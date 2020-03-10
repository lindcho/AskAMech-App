using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AskAMech.Command.Questions;
using AskAMech.Command.Services;
using AskAMech.Command.Test.Builders.Model;
using AskAMech.Command.Test.Builders.Questions;
using AskAMech.Data.DbGateways.Answers;
using AskAMech.Data.DbGateways.Questions;
using AskAMech.Domain.Models;
using NSubstitute;
using NUnit.Framework;

namespace AskAMech.Command.Test.Questions
{
    [TestFixture]
    public class TestQuestionCommand
    {

        [Test]
        public void QuestionCommands_GivenNoQuestionGateway_ShouldThrowException()
        {
            var ex = Assert.Throws<NullReferenceException>(() =>
            {
                var requestUserProvider = Substitute.For<IRequestUserProvider>();
                var answerGateway = Substitute.For<IAnswerGateway>();
                new QuestionCommands(null, requestUserProvider, answerGateway);
            });
            Assert.That(ex.Message, Is.EqualTo("QuestionGateway value cannot be null"));
        }

        [Test]
        public void QuestionCommands_GivenNoRequestProvider_ShouldThrowException()
        {
            var ex = Assert.Throws<NullReferenceException>(() =>
            {
                var questionGateway = Substitute.For<IQuestionGateway>();
                var answerGateway = Substitute.For<IAnswerGateway>();
                new QuestionCommands(questionGateway, null, answerGateway);
            });
            Assert.That(ex.Message, Is.EqualTo("RequestUserProvider value cannot be null"));
        }

        [Test]
        public void QuestionCommands_GivenNoAnswersGateway_ShouldThrowException()
        {
            var ex = Assert.Throws<NullReferenceException>(() =>
            {
                var questionGateway = Substitute.For<IQuestionGateway>();
                var requestUserProvider = Substitute.For<IRequestUserProvider>();
                new QuestionCommands(questionGateway, requestUserProvider, null);
            });
            Assert.That(ex.Message, Is.EqualTo("AnswerGateway value cannot be null"));
        }

        [Test]
        public void AskQuestion_GivenNoAuthor_ShouldTrowUserNotFound()
        {
            var questionGateway = Substitute.For<IQuestionGateway>();
            var requestUserProvider = Substitute.For<IRequestUserProvider>();
            var answerGateway = Substitute.For<IAnswerGateway>();

            var question = new Question
            {
                Id = 111,
                Title = "Test Question",
                Description = "Test Question Description",
                DateCreated = DateTime.Now,
                LastModified = DateTime.Now
            };
            var command = new QuestionCommands(questionGateway, requestUserProvider, answerGateway);
            var actual = command.AskQuestion(question, new CancellationToken());

            Assert.That(actual.Status, Is.EqualTo(TaskStatus.Faulted));
        }

        [Test]
        public void GetQuestion_WithInvalidId_ShouldReturnErrorResult()
        {
            //---------------Arrange----------------------

            var command = new AskQuestionCommandBuilder().Build();

            //---------------Act--------------------------
            var notFound = Assert.Throws<Exception>(() => command.GetQuestion(null));

            //---------------Assert-----------------------
            Assert.That(notFound.Message, Is.EqualTo("Id not found"));
        }

        [Test]
        public void GetQuestion_WithInvalidQuestionId_ShouldReturnErrorResult()
        {
            //---------------Arrange----------------------
            const int questionId = 0;

            var command = new AskQuestionCommandBuilder()
                .WithQuestionId(questionId)
                .Build();

            //---------------Act--------------------------
            var notFound = Assert.Throws<Exception>(() => command.GetQuestion(questionId));

            //---------------Assert-----------------------
            Assert.That(notFound.Message, Is.EqualTo("Question Id not found"));
        }

        [Test]
        public void AskQuestion_WithInvalidUserId_ShouldReturnErrorResult()
        {
            //---------------Arrange----------------------

            var question = new QuestionBuilder().Build();

            var command = new AskQuestionCommandBuilder()
                .WithInvalidUserId("")
                .Build();

            //---------------Act--------------------------
            var notFound = Assert.ThrowsAsync<Exception>(() => command.AskQuestion(question, new CancellationToken()));

            //---------------Assert-----------------------
            Assert.That(notFound.Message, Is.EqualTo("User not found"));
        }

        [Test]
        public void AskQuestion_WithExistingTitle_ShouldReturnErrorResult()
        {
            //---------------Arrange----------------------
            const string title = "where to buy a strong";
            const string userId = "22";

            var question = new QuestionBuilder().WithTitle(title).Build();
            var questions = new List<Question>
            {
                new QuestionBuilder().WithTitle(title).Build(),
                new QuestionBuilder().WithTitle(title).Build()
            };

            var command = new AskQuestionCommandBuilder()
                .WithExistingQuestionTitle(questions).WithInvalidUserId(userId)
                .Build();

            //---------------Act--------------------------
            var notFound = Assert.ThrowsAsync<Exception>(() => command.AskQuestion(question, new CancellationToken()));

            //---------------Assert-----------------------
            Assert.That(notFound.Message, Is.EqualTo("Title already exist!"));
        }

        [Test]
        public async Task AskQuestion_WithNewCreatedQuestion_ShouldReturnOkStatusCodeResult()
        {

            //---------------Arrange----------------------
            var questionGarGateway = Substitute.For<IQuestionGateway>();
            var requestUserProvider = Substitute.For<IRequestUserProvider>();
            var answerGateway = Substitute.For<IAnswerGateway>();

            var question = new Question
            {
                AuthorId = CreateUserId(),
                Id = 0,
                Title = "Test Question",
                Description = "Test Question Description. From Acceptance tests",
                DateCreated = DateTime.Now,
                LastModified = DateTime.Now
            };

            var existingQuestions = new List<Question>
            {
                new QuestionBuilder().WithTitle("tittle 1").Build(),
                new QuestionBuilder().WithTitle("tittle 2").Build(),
                new QuestionBuilder().WithTitle("tittle 3").Build(),
                new QuestionBuilder().WithTitle("tittle 4").Build(),
                new QuestionBuilder().WithTitle("title 5").Build()
            };

            var command = new AskQuestionCommandBuilder()
                .WithExistingQuestionTitle(existingQuestions)
                .WithValidUserId(question.AuthorId)
                .Build();

            var sut = CreateQuestionCommand(questionGarGateway, answerGateway, requestUserProvider).AskQuestion(question, CancellationToken.None);

            //---------------Assert-----------------------
            requestUserProvider.Received(1).GetUserId();
        }

        public string CreateUserId()
        {
            var answerBuilder = Substitute.For<IRequestUserProvider>();
            var id = answerBuilder.GetUserId().Returns("1f7999f-28be-4322-bc69-612ef8cccc5c");
            return id.ToString();
        }

        private QuestionCommands CreateQuestionCommand(IQuestionGateway questionGateway, IAnswerGateway answerGateway, IRequestUserProvider requestUserProvider)
        {
            return new QuestionCommands(questionGateway, requestUserProvider, answerGateway);
        }
    }
}

using System;
using System.Threading;
using System.Threading.Tasks;
using AskAMech.Command.Questions;
using AskAMech.Command.Services;
using AskAMech.Command.Test.Builders.Questions;
using AskAMech.Data.DbGateways.Answers;
using AskAMech.Data.DbGateways.Questions;
using AskAMech.Domain.Models;
using NSubstitute;
using NSubstitute.ReceivedExtensions;
using NUnit.Framework;
using PeanutButter.RandomGenerators;

namespace AskAMech.Command.Test.Acceptance
{
    [TestFixture]
    public class TestQuestionCommands
    {
        [Test]
        public void QuestionCommands_GivenNoQuestionGateway_ShouldThrowException()
        {
            var ex = Assert.Throws<NullReferenceException>(() => new QuestionCommands(null, Substitute.For<IRequestUserProvider>(), Substitute.For<IAnswerGateway>()));
            Assert.That(ex.Message, Is.EqualTo("Question Gateway not initialized"));
        }

        [Test]
        public void QuestionCommands_GivenNoRequestProvider_ShouldThrowException()
        {
            var ex = Assert.Throws<NullReferenceException>(() => new QuestionCommands(Substitute.For<IQuestionGateway>(), null, Substitute.For<IAnswerGateway>()));
            Assert.That(ex.Message, Is.EqualTo("User Provider not initialized"));
        }

        [Test]
        public void QuestionCommands_GivenNoAnswersGateway_ShouldThrowException()
        {
            var ex = Assert.Throws<NullReferenceException>(() => new QuestionCommands(Substitute.For<IQuestionGateway>(), Substitute.For<IRequestUserProvider>(), null));
            Assert.That(ex.Message, Is.EqualTo("Answers gateway not initialized"));
        }

        [Test]
        public void AskQuestion_GivenNoAuthor_ShouldTrowUserNotFound()
        {
            var question = new Question
            {
                Id = 111,
                Title = "Test Question",
                Description = "Test Question Description",
                DateCreated = DateTime.Now,
                LastModified = DateTime.Now
            };
            var command=new QuestionCommands(QuestionGateway(), RequestUserProvider(), AnswerGateway());
            var actual = command.AskQuestion(question, new CancellationToken());

            Assert.That(actual.Status,Is.EqualTo(TaskStatus.Faulted));
        }

        [Test]
        public void AskQuestion_GivenAuthour_ShouldAddQuestion()
        {
            var question = new Question
            {
                Title = "Test Question 1",
                Description = "Test Question Description",
                DateCreated = DateTime.Now,
                LastModified = DateTime.Now,
                AuthorId = CreateUserId()
            };
            var command = new QuestionCommands(QuestionGateway(), RequestUserProvider(), AnswerGateway());
            var actual = command.AskQuestion(question, new CancellationToken());

            Assert.That(actual.Status, Is.EqualTo(TaskStatus.Created));
            //Assert.That(actual.Exception,Is.TypeOf<Exception>()());
            //Assert.That(actual.Exception.Message,Is.TypeOf<Exception>());
        }

        public IAnswerGateway AnswerGateway()
        {
            var answerBuilder = Substitute.For<IAnswerGateway>();
            return answerBuilder;
        }

        public IQuestionGateway QuestionGateway()
        {
            var answerBuilder = Substitute.For<IQuestionGateway>();
            return answerBuilder;
        }

        public IRequestUserProvider RequestUserProvider()
        {
            var answerBuilder = Substitute.For<IRequestUserProvider>();
            return answerBuilder;
        }

        public string CreateUserId()
        {
            var answerBuilder = Substitute.For<IRequestUserProvider>();
            var id = answerBuilder.GetUserId().Returns("1f7999f-28be-4322-bc69-612ef8cccc5c");
            return id.ToString();
        }
    }
}

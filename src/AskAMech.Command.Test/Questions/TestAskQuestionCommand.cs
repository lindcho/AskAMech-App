using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AskAMech.Command.Test.Builders.Model;
using AskAMech.Command.Test.Builders.Questions;
using AskAMech.Data.DbGateways.Questions;
using AskAMech.Domain.Models;
using NUnit.Framework;

namespace AskAMech.Command.Test.Questions
{
    [TestFixture]
    public class TestQuestionCommand
    {
        private readonly IQuestionGateway _questionGateway;
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

        [Ignore("Need to fix the test")]
        [Test]
        public  void AskQuestion_WithNewCreatedQuestion_ShouldReturnOkStatusCodeResult()
        {

            //---------------Arrange----------------------

            var voidTaskType = typeof(Task<>).MakeGenericType(Type.GetType("System.Threading.Tasks.VoidTaskResult"));
            var question = new QuestionBuilder().Build();

            var command = new AskQuestionCommandBuilder()
                .WithQuestionCreated(question)
                .Build();

            //---------------Act--------------------------
            //---------------Assert-----------------------

            //Assert.That(command.AskQuestion(question, new CancellationToken()), Is.TypeOf<Task<Task>>());
            Assert.That(command.AskQuestion(question, new CancellationToken()), Is.EqualTo(voidTaskType));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Threading;
using AskAMech.Command.Test.Builders.Model;
using AskAMech.Command.Test.Builders.Questions;
using AskAMech.Domain.Models;
using NUnit.Framework;

namespace AskAMech.Command.Test.Questions
{
    [TestFixture]
    public class TestQuestionCommand
    {
        [Test]
        public void GetQuestion_WithInvalidId_ShouldReturnError()
        {
            //---------------Arrange----------------------
            const int questionId = 0;

            var command = new AskQuestionCommandBuilder()
                .WithQuestionId(questionId)
                .Build();

            //---------------Act--------------------------
            var notFound = Assert.Throws<Exception>(() => command.GetQuestion(null));

            //---------------Assert-----------------------
            Assert.That(notFound.Message, Is.EqualTo("Id not found"));
        }

        [Test]
        public void GetQuestion_WithInvaliQuestionId_ShouldReturnErrorResult()
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
            const string userId = "";

            var question = new QuestionBuilder().Build();

            var command = new AskQuestionCommandBuilder()
                .WithInvalidUserId(userId)
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
        public void UpdateQuestion_WithInvalidUserId_ShouldReturnErrorResult()
        {
            //---------------Arrange----------------------
            const string userId = "";

            var question = new QuestionBuilder().Build();

            var command = new AskQuestionCommandBuilder()
                .WithInvalidUserId(userId)
                .Build();

            //---------------Act--------------------------
            var notFound = Assert.ThrowsAsync<Exception>(() => command.UpdateQuestion(question, new CancellationToken()));

            //---------------Assert-----------------------
            Assert.That(notFound.Message, Is.EqualTo("User not found"));
        }
    }
}

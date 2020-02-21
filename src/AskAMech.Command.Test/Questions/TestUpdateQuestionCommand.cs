using System;
using System.Threading;
using AskAMech.Command.Test.Builders.Model;
using AskAMech.Command.Test.Builders.Questions;
using AskAMech.Domain.Models;
using NUnit.Framework;

namespace AskAMech.Command.Test.Questions
{
    [TestFixture]
    public class TestUpdateQuestionCommand
    {
        [Test]
        public void UpdateQuestion_WithInvalidUserId_ShouldReturnErrorResult()
        {
            //---------------Arrange----------------------

            var question = new QuestionBuilder().Build();
            var command = new AskQuestionCommandBuilder()
                .WithInvalidUserId("")
                .Build();

            //---------------Act--------------------------
            var notFound = Assert.ThrowsAsync<Exception>(() => command.UpdateQuestion(question, new CancellationToken()));

            //---------------Assert-----------------------
            Assert.That(notFound.Message, Is.EqualTo("User not found"));
        }

        [Test]
        public void UpdateQuestion_WithNewUpdatedQuestion_ShouldReturnQuestion()
        {
            //---------------Arrange----------------------

            var newQuestionTitle = "New Title Testing";

            var oldQuestion = new Question
            {
                Id = 5,
                Title = "Old Title testing",
                DateCreated = DateTime.Parse("2020-01-20"),
                Description = "Old Test description"
            };

            var question = new QuestionBuilder().WithId(5)
                .WithDateCreated(oldQuestion.DateCreated)
                .WithTitle(newQuestionTitle)
                .Build();

            var command = new AskQuestionCommandBuilder()
                .WithNewUpdatedQuestiond(question)
                .WithQuestionToUpdate(5, oldQuestion)
                .WithValidUserId("12")
                .Build();

            //---------------Act--------------------------

            var result = command.UpdateQuestion(question, new CancellationToken());

            //---------------Assert-----------------------

            Assert.That(result, Is.Not.Null);
            var resultTitle = result.Result.Title;
            Assert.That(oldQuestion.Title, Is.EqualTo("Old Title testing"));
            Assert.That(resultTitle, Is.EqualTo("New Title Testing"));
        }
    }
}

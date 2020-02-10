using System;
using System.Threading.Tasks;
using AskAMech.Command.Test.Builders.Questions;
using NUnit.Framework;

namespace AskAMech.Command.Test.Questions
{
    [TestFixture]
    public class TestQuestionCommand
    {
        [Test]
        public void AskQuestion_WithInvalidUserId_ShouldReturnError()
        {
            // Arrange
            const int questionId = 0;

            var command = new AskQuestionCommandBuilder()
                .WithQuestionId(questionId)
                .Build();

            var notFound = Assert.Throws<Exception>(() => command.GetQuestion(null));
            Assert.That(notFound.Message, Is.EqualTo("Id not found"));
        }

        [Test]
        public void GetQuestion_WithValidUserId_ShouldReturnErrorResult()
        {
            // Arrange
            const int questionId = 0;

            var command = new AskQuestionCommandBuilder()
                .WithQuestionId(questionId)
                .Build();

            var notFound = Assert.Throws<Exception>(() => command.GetQuestion(questionId));
            Assert.That(notFound.Message, Is.EqualTo("Question Id not found"));
        }
    }
}

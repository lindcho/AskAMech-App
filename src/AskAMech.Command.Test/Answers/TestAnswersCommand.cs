using System;
using System.Threading;
using System.Threading.Tasks;
using AskAMech.Command.Test.Builders;
using AskAMech.Domain.Models;
using NUnit.Framework;

namespace AskAMech.Command.Test.Answers
{
    [TestFixture]
    public class TestAnswersCommand
    {
        [Test]
        public void AnswerQuestion_NotLoggedIn_ShouldTrowException()
        {
            var question = new Question
            {
                AuthorId = "abc",
                Id = 1,
                Title = "Test Question",
                Description = "Test Question Description. From Acceptance tests",
                DateCreated = DateTime.Now,
                LastModified = DateTime.Now
            };

            var answer = new Answer()
            {
                Question = question,
                AnswerId = 3,
                AuthorId = null,
                Date = DateTime.Now,
                Description = "Answer from tests",
                QuestionId = 1
            };


            var command = new AnswerQuestionBuilder()
                .WithInvalidUserId(answer.AuthorId).WithQuestion(question).Build();

            var actual = command.AnswerQuestion(answer, new CancellationToken());

            var result = actual.Exception;

            Assert.That(result.Message, Is.EqualTo("One or more errors occurred. (User not found)"));

        }

        [Test]
        public void AnswerQuestion_WithInvalidQuestion_ShouldTrowException()
        {
            var question = new Question
            {
                Id = 1,
                Title = "Test Question",
                Description = "Test Question Description. From Acceptance tests",
                DateCreated = DateTime.Now,
                LastModified = DateTime.Now
            };

            var answer = new Answer()
            {
                Question = question,
                AnswerId = 4,
                AuthorId = question.AuthorId,
                Date = DateTime.Now,
                Description = "Answer from tests",
                QuestionId = 0
            };


            var command = new AnswerQuestionBuilder()
                .WithInvalidUserId(answer.AuthorId)
                .WithQuestion(question).WithGeneratedUserId().Build();

            var actual = command.AnswerQuestion(answer, new CancellationToken());

            var result = actual.Exception;

            Assert.That(result.Message, Is.EqualTo("One or more errors occurred. (Question not found)"));

        }

        [Test]
        public void AnswerQuestion_WithValidData_ShouldSaveQuestion()
        {
            var question = new Question
            {
                Id = 1,
                Title = "Test Question",
                Description = "Test Question Description. From Acceptance tests",
                DateCreated = DateTime.Now,
                LastModified = DateTime.Now
            };

            var answer = new Answer()
            {
                Question = question,
                AnswerId = 4,
                AuthorId = question.AuthorId,
                Date = DateTime.Now,
                Description = "Answer from tests",
                QuestionId = 1
            };

            var command = new AnswerQuestionBuilder()
                .WithInvalidUserId(answer.AuthorId)
                .WithQuestion(question).WithGeneratedUserId().Build();

            var actual = command.AnswerQuestion(answer, new CancellationToken());

            var result = actual.Status;

            Assert.That(result, Is.EqualTo(TaskStatus.RanToCompletion));

        }



    }
}

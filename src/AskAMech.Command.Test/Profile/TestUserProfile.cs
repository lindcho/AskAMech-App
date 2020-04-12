using AskAMech.Command.Answers;
using AskAMech.Command.Questions;
using AskAMech.Command.Services;
using AskAMech.Domain;
using AskAMech.Domain.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace AskAMech.Command.Test.Profile
{
      [TestFixture]
        public class TestUserProfile
        {
            private readonly IRequestUserProvider _requestUserProvider;
            private readonly IQuestionCommands _questionCommands;
            private readonly IAnswersCommand _answersCommand;

            [Test]
            public async void GetUserByUserId_GivenUserId_ShouldReturnUserProfileDetailsAsync()
            {
                // Arrange
                var userId = "1f7999f-28be-4322-bc69-612ef8bbbb5c";
                //Act
                var user = await _requestUserProvider.GetUserByUserId(userId);
                //Assert
                Assert.That(user, Is.Not.Null);
                Assert.That(user.FullName, Is.EqualTo("Khanyisile"));
                Assert.That(user.Email, Is.EqualTo("askamech@gmail.com"));
                Assert.That(user.PhoneNumber, Is.EqualTo("0746009500"));

            }

            [Test]
            public async void GetUserQuestions_GivenUserId_ShouldReturnUserQuestions()
            {
                // Arrange
                var userId = "1f7999f-28be-4322-bc69-612ef8bbbb5c";
                //Act
                var questions = await _questionCommands.GetUserQuestions(userId);
                //Assert
                Assert.That(questions, Is.Not.Null);
                Assert.That(questions.Count, Is.EqualTo(1));
                Assert.That(questions.GetType(), Is.EqualTo(typeof(List<Question>)));

            }

        [Test]
        public void GetQuestionsWithAnswers_GivenUserId_ShouldReturnQuestionsWithAnswers()
        {
            // Arrange
            var userId = "1f7999f-28be-4322-bc69-612ef8bbbb5c";
            //Act
            var questionAnswers = _answersCommand.GetQuestionsWithAnswers(userId);
            //Assert
            Assert.That(questionAnswers, Is.Not.Null);
            Assert.That(questionAnswers.GetType(), Is.EqualTo(typeof(System.Linq.IQueryable<AnswersListViewModel>)));
        }

    }
}

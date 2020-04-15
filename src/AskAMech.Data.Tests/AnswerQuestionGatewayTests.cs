using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AskAMech.Data.DbGateways.Answers;
using AskAMech.Data.DbGateways.Questions;
using AskAMech.Domain.Models;
using AskAMech.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace AskAMech.Data.Tests
{
    public class AnswerQuestionGatewayTests
    {
        private AnswerGateway _answerGateway;
        private QuestionGateway _questionGateway;

        [SetUp]
        public void TestSetup()
        {
            var optionsBuilder = BuildDbConnection();
            var dbContext = new ApplicationDbContext(optionsBuilder.Options);
            _answerGateway = new AnswerGateway(dbContext);
            _questionGateway = new QuestionGateway(dbContext);
        }

        private static DbContextOptionsBuilder<ApplicationDbContext> BuildDbConnection()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer(
                "Server=(localdb)\\mssqllocaldb;Database=AskAMech;Trusted_Connection=True;MultipleActiveResultSets=true");
            return optionsBuilder;
        }

        [Test]
        public void IsGatewayInitializedWithValidNumberOfData()
        {
            var questions = _answerGateway.GetAllAnswers(new CancellationToken());
            Assert.IsNotNull(questions);
            var numberOfRecords = questions.Result.ToList().Count;
            Assert.AreEqual(7, numberOfRecords);
        }

        [Test]
        [Ignore("manually run test")]
        public async Task Add_GivenValidAnswerDetails_ShouldAddAnswerAndIncreaseRecordCountAsync()
        {
            const string authorId = "36b2db51-238e-4224-ad1d-fe3077a5e4e4";
            const int questionId = 2;
            const string description = "Please have a look at this link. https://www.continental-tires.com/car/tire-knowledge/tire-change-fitting/fitting-tires";
            var date = DateTime.Now;

            var answer = MakeAnswer(questionId, authorId, description, date);
            await _answerGateway.AddAnswer(answer, new CancellationToken());

            var result = _answerGateway.GetAllAnswers(new CancellationToken());
            var numberOfRecords = result.Result.ToList().Count;
            Assert.AreEqual(7, numberOfRecords);
        }

        [Test]
        public void AddAnswer_MissingAnswerDescription_ShouldThrowException()
        {
            const string authorId = "36b2db51-238e-4224-ad1d-fe3077a5e4e4";
            const int questionId = 2;
            var date = DateTime.Now;

            var answer = MakeAnswer(questionId, authorId, date);

            const string errorMessage = "An error occurred while updating the entries. See the inner exception for details.";
            Assert.That(async () => await _answerGateway.AddAnswer(answer, new CancellationToken()), Throws.Exception.TypeOf<DbUpdateException>().And.Message.EqualTo(errorMessage));
        }

        [Test]
        public void Add_MissingQuestionId_ShouldThrowException()
        {
            const string authorId = "36b2db51-238e-4224-ad1d-fe3077a5e4e4";
            const string description = "Please have a look at this link. https://www.continental-tires.com/car/tire-knowledge/tire-change-fitting/fitting-tires";
            var date = DateTime.Now;

            var answer = MakeAnswer(authorId, description, date);

            const string errorMessage = "An error occurred while updating the entries. See the inner exception for details.";
            Assert.That(async () => await _answerGateway.AddAnswer(answer, new CancellationToken()), Throws.Exception.TypeOf<DbUpdateException>().And.Message.EqualTo(errorMessage));
        }
        [Test]
        [Ignore("manually run test")]
        public async Task MarkAsAccepted_GivenValidDetails_ShouldMarkAnswerAsAccepted()
        {
            var question = await _questionGateway.GetQuestion(2);
            question.AcceptedAnswerId = 8;

            await _answerGateway.AcceptAnswer(question, new CancellationToken());
        }

        private static Answer MakeAnswer(int questionId, string authorId, string description, DateTime date)
        {
            return new Answer { QuestionId = questionId, AuthorId = authorId, Description = description, Date = date };
        }

        private static Answer MakeAnswer(int questionId, string authorId, DateTime date)
        {
            return new Answer { QuestionId = questionId, AuthorId = authorId, Date = date };
        }

        private static Answer MakeAnswer(string authorId, string description, DateTime date)
        {
            return new Answer { AuthorId = authorId, Description = description, Date = date };
        }
    }
}

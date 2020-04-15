using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AskAMech.Data.DbGateways.Questions;
using AskAMech.Domain.Models;
using AskAMech.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace AskAMech.Data.Tests
{
    [Category("Question")]
    public class QuestionGatewayTests
    {
        private QuestionGateway _questionGateway;

        [SetUp]
        public void TestSetup()
        {
            var optionsBuilder = BuildDbConnection();
            var dbContext = new ApplicationDbContext(optionsBuilder.Options);
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
            var questions = _questionGateway.GetAll(new CancellationToken());
            Assert.IsNotNull(questions);
            var numberOfRecords = questions.Result.ToList().Count;
            Assert.AreEqual(6, numberOfRecords);
        }

        [Test]
        [Ignore("manually run test")]
        public async Task Add_GivenValidModel_ShouldAddQuestionAndIncreaseRecordCountAsync()
        {
            Question certificateToInsert = new Question()
            {
                AuthorId = "36b2db51-238e-4224-ad1d-fe3077a5e4e4",
                Title = "When Should I Change My Transmission Fluid?",
                Description = "The Automatic Transmission Rebuilders Association (ATRA) recommends changing your transmission fluid every 50,000 km, or two years. If you want to know more about transmission fluid and why it’s so important",
                DateCreated = DateTime.Now.Subtract(TimeSpan.FromDays(60)),
                LastModified = DateTime.Now.Subtract(TimeSpan.FromDays(30))
            };
            await _questionGateway.Add(certificateToInsert, new CancellationToken());
            var result = _questionGateway.GetAll(new CancellationToken());
            var numberOfRecords = result.Result.ToList().Count;
            Assert.AreEqual(10, numberOfRecords);
        }

        [Test]
        public void Add_MissingTitle_ShouldThrowException()
        {
            Question questionToInsert = new Question()
            {
                AuthorId = "36b2db51-238e-4224-ad1d-fe3077a5e4e4",
                Description = "The Automatic Transmission Rebuilders Association (ATRA) recommends changing your transmission fluid every 50,000 km, or two years. If you want to know more about transmission fluid and why it’s so important",
                DateCreated = DateTime.Now.Subtract(TimeSpan.FromDays(60)),
                LastModified = DateTime.Now.Subtract(TimeSpan.FromDays(30))
            };

            const string errorMessage = "An error occurred while updating the entries. See the inner exception for details.";
            Assert.That(async () => await _questionGateway.Add(questionToInsert, new CancellationToken()), Throws.Exception.TypeOf<DbUpdateException>().And.Message.EqualTo(errorMessage));
        }

        [Test]
        [Ignore("run manually")]
        public async Task Update_ShouldUpdateModelSuccessfully()
        {
            var newCVJointDescription =
                "problem with CV joints is when the protective boot cracks or gets damaged. Once this happens, the grease comes out and moisture and dirt get in, causing the CV joint to wear faster and eventually fail due to lack of lubrication and corrosion.";

            var question = await _questionGateway.GetQuestion(3);
            question.Description = newCVJointDescription;
            question.LastModified = DateTime.Now;

            await _questionGateway.Update(question, new CancellationToken());

            Assert.AreEqual(newCVJointDescription, question.Description);
        }

        [Test]
        public async Task GetUserQuestions_GivenValidUserId_ShouldGetAllQuestionsForUser()
        {
            var userId = "1f7999f-28be-4322-bc69-612ef8cccc5c";
            var userQuestions = await _questionGateway.GetUserQuestions(userId);


            Assert.That(userQuestions, Is.Not.Null);
            Assert.That(userQuestions.Count, Is.EqualTo(2));
        }

        [Test]
        public async Task GetUserQuestions_GivenInValidUserId_ShouldReturnEmptyList()
        {
            var userId = "1f7999f-28be-4322-bc69-612ef8cccc6G";
            var userQuestions = await _questionGateway.GetUserQuestions(userId);


            Assert.That(userQuestions, Is.Empty);
        }
    }
}
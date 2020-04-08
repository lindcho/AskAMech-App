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
    public class Tests
    {
        private QuestionGateway _questionGateway;

        [SetUp]
        public void TestSetup()
        {
            var optionsBuilder = BuildDbConnection();
            var certificateContext = new ApplicationDbContext(optionsBuilder.Options);
            _questionGateway = new QuestionGateway(certificateContext);
        }

        private static DbContextOptionsBuilder<ApplicationDbContext> BuildDbConnection()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer(
                "Server=(localdb)\\mssqllocaldb;Database=AskAMech;Trusted_Connection=True;MultipleActiveResultSets=true");
            return optionsBuilder;
        }

        [Test]
        [Ignore("manually run")]
        public void IsGatewayInitializedWithValidNumberOfData()
        {
            var questions = _questionGateway.GetAll(new CancellationToken());
            Assert.IsNotNull(questions);
            var numberOfRecords = questions.Result.ToList().Count;
            Assert.AreEqual(5, numberOfRecords);
        }

        [Test]
        [Ignore("manually run test")]
        public async Task Add_GivenFiveRecordsInDb_ShouldAddQuestionAndIncreaseRecordCountAsync()
        {
            Question certificateToInsert = new Question()
            {
                AuthorId = "36b2db51-238e-4224-ad1d-fe3077a5e4e4",
                Title = "How to boost a toyota etios 2015 using jumper cables?",
                Description = "My car refuses to start and i have been told its a battery problem, how can i boost it so that i can go buy battery.",
                DateCreated = DateTime.Now.Subtract(TimeSpan.FromDays(60)),
                LastModified = DateTime.Now.Subtract(TimeSpan.FromDays(30))
            };
            await _questionGateway.Add(certificateToInsert, new CancellationToken());
            var result = _questionGateway.GetAll(new CancellationToken());
            var numberOfRecords = result.Result.ToList().Count;
            Assert.AreEqual(6, numberOfRecords);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AskAMech.Domain.Models;
using AskAMech.Infrastructure.Data;

namespace AskAMech.Command.Gateways
{
    public class QuestionGateway : IQuestionGateway
    {
        private readonly ApplicationDbContext _dbContext;

        public QuestionGateway(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Question> GetAllQuestions()
        {
            return _dbContext.Questions.ToList();
        }
    }
}

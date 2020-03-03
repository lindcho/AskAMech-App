using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AskAMech.Domain;
using AskAMech.Domain.Models;
using AskAMech.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AskAMech.Data.DbGateways.Answers
{
    public class AnswerGateway : IAnswerGateway
    {
        private readonly ApplicationDbContext _context;

        public AnswerGateway(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAnswer(Answer answer, CancellationToken cancellationToken)
        {
            _context.Answers.Add(answer);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task AcceptAnswer(Question question, CancellationToken cancellationToken)
        {
            _context.Questions.Update(question);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<Answer> GetOneAnswer(int id)
        {
            return await _context.Answers.FindAsync(id);
        }

        public async Task<List<Answer>> GetAllAnswers(CancellationToken cancellationToken)
        {
            return await _context.Answers.
                Include(x => x.Author)
                .ToListAsync(cancellationToken: cancellationToken);
        }
        public IQueryable<AnswersListViewModel> GetUserAnswers(string currentUserId)
        {
            var queryable = from question in _context.Questions
                            join answer in _context.Answers on question.Id equals answer.QuestionId into combined
                            from subList in combined.DefaultIfEmpty().Where(q => currentUserId == question.AuthorId && question.Id == q.QuestionId)
                            group question by new { subList.QuestionId, subList.Description, subList.Date };

            var data = from grouping in queryable
                       select new AnswersListViewModel
                       {
                           QuestionId = grouping.Key.QuestionId,
                           AnswerDescription = grouping.Key.Description,
                           DateAnswered = grouping.Key.Date
                       };
            return data;
        }
    }
}

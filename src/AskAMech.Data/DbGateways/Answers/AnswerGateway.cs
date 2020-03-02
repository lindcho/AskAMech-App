using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
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
        public async Task<List<Answer>> GetUserAnswers(string currentUserId)
        {
            var answers = GetAllAnswers();
            return answers.Where(a => a.AuthorId == currentUserId).ToList();
        }

        private List<Answer> GetAllAnswers()
        {
            return _context.Answers.ToList();
        }
    }
}

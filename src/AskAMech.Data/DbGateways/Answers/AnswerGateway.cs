using System.Collections.Generic;
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

        public async Task<List<Answer>> GetAllAnswers(CancellationToken cancellationToken)
        {
            return await _context.Answers.
                Include(x => x.Author)
                .ToListAsync(cancellationToken: cancellationToken);
        }
    }
}

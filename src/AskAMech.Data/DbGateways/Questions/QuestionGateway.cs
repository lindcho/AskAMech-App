using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AskAMech.Domain.Models;
using AskAMech.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AskAMech.Data.DbGateways.Questions
{

    public class QuestionGateway : IQuestionGateway
    {
        private readonly ApplicationDbContext _context;

        public QuestionGateway(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Question>> GetAll(CancellationToken cancellationToken)
        {
            return await _context.Questions
                .Include(q => q.Author)
                .ToListAsync(cancellationToken);
        }

        public async Task Add(Question question, CancellationToken cancellationToken)
        {
            _context.Questions.Add(question);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task Update(Question question, CancellationToken cancellationToken)
        {
                _context.Questions.Update(question);
                await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<Question> GetQuestion(int? id)
        {
            var question = await _context.Questions.AsNoTracking()
                .Include(q => q.Author)
                .FirstOrDefaultAsync(q => q.Id == id);
            return question;
        }

        public async Task<List<Question>> GetUserQuestions(string currentUserId)
        {
            var questions = await GetAll(new CancellationToken());
            return questions.Where(x => x.AuthorId == currentUserId).ToList();
        }
    }
}

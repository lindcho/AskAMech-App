using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AskAMech.Domain.Models;
using AskAMech.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AskAMech.Data.DbGateways
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

        public async Task<Question> Update(Question question, CancellationToken cancellationToken)
        {
            var currentUserId = "12323435";
            if (string.IsNullOrEmpty(currentUserId))
            {
                // NotFoundException(nameof(ApplicationUser), currentUserId);
            }

            try
            {
                question.LastModified = DateTime.Now;
                question.AuthorId = currentUserId;
                _context.Questions.Update(question);
                await _context.SaveChangesAsync(cancellationToken);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return question;
        }

        public async Task<Question> GetQuestion(int? id)
        {
            var question = await _context.Questions
                .Include(q => q.Author)
                .FirstOrDefaultAsync(q => q.Id == id);
            return question;
        }

        public async Task<List<Question>> GetUserQuestions()
        {
            var currentUserId = "12323435";
            if (string.IsNullOrEmpty(currentUserId))
            {
                //throw;// new NotFoundException(nameof(ApplicationUser), currentUserId);
            }

            var questions = await GetAll(new CancellationToken());
            return questions.Where(x => x.AuthorId == currentUserId).ToList();
        }

        public bool CanUserEditQuestion(int? id)
        {
            var currentUserId = "12323435";
            var author = GetQuestion(id);
            return currentUserId == author.Result.AuthorId;
        }
    }
}

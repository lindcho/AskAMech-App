using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AskAMech.Domain;
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

        public IQueryable<QuestionsListGroupViewModel> GetQuestionList()
        {
            var queryable = from question in _context.Questions
                            join answer in _context.Answers on question.Id equals answer.QuestionId into combined
                            from subList in combined.DefaultIfEmpty()
                            group question by new { question.Id, question.Title, question.DateCreated, question.Author.UserName, question.Answers.Count, question.AcceptedAnswerId };

            var data = from groupCount in queryable
                       select new QuestionsListGroupViewModel()
                       {
                           QuestionId = groupCount.Key.Id,
                           Title = groupCount.Key.Title,
                           AuthorName = groupCount.Key.UserName,
                           DateCreated = groupCount.Key.DateCreated,
                           AcceptedAnswerId = groupCount.Key.AcceptedAnswerId,
                           AnswerCount = groupCount.Key.Count
                       };
            return data.OrderByDescending(x => x.QuestionId);
        }
    }
}

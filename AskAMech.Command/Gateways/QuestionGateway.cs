using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AskAMech.Command.Exceptions;
using AskAMech.Command.Services;
using AskAMech.Domain.Models;
using AskAMech.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AskAMech.Command.Gateways
{

    public class QuestionGateway : IQuestionGateway
    {
        private readonly ApplicationDbContext _context;
        private readonly IRequestUserProvider _requestUserProvider;

        public QuestionGateway(ApplicationDbContext context, IRequestUserProvider requestUserProvider)
        {
            _context = context;
            _requestUserProvider = requestUserProvider;
        }

        public async Task<List<Question>> GetAllQuestions(CancellationToken cancellationToken)
        {
            return await _context.Questions.Include(q => q.Author).ToListAsync(cancellationToken: cancellationToken);
        }

        public async Task Add(Question question, CancellationToken cancellationToken)
        {
            var currentUserId = _requestUserProvider.GetUserId();
            if (string.IsNullOrEmpty(currentUserId))
            {
                throw new NotFoundException(nameof(ApplicationUser), currentUserId);
            }

            var questions = await GetAllQuestions(cancellationToken);
            if (questions.Any(t => t.Title == question.Title))
            {
                throw new ArgumentException("Title already exist!");
            }

            try
            {
                question.DateCreated = DateTime.Now;
                question.LastModified = DateTime.Now;
                question.AuthorId = currentUserId;
                _context.Questions.Add(question);
                await _context.SaveChangesAsync(cancellationToken);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<Question> Update(Question question, CancellationToken cancellationToken)
        {
            var currentUserId = _requestUserProvider.GetUserId();
            if (string.IsNullOrEmpty(currentUserId))
            {
                throw new NotFoundException(nameof(ApplicationUser), currentUserId);
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
            var currentUserId = _requestUserProvider.GetUserId();
            if (string.IsNullOrEmpty(currentUserId))
            {
                throw new NotFoundException(nameof(ApplicationUser), currentUserId);
            }

            var questions = await GetAllQuestions(new CancellationToken());
            return questions.Where(x => x.AuthorId == currentUserId).ToList();
        }

        public bool CanUserEditQuestion(int? id)
        {
            var currentUserId = _requestUserProvider.GetUserId();
            var author = GetQuestion(id);
            return currentUserId == author.Result.AuthorId;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
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
            question.DateCreated = DateTime.Now;
            question.LastModified = DateTime.Now;
            question.AuthorId = _requestUserProvider.GetUserId();
            _context.Questions.Add(question);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<Question> Update( Question question,CancellationToken cancellationToken)
        {
            question.LastModified = DateTime.Now;
            question.AuthorId = "946e894f-1bee-4f63-b741-77f47953fa86";
            _context.Questions.Update(question);
            await _context.SaveChangesAsync(cancellationToken);
            return question;
        }

        public async Task<Question> GetQuestion(int? id)
        {
            var question = await _context.Questions.FindAsync(id);
            return question;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AskAMech.Domain.Models;
using AskAMech.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AskAMech.Command.Gateways
{
    public class QuestionGateway : IQuestionGateway
    {
        private readonly ApplicationDbContext _context;

        public QuestionGateway(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Question>> GetAllQuestions(CancellationToken cancellationToken)
        {
            return await _context.Questions.Include(q => q.Author).ToListAsync(cancellationToken: cancellationToken);
        }

        public async Task Add(Question question, CancellationToken cancellationToken)
        {
            question.DateCreated = DateTime.Now;
            question.LastModified = DateTime.Now;
            //TODO Remove after implementing service for current user
            question.AuthorId = "946e894f-1bee-4f63-b741-77f47953fa86";
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

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
            question.AuthorId = "aaa7d6f1-6515-4425-bc4e-094e135ad1b0";
            _context.Questions.Add(question);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}

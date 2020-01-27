using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AskAMech.Command.Exceptions;
using AskAMech.Command.Services;
using AskAMech.Data.DbGateways;
using AskAMech.Domain.Models;

namespace AskAMech.Command.Questions
{
    public class QuestionCommands : IQuestionCommands
    {
        public readonly IQuestionGateway _questionGateway;
        private readonly IRequestUserProvider _requestUserProvider;

        public QuestionCommands(IQuestionGateway questionGateway, IRequestUserProvider requestUserProvider)
        {
            _questionGateway = questionGateway;
            _requestUserProvider = requestUserProvider;
        }

        public Task<List<Question>> GetAllQuestions(CancellationToken cancellationToken)
        {
            return _questionGateway.GetAll(cancellationToken);
        }

        public async Task AskQuestion(Question question, CancellationToken cancellationToken)
        {
            var currentUserId = _requestUserProvider.GetUserId();
            if (string.IsNullOrEmpty(currentUserId))
            {
                throw new NotFoundException(nameof(ApplicationUser), currentUserId);
            }

            var questions = await _questionGateway.GetAll(cancellationToken);
            if (questions.Any(t => t.Title == question.Title))
            {
                throw new ArgumentException("Title already exist!");
            }

            try
            {
                question.DateCreated = DateTime.Now;
                question.LastModified = DateTime.Now;
                question.AuthorId = currentUserId;
                await _questionGateway.Add(question, cancellationToken);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}

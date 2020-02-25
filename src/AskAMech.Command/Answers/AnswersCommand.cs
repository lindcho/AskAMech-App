using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AskAMech.Command.Services;
using AskAMech.Data.DbGateways.Answers;
using AskAMech.Data.DbGateways.Questions;
using AskAMech.Domain.Models;

namespace AskAMech.Command.Answers
{
    public class AnswersCommand : IAnswersCommand
    {
        private readonly IAnswerGateway _answersGateway;
        private readonly IQuestionGateway _questionGateway;
        private readonly IRequestUserProvider _requestUserProvider;

        public AnswersCommand(IAnswerGateway answersGateway, IQuestionGateway questionGateway, IRequestUserProvider requestUserProvider)
        {
            _answersGateway = answersGateway;
            _questionGateway = questionGateway;
            _requestUserProvider = requestUserProvider;
        }

        public async Task<List<Answer>> GetAnswersByQuestionId(int questionId, CancellationToken cancellationToken)
        {
            var answers = await _answersGateway.GetAllAnswers(cancellationToken);
            var questionAnswers = answers
                .Where(x => x.QuestionId == questionId)
                .OrderByDescending(x => x.AnswerId)
                .ToList();
            return questionAnswers;
        }

        public async Task AnswerQuestion(Answer answer, CancellationToken cancellationToken)
        {
            var currentUserId = _requestUserProvider.GetUserId();
            if (string.IsNullOrEmpty(currentUserId))
            {
                throw new Exception("User not found");

            }

            var question = await _questionGateway.GetQuestion(answer.QuestionId);
            if (question == null)
            {
                throw new Exception("Question not found");
            }
            try
            {
                answer.AuthorId = currentUserId;
                answer.Date = DateTime.Now;
                await _answersGateway.AddAnswer(answer, cancellationToken);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        public async Task AcceptAnswer(int answerId, CancellationToken cancellationToken)
        {
            var answer = await _answersGateway.GetOneAnswer(answerId);
            if (answer == null) throw new Exception("No matching answer found");

            var question = _questionGateway.GetQuestion(answer.QuestionId).Result;
            if (question == null) throw new Exception("Question not found");

            var currentUserId = _requestUserProvider.GetUserId();
            if (question.AuthorId != currentUserId) throw new Exception("Only the question author can accept answer");

            question.AcceptedAnswerId = answerId;
            await _answersGateway.AcceptAnswer(question, cancellationToken);
        }

    }
}

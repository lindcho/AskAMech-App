using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AskAMech.Data.DbGateways.Answers;
using AskAMech.Domain.Models;

namespace AskAMech.Command.Answers
{
    public class AnswersCommand : IAnswersCommand
    {
        private readonly IAnswerGateway _answersGateway;

        public AnswersCommand(IAnswerGateway answersGateway)
        {
            _answersGateway = answersGateway;
        }

        public async Task<List<Answer>> GetAnswersByQuestionId(int questionId, CancellationToken cancellationToken)
        {
            var answers = await _answersGateway.GetAllAnswers(cancellationToken);
            var questionAnswers = answers.Where(x => x.QuestionId == questionId).ToList();
            return questionAnswers;
        }
    }
}

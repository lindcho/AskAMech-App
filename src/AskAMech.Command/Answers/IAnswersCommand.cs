using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AskAMech.Domain.Models;

namespace AskAMech.Command.Answers
{
    public interface IAnswersCommand
    {
        Task<List<Answer>> GetAnswersByQuestionId(int questionId, CancellationToken cancellationToken);
        Task AnswerQuestion(Answer answer, CancellationToken cancellationToken);
        Task AcceptAnswer(int answerId, CancellationToken cancellationToken);
        Task<List<Answer>> GetCurrentUserAnswers();
        Task<Answer> GetAcceptedAnswerByQuestionId(int questionId, CancellationToken cancellationToken);
    }
}

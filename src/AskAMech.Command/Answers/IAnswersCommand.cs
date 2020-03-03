using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AskAMech.Domain;
using AskAMech.Domain.Models;

namespace AskAMech.Command.Answers
{
    public interface IAnswersCommand
    {
        Task<List<Answer>> GetAnswersByQuestionId(int questionId, CancellationToken cancellationToken);
        Task AnswerQuestion(Answer answer, CancellationToken cancellationToken);
        Task AcceptAnswer(int answerId, CancellationToken cancellationToken);
        IQueryable<AnswersListViewModel> GetQuestionsWithAnswers();
        Task<Answer> GetAcceptedAnswerByQuestionId(int questionId, CancellationToken cancellationToken);
    }
}

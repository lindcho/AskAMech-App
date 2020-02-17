using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AskAMech.Domain.Models;

namespace AskAMech.Data.DbGateways.Answers
{
    public interface IAnswerGateway
    {
        Task<List<Answer>> GetAllAnswers(CancellationToken cancellationToken);
        Task AddAnswer(Answer answer, CancellationToken cancellationToken);
    }
}

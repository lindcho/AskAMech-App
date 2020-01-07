using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AskAMech.Domain.Models;

namespace AskAMech.Command.Gateways
{
    public interface IQuestionGateway
    {
        Task<List<Question>> GetAllQuestions(CancellationToken cancellationToken);
        Task Add(Question question, CancellationToken cancellationToken);
        Task<Question> Update(Question question, CancellationToken cancellationToken);
        Task<Question> GetQuestion(int? id);

    }
}

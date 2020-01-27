using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AskAMech.Domain.Models;

namespace AskAMech.Command.Questions
{
    public interface IQuestionCommands
    {
        Task<List<Question>> GetAllQuestions(CancellationToken cancellationToken);
        Task AskQuestion(Question question, CancellationToken cancellationToken);

    }
}

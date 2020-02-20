using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AskAMech.Domain;
using AskAMech.Domain.Models;

namespace AskAMech.Command.Questions
{
    public interface IQuestionCommands
    {
        Task<List<Question>> GetAllQuestions(CancellationToken cancellationToken);
        Task AskQuestion(Question question, CancellationToken cancellationToken);
        Task<Question> UpdateQuestion(Question question, CancellationToken cancellationToken);
        Task<Question> GetQuestion(int? id);
        bool CanUserEditQuestion(int? id);
        Task<List<Question>> GetUserQuestions();
        int GetAnswersCount(int questionId);
        IQueryable<QuestionsListGroupViewModel> GetQuestionList();
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AskAMech.Domain.Models;

namespace AskAMech.Command.Answers
{
    public interface IAnswersCommand
    {
        Task<List<Answer>> GetAnswersByQuestionId( int questionId,CancellationToken cancellationToken);
    }
}

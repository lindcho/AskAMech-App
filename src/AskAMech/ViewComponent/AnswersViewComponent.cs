using System.Threading;
using System.Threading.Tasks;
using AskAMech.Command.Answers;
using Microsoft.AspNetCore.Mvc;

namespace AskAMech.ViewComponent
{
    public class AnswersViewComponent : Microsoft.AspNetCore.Mvc.ViewComponent
    {
        public readonly IAnswersCommand _answersCommand;

        public AnswersViewComponent(IAnswersCommand answersCommand)
        {
            _answersCommand = answersCommand;
        }

        public async Task<IViewComponentResult> InvokeAsync(int questionId)
        {
            var answers = await _answersCommand.GetAnswersByQuestionId(questionId, new CancellationToken());
            return View(answers);
        }
    }
}

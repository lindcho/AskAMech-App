using System.Linq;
using System.Threading;
using System.Web.Mvc;
using AskAMech.Command.Answers;
using Microsoft.AspNetCore.Mvc;
using Controller = Microsoft.AspNetCore.Mvc.Controller;

namespace AskAMech.Controllers
{
    public class AnswersController : Controller
    {
        public readonly IAnswersCommand _answersCommand;

        public AnswersController(IAnswersCommand answersCommand)
        {
            _answersCommand = answersCommand;
        }

        [ChildActionOnly]
        public IActionResult Index(int id)
        {
            var answers = _answersCommand.GetAnswersByQuestionId(id, new CancellationToken());
            return PartialView("_Answers",answers.Result.ToList());
        }
    }
}
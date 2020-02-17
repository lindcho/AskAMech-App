using System.Threading;
using System.Threading.Tasks;
using AskAMech.Command.Answers;
using AskAMech.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AskAMech.Controllers
{
    public class AnswersController : Controller
    {
        public readonly IAnswersCommand _answersCommand;

        public AnswersController(IAnswersCommand answersCommand)
        {
            _answersCommand = answersCommand;
        }

        [Authorize]
        [HttpGet]
        public IActionResult Add(int questionId)
        {
            var answer = new Answer
            {
                QuestionId = questionId
            };
            return View(answer);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(Answer answer)
        {
            if (!ModelState.IsValid) return View(answer);
            await _answersCommand.AddAnswer(answer, new CancellationToken());
            return RedirectToAction("Details", "Questions", new { id = answer.QuestionId });
        }
    }
}
using System.Threading;
using System.Threading.Tasks;
using AskAMech.Command.Answers;
using AskAMech.Command.Questions;
using AskAMech.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AskAMech.Controllers
{
    public class AnswersController : BaseController
    {
        public readonly IAnswersCommand _answersCommand;
        public readonly IQuestionCommands _questionCommands;

        public AnswersController(IAnswersCommand answersCommand, IQuestionCommands questionCommands)
        {
            _answersCommand = answersCommand;
            _questionCommands = questionCommands;
        }

        [Authorize]
        [HttpGet]
        public IActionResult AnswerQuestion(int questionId)
        {
            var question = _questionCommands.GetQuestion(questionId).Result;
            var answer = new Answer
            {
                QuestionId = questionId,
                Question = question
            };
            return View(answer);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AnswerQuestion([Bind("AnswerId,Description,QuestionId")] Answer answer)
        {
            if (!ModelState.IsValid) return View(answer);
            await _answersCommand.AnswerQuestion(answer, new CancellationToken());
            Success("<b>Answer</b> was successfully posted for the question.", true);
            return RedirectToAction("Details", "Questions", new { id = answer.QuestionId });
        }

        [HttpGet]
        public async Task<IActionResult> AcceptAnswer(int answerId, int questionId)
        {
            await _answersCommand.AcceptAnswer(answerId, new CancellationToken());
            return RedirectToAction("Details", "Questions", new { id = questionId });
        }
    }
}
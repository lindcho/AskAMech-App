using System;
using System.Threading;
using System.Threading.Tasks;
using AskAMech.Command.Answers;
using AskAMech.Command.Questions;
using AskAMech.Command.Services;
using AskAMech.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AskAMech.Controllers
{
    public class AnswersController : BaseController
    {
        public readonly IAnswersCommand _answersCommand;
        public readonly IQuestionCommands _questionCommands;
        private readonly IRequestUserProvider _requestUserProvider;

        public AnswersController(IAnswersCommand answersCommand, IQuestionCommands questionCommands, IRequestUserProvider requestUserProvider)
        {
            _answersCommand = answersCommand;
            _questionCommands = questionCommands;
            _requestUserProvider = requestUserProvider;
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
            Success("Your <b>answer</b> was successfully posted for the question.", true);
            return RedirectToAction("Details", "Questions", new { id = answer.QuestionId });
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddAnswer(int id, string comment)
        {
            try
            {

                if (String.IsNullOrEmpty(comment))
                {
                    return Json(false);
                }
                var user = await _requestUserProvider.GetCurrentUserAsync();
                var commentModel = new Answer()
                {
                    Description = comment,
                    Date = DateTime.Now,
                    AuthorId = user.Id,
                    QuestionId = id,

                };
                await _answersCommand.AnswerQuestion(commentModel, new CancellationToken());
                return Json(true);

            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                return Json(false);
            }
        }

        [HttpGet]
        public async Task<IActionResult> AcceptAnswer(int answerId, int questionId)
        {
            await _answersCommand.AcceptAnswer(answerId, new CancellationToken());
            return RedirectToAction("Details", "Questions", new { id = questionId });
        }
    }
}
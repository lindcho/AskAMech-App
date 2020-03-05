using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AskAMech.Command.Answers;
using AskAMech.Command.Questions;
using Microsoft.AspNetCore.Mvc;

namespace AskAMech.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IQuestionCommands _questionCommands;
        private readonly IAnswersCommand _answersCommand;

        public ProfileController(IQuestionCommands questionCommands, IAnswersCommand answersCommand)
        {
            _questionCommands = questionCommands;
            _answersCommand = answersCommand;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string userId)
        {
            var userQuestions =await _questionCommands.GetUserQuestions(userId);
            ViewData["Questions"] = userQuestions ?? throw new Exception("You don't have any questions yet");

            var questionModel = _answersCommand.GetQuestionsWithAnswers(userId);
            ViewData["Answers"] = questionModel;
            return View();
        }
    }
}
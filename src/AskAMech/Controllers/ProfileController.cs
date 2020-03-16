using System.Threading.Tasks;
using AskAMech.Command.Answers;
using AskAMech.Command.Questions;
using AskAMech.Command.Services;
using AskAMech.Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AskAMech.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IQuestionCommands _questionCommands;
        private readonly IAnswersCommand _answersCommand;
        private readonly IRequestUserProvider _requestUserProvider;

        public ProfileController(IQuestionCommands questionCommands, IAnswersCommand answersCommand, IRequestUserProvider requestUserProvider)
        {
            _questionCommands = questionCommands;
            _answersCommand = answersCommand;
            _requestUserProvider = requestUserProvider;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string userId)
        {
            var currentUserId = _requestUserProvider.GetUserId();
            ViewBag.UserId = currentUserId;

            var questions = await _questionCommands.GetUserQuestions(userId);
            var questionAnswers = _answersCommand.GetQuestionsWithAnswers(userId);
            var user = await _requestUserProvider.GetUserByUserId(userId);
            var us = _requestUserProvider.GetCurrentUserAsync();

            var viewModel = new ProfileDetailsViewModel
            {
                AskedQuestions = questions,
                QuestionAnswers = questionAnswers,
                User = user
            };
            return View(viewModel);
        }
    }
}
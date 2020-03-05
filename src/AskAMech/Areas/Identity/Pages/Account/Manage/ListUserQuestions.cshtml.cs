using System;
using System.Threading.Tasks;
using AskAMech.Command.Answers;
using AskAMech.Command.Questions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AskAMech.Areas.Identity.Pages.Account.Manage
{
    public class ListUserQuestionsModel : PageModel
    {

        private readonly IQuestionCommands _questionCommands;
        private readonly IAnswersCommand _answersCommand;

        public ListUserQuestionsModel(IQuestionCommands questionCommands, IAnswersCommand answersCommand)
        {
            _questionCommands = questionCommands;
            _answersCommand = answersCommand;
        }

        public async Task<IActionResult> OnGet(string userId)
        {
            var questions = await _questionCommands.GetUserQuestions(userId);
            ViewData["Questions"] = questions ?? throw new Exception("You don't have any questions yet");

            var questionModel = _answersCommand.GetQuestionsWithAnswers(userId);
            ViewData["Answers"] = questionModel;
            return Page();
        }
    }
}
using System;
using System.Threading;
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
        private readonly IAnswersCommand __answersCommand;

        public ListUserQuestionsModel(IQuestionCommands questionCommands, IAnswersCommand answersCommand)
        {
            _questionCommands = questionCommands;
            __answersCommand = answersCommand;
        }
        
        public async Task<IActionResult> OnGet(int id)
        {
            var questions = await _questionCommands.GetUserQuestions();
            ViewData["Questions"] = questions ?? throw new Exception("You don't have any questions yet");
            
            ViewData["Answers"] = await __answersCommand.GetCurrentUserAnswers();
            return Page();
        }
    }
}
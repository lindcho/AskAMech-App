using System;
using System.Threading.Tasks;
using AskAMech.Command.Questions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AskAMech.Areas.Identity.Pages.Account.Manage
{
    public class ListUserQuestionsModel : PageModel
    {

        private readonly IQuestionCommands _questionCommands;

        public ListUserQuestionsModel(IQuestionCommands questionCommands)
        {
            _questionCommands = questionCommands;
        }
        
        public async Task<IActionResult> OnGet()
        {
            var questions = await _questionCommands.GetUserQuestions();
            ViewData["Questions"] = questions ?? throw new Exception("You don't have any questions yet");
            return Page();
        }
    }
}
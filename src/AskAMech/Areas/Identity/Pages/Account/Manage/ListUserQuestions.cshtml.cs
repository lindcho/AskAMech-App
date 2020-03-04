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
        
        public async Task<IActionResult> OnGet()
        {
            var questions = await _questionCommands.GetUserQuestions();
            ViewData["Questions"] = questions ?? throw new Exception("You don't have any questions yet");

            var answerModel = _answersCommand.GetQuestionsWithAnswers();
            ViewData["Answers"] = answerModel;
            return Page();
        }
    }
}
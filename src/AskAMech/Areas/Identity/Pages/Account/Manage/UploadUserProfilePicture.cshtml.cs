using System.Threading.Tasks;
using AskAMech.Command.Questions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AskAMech.Areas.Identity.Pages.Account.Manage
{
    public partial class UploadUserProfilePictureModel : PageModel
    {
        private readonly IQuestionCommands _questionCommands;

        public UploadUserProfilePictureModel(IQuestionCommands questionCommands)
        {
            _questionCommands = questionCommands;
        }

        [BindProperty]
        public InputModel Input { get; set; }
        public class InputModel
        {
            public byte[] UserPhoto { get; set; }
        }

        public IActionResult OnGet()
        {
            return Page();
        }
        
        public async Task<ActionResult> OnPost(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                await _questionCommands.UploadImage(file);
            }
            return Redirect("/Identity/Account/Manage");
        }
    }
}
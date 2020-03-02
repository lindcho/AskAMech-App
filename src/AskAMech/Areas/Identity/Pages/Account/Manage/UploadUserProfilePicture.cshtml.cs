using System.Threading.Tasks;
using AskAMech.Command.Questions;
using AskAMech.Controllers;
using AskAMech.Helpers;
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
        [TempData]
        public string StatusMessage { get; set; }

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
            if (file == null || file.Length == 0)
            {
                ModelState.AddModelError("", "Uploaded file is empty or null.");
                return Page();
            }

            var isImage = file.IsImage();

            if (!isImage)
            {
                ModelState.AddModelError("", "This photo extension is not allowed!");
                return Page();
            }

            if (!ModelState.IsValid)
                return Redirect("/Identity/Account/Manage");

            if (file.Length > 0)
            {
                await _questionCommands.UploadImage(file);
                StatusMessage = "Your profile picture has been uploaded successfully";
            }
            return Redirect("/Identity/Account/Manage");
        }
    }
}
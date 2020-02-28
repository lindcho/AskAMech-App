using AskAMech.Command.Questions;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AskAMech.Areas.Identity.Pages.Account.Manage
{
    public class UploadUserProfilePictureModel : PageModel
    {
        private readonly IQuestionCommands _questionCommands;

        public UploadUserProfilePictureModel(IQuestionCommands questionCommands)
        {
            _questionCommands = questionCommands;
        }
        //public async Task<IActionResult> OnGet(IFormFile file)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (file != null && file.Length > 0)
        //        {
        //            var userPhot = await _questionCommands.UploadImage(file);
        //            ViewData["UserProfilePicture"] = userPhoto;
        //        }
        //    }
        //    return Page();
        //}
    }
}
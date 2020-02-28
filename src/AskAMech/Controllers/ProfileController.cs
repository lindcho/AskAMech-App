using System.Threading.Tasks;
using AskAMech.Command.Questions;
using AskAMech.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AskAMech.Controllers
{
    public class ProfileController : BaseController
    {
        private readonly IQuestionCommands _questionCommands;

        public ProfileController(IQuestionCommands questionCommands)
        {
            _questionCommands = questionCommands;
        }

        [HttpGet]
        public ActionResult ProfilePicture()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ProfilePicture(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                ModelState.AddModelError("", "Uploaded file is empty or null.");
                return View();
            }

            var isImage = file.IsImage();

            if (!isImage)
            {
                ModelState.AddModelError("", "This photo extension is not allowed!");
                return View();
            }
                 
            if (!ModelState.IsValid)
                return Redirect("/Identity/Account/Manage");
            if (file.Length > 0)
            {
                await _questionCommands.UploadImage(file);
                Success(string.Format("<b>{0}</b> was successfully added to the database.", "Image"), true);
            }


            return Redirect("/Identity/Account/Manage");
        }
    }

  
}

using System.Threading.Tasks;
using AskAMech.Command.Questions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AskAMech.Controllers
{
    public class ProfileController : Controller
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
            if (ModelState.IsValid)
            {
                  if (file != null && file.Length > 0)
                  {
                        await _questionCommands.UploadImage(file);
                  }
            }

            return Redirect("/Identity/Account/Manage");
        }
    }
}

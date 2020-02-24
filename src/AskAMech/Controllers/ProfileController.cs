using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Threading.Tasks;
using AskAMech.Command.Services;
using AskAMech.Domain.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;

namespace AskAMech.Controllers
{
    public class ProfileController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IRequestUserProvider _requestUserProvider;
        private IHostingEnvironment _environment;
        private readonly IFileProvider fileProvider;

        public ProfileController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, IRequestUserProvider requestUserProvider, IHostingEnvironment environment, IFileProvider fileProvider)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _requestUserProvider = requestUserProvider;
            _environment = environment;
            this.fileProvider = fileProvider;
        }

        public async Task<ActionResult> Index()
        {
            var userId = _requestUserProvider.GetUserId();
            var user = await _userManager.FindByIdAsync(userId);
            return View(user);
        }

        // GET: /Manage/ProfilePicture
        public ActionResult ProfilePicture()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ProfilePicture(EmailForm model)
        {
            var userId = _requestUserProvider.GetUserId();
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (model == null ||
                model.File == null || model.File.Length == 0)
                return Content("file not selected");

            var path = Path.Combine(
                Directory.GetCurrentDirectory(), "wwwroot",
                model.File.GetFilename());

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await model.File.CopyToAsync(stream);
                user.PictureUrl = stream.ToString();
            }


            var updateProfileResult = await _userManager.UpdateAsync(user);
            if (!updateProfileResult.Succeeded)
            {
                throw new InvalidOperationException($"Unexpected error ocurred updating the profile for user with ID '{user.Id}'");
            }


            return View();
        }

        public class EmailForm
        {
            /// <summary>
            /// Gets or Sets the FileName
            /// </summary>
            [Required(ErrorMessage = "FileName is required")]
            public string FileName { get; set; }

            [Required(ErrorMessage = "File is required")]
            [DataType(DataType.Upload)]
            [FromForm(Name = "File")]
            public IFormFile File { get; set; }
        }
    }
}
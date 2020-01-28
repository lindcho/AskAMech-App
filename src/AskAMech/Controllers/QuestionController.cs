using System.Threading;
using System.Threading.Tasks;
using AskAMech.Command.Questions;
using AskAMech.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AskAMech.Controllers
{
    public class QuestionController : Controller
    {
        private readonly IQuestionCommands _questionCommands;

        public QuestionController(IQuestionCommands questionCommands)
        {
            _questionCommands = questionCommands;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var allQuestions = await _questionCommands.GetAllQuestions(new CancellationToken());
            foreach (var question in allQuestions)
            {
                question.Author.FullName = question.Author.FullName ?? question.Author.UserName;
            }
            return View(allQuestions);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> ListUserQuestions()
        {
            return View(await _questionCommands.GetUserQuestions());
        }

        // GET: Questions/Add
        [Authorize]
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        // POST: Questions/Add
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add([Bind("Id,Title,Description")] Question question)
        {
            if (!ModelState.IsValid) return View(question);
            await _questionCommands.AskQuestion(question, new CancellationToken());
            return RedirectToAction(nameof(List));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            var question = await _questionCommands.GetQuestion(id);
            await _questionCommands.GetQuestion(id);
            return View(question);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("Id,Title,Description")] Question question)
        {
            if (!ModelState.IsValid) return View(question);
            await _questionCommands.UpdateQuestion(question, new CancellationToken());
            return RedirectToAction(nameof(List));
        }

        [HttpGet]
        public async Task<IActionResult> ViewQuestion(int id)
        {
            ViewBag.canEdit = _questionCommands.CanUserEditQuestion(id);
            var questionWithFullName = await _questionCommands.GetQuestion(id);
            questionWithFullName.Author.FullName = questionWithFullName.Author.FullName ?? questionWithFullName.Author.UserName;

            return View(questionWithFullName);
        }
    }
}
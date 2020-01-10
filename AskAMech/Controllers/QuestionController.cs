using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using AskAMech.Command.Gateways;
using AskAMech.Command.Services;
using AskAMech.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AskAMech.Controllers
{
    public class QuestionController : Controller
    {
        private readonly IQuestionGateway _questionGateway;

        public QuestionController(IQuestionGateway questionGateway)
        {
            _questionGateway = questionGateway;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var questionsWithFullName = await _questionGateway.GetAllQuestions(new CancellationToken());
            foreach (var question in questionsWithFullName)
            {
                    question.Author.FullName = question.Author.FullName ?? question.Author.UserName;
            }
            return View(questionsWithFullName);
        }
         
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> ListUserQuestions()
        {
            return View(await _questionGateway.GetUserQuestions());
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
            await _questionGateway.Add(question, new CancellationToken());
            return RedirectToAction(nameof(List));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var question = await _questionGateway.GetQuestion(id);
            if (question == null)
            {
                return NotFound();
            }
            return View(question);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("Id,Title,Description")] Question question)
        {
            if (!ModelState.IsValid) return View(question);
            await _questionGateway.Update(question, new CancellationToken());
            return RedirectToAction(nameof(ListUserQuestions));
        }

        [HttpGet]
        public async Task<IActionResult> ViewQuestion(int id)
        {
            ViewBag.canEdit = _questionGateway.CanUserEditQuestion(id);
            var questionWithFullName = await _questionGateway.GetQuestion(id);
            questionWithFullName.Author.FullName = questionWithFullName.Author.FullName ?? questionWithFullName.Author.UserName;

            return View(questionWithFullName);
        }
    }
}
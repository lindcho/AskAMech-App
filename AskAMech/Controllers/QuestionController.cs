using System.Threading;
using System.Threading.Tasks;
using AskAMech.Command.Gateways;
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
            return View(await _questionGateway.GetAllQuestions(new CancellationToken()));
        }

        // GET: Questions/Add
        [Authorize]
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
        public IActionResult Add([Bind("Id,Title,Description")] Question question)
        {
            if (!ModelState.IsValid) return View(question);
            _questionGateway.Add(question, new CancellationToken());
            return RedirectToAction(nameof(List));
        }

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
        public async Task<IActionResult> Edit([Bind("Id,Title,Description,DateCreated,LastModified,AuthorId")] Question question)
        {
            if (!ModelState.IsValid) return View(question);
            await _questionGateway.Update(question, new CancellationToken());
            return RedirectToAction(nameof(List));
        }
    }
}
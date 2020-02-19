using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AskAMech.Command.Answers;
using AskAMech.Command.Questions;
using AskAMech.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace AskAMech.Controllers
{
    public class QuestionsController : Controller
    {
        private readonly IQuestionCommands _questionCommands;
        private readonly IAnswersCommand __answersCommand;


        public QuestionsController(IQuestionCommands questionCommands, IAnswersCommand answersCommand)
        {
            _questionCommands = questionCommands;
            __answersCommand = answersCommand;
        }

        [HttpGet]

        public async Task<IActionResult> List(int? pageNumber, string searchString)
        {
            var allQuestions = await _questionCommands.GetAllQuestions(new CancellationToken());
            foreach (var question in allQuestions)
            {
                question.Author.FullName = question.Author.FullName ?? question.Author.UserName;
            }

            if (!string.IsNullOrEmpty(searchString))
            {
                return View(allQuestions.Where(q => q.Title.Contains(searchString, System.StringComparison.OrdinalIgnoreCase)).ToList().ToPagedList(pageNumber ?? 1, 4));
            }
            return View(allQuestions.ToPagedList(pageNumber ?? 1, 4));
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
        public async Task<IActionResult> Details(int id)
        {
            ViewBag.canEdit = _questionCommands.CanUserEditQuestion(id);

            var questionModel = await _questionCommands.GetQuestion(id);
            questionModel.Author.FullName = questionModel.Author.FullName ?? questionModel.Author.UserName;
            questionModel.Answers = await __answersCommand.GetAnswersByQuestionId(id, new CancellationToken());
            ViewBag.answerCount = _questionCommands.GetAnswersCount(id);
            return View(questionModel);
        }
    }
}
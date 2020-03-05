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
    public class QuestionsController : BaseController
    {
        private readonly IQuestionCommands _questionCommands;
        private readonly IAnswersCommand _answersCommand;

        public QuestionsController(IQuestionCommands questionCommands, IAnswersCommand answersCommand)
        {
            _questionCommands = questionCommands;
            _answersCommand = answersCommand;
        }

        //[Authorize]
        [HttpGet]
        public async Task<IActionResult> ListUserQuestions(string userId)
        {
            return View(await _questionCommands.GetUserQuestions(userId));
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
            Success($"<b>{question.Title}</b> was successfully posted to the forum.", true);
            return RedirectToAction(nameof(Index));
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
            Success($"<b>{question.Title}</b> was successfully updated.", true);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            ViewBag.isAuthor = _questionCommands.CanUserEditQuestion(id);

            var questionModel = await _questionCommands.GetQuestion(id);
            questionModel.Author.FullName = questionModel.Author.FullName ?? questionModel.Author.UserName;
            questionModel.Answers = await _answersCommand.GetAnswersByQuestionId(id, new CancellationToken());

            ViewBag.AcceptedAnswer = await _answersCommand.GetAcceptedAnswerByQuestionId(id, new CancellationToken());
            ViewBag.answerCount = _questionCommands.GetAnswersCount(id);
            return View(questionModel);
        }

        public IActionResult Index(int? pageNumber, string searchString)
        {
            var allQuestions = _questionCommands.GetQuestionList().ToList();

            if (string.IsNullOrEmpty(searchString)) return View(allQuestions.ToPagedList(pageNumber ?? 1, 10));
            ViewBag.Searching = true;
            return View(allQuestions.Where(q => q.Title.Contains(searchString, System.StringComparison.OrdinalIgnoreCase)).ToList().ToPagedList(pageNumber ?? 1, 10));

        }
    }
}
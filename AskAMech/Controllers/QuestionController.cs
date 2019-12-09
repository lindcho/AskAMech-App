using System.Linq;
using AskAMech.Command.Gateways;
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
        public IActionResult Index()
        {
            return View(_questionGateway.GetAllQuestions().ToList());
        }
    }
}
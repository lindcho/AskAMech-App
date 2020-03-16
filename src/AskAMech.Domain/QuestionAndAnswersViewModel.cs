using System.Collections.Generic;
using AskAMech.Domain.Models;

namespace AskAMech.Domain
{
    public class QuestionAndAnswersViewModel
    {
        public Question Question { get; set; }
        public List<Answer> QuestionAnswers { get; set; }
    }
}

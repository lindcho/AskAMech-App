using System;

namespace AskAMech.Domain
{
   public class AnswersListViewModel
    {
        public string AnswerDescription { get; set; }
        public int QuestionId { get; set; }
        public DateTime DateAnswered { get; set; }
    }
}

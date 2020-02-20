using System;
using System.ComponentModel.DataAnnotations;

namespace AskAMech.Domain
{
    public class QuestionsListGroupViewModel
    {
        public int QuestionId { get; set; }
        public string Title { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateCreated { get; set; }
        public string AuthorName { get; set; }
        public int? AcceptedAnswerId { get; set; }
        public int AnswerCount { get; set; }

    }
}

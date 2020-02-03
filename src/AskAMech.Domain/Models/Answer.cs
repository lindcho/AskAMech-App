using System;
using System.ComponentModel.DataAnnotations;

namespace AskAMech.Domain.Models
{
    public class Answer
    {
        [Key]
        public int AnswerId { get; set; }
        public int QuestionId { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}

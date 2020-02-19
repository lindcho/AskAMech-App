using System;
using System.ComponentModel.DataAnnotations;

namespace AskAMech.Domain.Models
{
    public class Answer
    {
        [Key]
        public int AnswerId { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string AuthorId { get; set; }
        public virtual ApplicationUser Author { get; set; }
        public int QuestionId { get; set; }
        public virtual Question Question { get; set; }
    }
}

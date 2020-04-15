using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AskAMech.Domain.Models
{
    public class Answer
    {
        [Key]
        public int AnswerId { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public DateTime Date { get; set; }
        [ForeignKey("Author")]
        public string AuthorId { get; set; }
        public virtual ApplicationUser Author { get; set; }
        [Required]
        public int QuestionId { get; set; }
        public virtual Question Question { get; set; }
    }
}

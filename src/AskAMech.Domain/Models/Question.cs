using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AskAMech.Domain.Models
{
    public class Question
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true)]
        public DateTime DateCreated { get; set; }
        public DateTime LastModified { get; set; }
        public int? AcceptedAnswerId { get; set; }
        [ForeignKey("Author")]
        public string AuthorId { get; set; }
        public virtual ApplicationUser Author { get; set; }
        public ICollection<Answer> Answers { get; set; }
    }
}

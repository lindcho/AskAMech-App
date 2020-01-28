using System;
using System.ComponentModel.DataAnnotations;

namespace AskAMech.Domain.Models
{
    public class Question
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime LastModified { get; set; }

        //EF relationships should pick this relationship between Question and ApplicationUser tables     
        public string AuthorId { get; set; }
        public virtual ApplicationUser Author { get; set; }
    }
}

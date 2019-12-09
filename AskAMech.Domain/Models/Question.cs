using System;
using System.Collections.Generic;
using System.Text;

namespace AskAMech.Domain.Models
{
   public class Question
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string AuthorId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime LastModified { get; set; }
    }
}

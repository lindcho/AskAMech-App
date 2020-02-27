using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace AskAMech.Domain.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
        public byte[] UserPhoto { get; set; }

        public ICollection<Question> Questions { get; set; }
        public ICollection<Answer> Answers { get; set; }
       
    }
}

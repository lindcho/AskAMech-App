using System;
using AskAMech.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AskAMech.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            SetDefaultUserQuestions();
        }

        //ToDo to extract method to a new class
        private void SetDefaultUserQuestions()
        {
            IList<ApplicationUser> defaultUser = new List<ApplicationUser>();
            {
                if (Users.Any() || Questions.Any()) return;
                defaultUser.Add(new ApplicationUser
                {
                    Email = "askAmech@gmail.com",
                    EmailConfirmed = true,
                    UserName = "askAmech@gmail.com",
                    Id = "1f7999f-28be-4322-bc69-612ef8bbbb5c",
                    FullName = "Khanyisile",
                    PhoneNumber = "07835645445",
                    PhoneNumberConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    LockoutEnabled = true,
                    NormalizedEmail = "ASKAMECH@GMAIL.COM",
                    NormalizedUserName = "ASKAMECH@GMAIL.COM",
                    // Password = "@Password01";
                    PasswordHash = "AQAAAAEAACcQAAAAEKGJW6gAMtcOK+HH2phjyFSosZjyexbheSbFtgc6IYtspAcTAmPe9MwjitV7xe8gLQ==",
                    Questions = new[]

                    {
                        new Question
                        {
                            Title = "where to buy a strong tire", Description = "I need to know where can i buy a strong tire.",
                            DateCreated = DateTime.Now.Subtract(TimeSpan.FromMinutes(60))
                        },
                        new Question
                        {
                            Title = "How to fit a tire",
                            Description = "I just bought a tire but don;t know how to fit it in my car.",
                            DateCreated = DateTime.Now
                        },
                        new Question
                        {
                            Title = "How to fit brackes", Description = "I bought brackpads but don't know how to fix it.",
                            DateCreated = new DateTime(2017, 03, 09)
                        },
                        new Question
                        {
                            Title = "CV problem", Description = "my cra is making a noise i think i need to replace cv's.",
                            DateCreated = new DateTime(2018, 10, 09)
                        },
                        new Question
                        {
                            Title = "My car brakes are not working",
                            Description = "i bought this brakes two months ago but it seams like they are not original.",
                            DateCreated = new DateTime(2019, 06, 09)
                        }
                    }
                });

                Set<ApplicationUser>().AddRange(defaultUser);
                base.SaveChanges();
            }
        }

        public DbSet<Question> Questions { get; set; }

    }
}

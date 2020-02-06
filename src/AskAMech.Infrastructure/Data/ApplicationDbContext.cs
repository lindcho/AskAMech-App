using System;
using AskAMech.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AskAMech.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            SetDefaultUserQuestions();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Question>()
                .HasIndex(q => q.AcceptedAnswerId)
                .IsUnique();
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
                            Id = 1,
                            Title = "where to buy a strong tire", Description = "I need to know where can i buy a strong tire.",
                            DateCreated = DateTime.Now.Subtract(TimeSpan.FromMinutes(60)),
                            LastModified = DateTime.Now.Subtract(TimeSpan.FromMinutes(10))
                        },
                        new Question
                        {
                            Id = 2,
                            Title = "How to fit a tire",
                            Description = "I just bought a tire but don;t know how to fit it in my car.",
                            DateCreated = DateTime.Now.Subtract(TimeSpan.FromHours(3)),
                            LastModified = DateTime.Now.Subtract(TimeSpan.FromMinutes(2))
                        },
                        new Question
                        {
                            Id = 3,
                            Title = "How to fit brackes", Description = "I bought brackpads but don't know how to fix it.",
                            DateCreated = DateTime.Now.Subtract(TimeSpan.FromDays(60)),
                            LastModified = DateTime.Now.Subtract(TimeSpan.FromDays(30))
                        },
                        new Question
                        {
                            Id = 4,
                            Title = "CV problem", Description = "my cra is making a noise i think i need to replace cv's.",
                            DateCreated = DateTime.Now.Subtract(TimeSpan.FromDays(60)),
                            LastModified = DateTime.Now.Subtract(TimeSpan.FromMinutes(10))
                        },
                        new Question
                        {
                            Id = 5,
                            Title = "My car brakes are not working",
                            Description = "i bought this brakes two months ago but it seams like they are not original.",
                            DateCreated = DateTime.Now.Subtract(TimeSpan.FromDays(60)),
                            LastModified = DateTime.Now.Subtract(TimeSpan.FromMinutes(16))
                        }
                    },
                    Answers = new[]
                    {
                        new Answer
                        {
                            AuthorId = "1f7999f-28be-4322-bc69-612ef8bbbb5c",
                            QuestionId = 2,
                            Date = DateTime.Now.Subtract(TimeSpan.FromMinutes(16)),
                            Description = "fix it"
                        },
                        new Answer
                        {
                            AuthorId = "1f7999f-28be-4322-bc69-612ef8bbbb5c",
                            QuestionId = 3,
                            Date = DateTime.Now.Subtract(TimeSpan.FromMinutes(16)),
                            Description = "fix it now"
                        },
                        new Answer
                        {
                            AuthorId = "1f7999f-28be-4322-bc69-612ef8bbbb5c",
                            QuestionId = 4,
                            Date = DateTime.Now.Subtract(TimeSpan.FromMinutes(16)),
                            Description = "fix then test it"
                        },
                        new Answer
                        {
                            AuthorId = "36b2db51-238e-4224-ad1d-fe3077a5e4e4",
                            QuestionId = 1,
                            Date = DateTime.Now.Subtract(TimeSpan.FromMinutes(16)),
                            Description = "You can buy from Continental! but the price is just off the roof.. Very expensive"
                        },
                        new Answer
                        {
                            AuthorId = "ffc183dc-78c2-413d-96f8-2091600c0b69",
                            QuestionId = 1,
                            Date = DateTime.Now.Subtract(TimeSpan.FromMinutes(16)),
                            Description = "Super Tyres"
                        },
                        new Answer
                        {
                            AuthorId = "36b2db51-238e-4224-ad1d-fe3077a5e4e4",
                            QuestionId = 1,
                            Date = DateTime.Now.Subtract(TimeSpan.FromMinutes(16)),
                            Description = "Goodyear Tyres for new tires, but you can also try your new garage for second hand tyres"
                        }
                    }
                });

                Set<ApplicationUser>().AddRange(defaultUser);
                Set<Answer>().AddRange(Answers);
                base.SaveChanges();
            }
        }

        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }

    }
}

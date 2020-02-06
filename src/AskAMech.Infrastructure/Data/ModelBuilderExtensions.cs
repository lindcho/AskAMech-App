using System;
using AskAMech.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace AskAMech.Infrastructure.Data
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Email = "lindco@outlook.com",
                    EmailConfirmed = true,
                    UserName = "lindco@outlook.com",
                    Id = "1f7999f-28be-4322-bc69-612ef8bbbb5G",
                    FullName = "lindokuhle",
                    PhoneNumber = "0746009500",
                    PhoneNumberConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    LockoutEnabled = true,
                    NormalizedEmail = "LINDCHO@OUTLOOK.COM",
                    NormalizedUserName = "LINDCHO@OUTLOOK.COM",
                    // Password = "@Password01";
                    PasswordHash =
                        "AQAAAAEAACcQAAAAEKGJW6gAMtcOK+HH2phjyFSosZjyexbheSbFtgc6IYtspAcTAmPe9MwjitV7xe8gLQ=="
                },
                new ApplicationUser
                {
                    Email = "askamech@gmail.com",
                    EmailConfirmed = true,
                    UserName = "askamech@gmail.com",
                    Id = "1f7999f-28be-4322-bc69-612ef8bbbb5c",
                    FullName = "khanyisile",
                    PhoneNumber = "0746009500",
                    PhoneNumberConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    LockoutEnabled = true,
                    NormalizedEmail = "ASKAMECH@GMAIL.COM",
                    NormalizedUserName = "ASKAMECH@GMAIL.COM",
                    // Password = "@Password01";
                    PasswordHash =
                        "AQAAAAEAACcQAAAAEKGJW6gAMtcOK+HH2phjyFSosZjyexbheSbFtgc6IYtspAcTAmPe9MwjitV7xe8gLQ=="
                },
                new ApplicationUser
                {
                    Email = "sam@gmail.com",
                    EmailConfirmed = true,
                    UserName = "sam@gmail.com",
                    Id = "36b2db51-238e-4224-ad1d-fe3077a5e4e4",
                    FullName = "samkelo",
                    PhoneNumber = "0746009500",
                    PhoneNumberConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    LockoutEnabled = true,
                    NormalizedEmail = "SAM@GMAIL.COM",
                    NormalizedUserName = "SAM@GMAIL.COM",
                    // Password = "@Password01";
                    PasswordHash =
                        "AQAAAAEAACcQAAAAEKGJW6gAMtcOK+HH2phjyFSosZjyexbheSbFtgc6IYtspAcTAmPe9MwjitV7xe8gLQ=="
                },
                new ApplicationUser
                {
                    Email = "lindo1@ymail.com",
                    EmailConfirmed = true,
                    UserName = "lindo1@ymail.com",
                    Id = "ffc183dc-78c2-413d-96f8-2091600c0b69",
                    FullName = "samkelo",
                    PhoneNumber = "0746009500",
                    PhoneNumberConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    LockoutEnabled = true,
                    NormalizedEmail = "LINDO1@YMAIL.COM",
                    NormalizedUserName = "LINDO1@YMAIL.COM",
                    // Password = "@Password01";
                    PasswordHash =
                        "AQAAAAEAACcQAAAAEKGJW6gAMtcOK+HH2phjyFSosZjyexbheSbFtgc6IYtspAcTAmPe9MwjitV7xe8gLQ=="
                }
            );

            modelBuilder.Entity<Question>().HasData(
                new Question
                {
                    Id = 1,
                    AuthorId = "1f7999f-28be-4322-bc69-612ef8bbbb5c",
                    Title = "where to buy a strong tire",
                    Description = "I need to know where can i buy a strong tire.",
                    DateCreated = DateTime.Now.Subtract(TimeSpan.FromMinutes(60)),
                    LastModified = DateTime.Now.Subtract(TimeSpan.FromMinutes(10))
                },
                        new Question
                        {
                            Id = 2,
                            AuthorId = "1f7999f-28be-4322-bc69-612ef8bbbb5G",
                            Title = "How to fit a tire",
                            Description = "I just bought a tire but don;t know how to fit it in my car.",
                            DateCreated = DateTime.Now.Subtract(TimeSpan.FromHours(3)),
                            LastModified = DateTime.Now.Subtract(TimeSpan.FromMinutes(2))
                        },
                        new Question
                        {
                            Id = 3,
                            AuthorId = "36b2db51-238e-4224-ad1d-fe3077a5e4e4",
                            Title = "How to fit brackes",
                            Description = "I bought brackpads but don't know how to fix it.",
                            DateCreated = DateTime.Now.Subtract(TimeSpan.FromDays(60)),
                            LastModified = DateTime.Now.Subtract(TimeSpan.FromDays(30))
                        },
                        new Question
                        {
                            Id = 4,
                            AuthorId = "ffc183dc-78c2-413d-96f8-2091600c0b69",
                            Title = "CV problem",
                            Description = "my cra is making a noise i think i need to replace cv's.",
                            DateCreated = DateTime.Now.Subtract(TimeSpan.FromDays(60)),
                            LastModified = DateTime.Now.Subtract(TimeSpan.FromMinutes(10))
                        },
                        new Question
                        {
                            Id = 5,
                            AuthorId = "ffc183dc-78c2-413d-96f8-2091600c0b69",
                            Title = "My car brakes are not working",
                            Description = "i bought this brakes two months ago but it seams like they are not original.",
                            DateCreated = DateTime.Now.Subtract(TimeSpan.FromDays(60)),
                            LastModified = DateTime.Now.Subtract(TimeSpan.FromMinutes(16))
                        }
            );

            modelBuilder.Entity<Answer>().HasData(
                new Answer
                {
                    AnswerId = 1,
                    AuthorId = "1f7999f-28be-4322-bc69-612ef8bbbb5c",
                    QuestionId = 2,
                    Date = DateTime.Now.Subtract(TimeSpan.FromMinutes(16)),
                    Description = "fix it"
                },
                new Answer
                {
                    AnswerId = 2,
                    AuthorId = "1f7999f-28be-4322-bc69-612ef8bbbb5c",
                    QuestionId = 3,
                    Date = DateTime.Now.Subtract(TimeSpan.FromMinutes(16)),
                    Description = "fix it now"
                },
                new Answer
                {
                    AnswerId = 3,
                    AuthorId = "1f7999f-28be-4322-bc69-612ef8bbbb5c",
                    QuestionId = 4,
                    Date = DateTime.Now.Subtract(TimeSpan.FromMinutes(16)),
                    Description = "fix then test it"
                },
                new Answer
                {
                    AnswerId = 4,
                    AuthorId = "36b2db51-238e-4224-ad1d-fe3077a5e4e4",
                    QuestionId = 1,
                    Date = DateTime.Now.Subtract(TimeSpan.FromMinutes(16)),
                    Description =
                        "You can buy from Continental! but the price is just off the roof.. Very expensive"
                },
                new Answer
                {
                    AnswerId = 5,
                    AuthorId = "ffc183dc-78c2-413d-96f8-2091600c0b69",
                    QuestionId = 1,
                    Date = DateTime.Now.Subtract(TimeSpan.FromMinutes(16)),
                    Description = "Super Tyres"
                },
                new Answer
                {
                    AnswerId = 6,
                    AuthorId = "1f7999f-28be-4322-bc69-612ef8bbbb5G",
                    QuestionId = 1,
                    Date = DateTime.Now.Subtract(TimeSpan.FromMinutes(16)),
                    Description =
                        "Goodyear Tyres for new tires, but you can also try your new garage for second hand tyres"
                }
            );
        }
    }
}

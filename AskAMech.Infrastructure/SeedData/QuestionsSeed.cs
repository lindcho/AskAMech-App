using System;
using System.Collections.Generic;
using System.Linq;
using AskAMech.Domain.Models;

namespace AskAMech.Infrastructure.SeedData
{
    public class QuestionsSeed
    {
        public static List<Question> GenerateQuestions(int count)
        {
            return Enumerable.Range(1, count)
                .Select(i => new Question()
                {
                    Id = i,
                    Title = "Title" + i,
                    Abstract = "Abstract " + 1,
                    Description = $"Description {i}",
                    AuthorId = (000000 + i).ToString(),
                    DateCreated = new DateTime(2019, 11, 09),
                    LastModified = new DateTime(2019, 11, 09)
                })
                .ToList();
        }
    }
}

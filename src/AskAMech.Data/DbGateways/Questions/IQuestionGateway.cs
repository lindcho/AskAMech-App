﻿using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AskAMech.Domain;
using AskAMech.Domain.Models;

namespace AskAMech.Data.DbGateways.Questions
{
    public interface IQuestionGateway
    {
        Task<List<Question>> GetAll(CancellationToken cancellationToken);
        Task Add(Question question, CancellationToken cancellationToken);
        Task Update(Question question, CancellationToken cancellationToken);
        Task<Question> GetQuestion(int? id);
        Task<List<Question>> GetUserQuestions(string userId);
        IQueryable<QuestionsListGroupViewModel> GetQuestionList();
        Task UploadUserPhoto(ApplicationUser user);
    }
}

﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Threading;
using System.Threading.Tasks;
using AskAMech.Command.Services;
using AskAMech.Data.DbGateways.Answers;
using AskAMech.Data.DbGateways.Questions;
using AskAMech.Domain;
using AskAMech.Domain.Models;
using AskAMech.Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Remotion.Linq.Clauses;

namespace AskAMech.Command.Questions
{
    public class QuestionCommands : IQuestionCommands
    {
        private readonly IQuestionGateway _questionGateway;
        private readonly IAnswerGateway _answersGateway;
        private readonly IRequestUserProvider _requestUserProvider;
        private readonly ApplicationDbContext _context;

        public QuestionCommands(IQuestionGateway questionGateway, IRequestUserProvider requestUserProvider, IAnswerGateway answerGateway, ApplicationDbContext context)
        {
            _questionGateway = questionGateway;
            _requestUserProvider = requestUserProvider;
            _answersGateway = answerGateway;
            _context = context;
        }

        public Task<List<Question>> GetAllQuestions(CancellationToken cancellationToken)
        {
            return _questionGateway.GetAll(cancellationToken);
        }

        public async Task AskQuestion(Question question, CancellationToken cancellationToken)
        {
            var currentUserId = _requestUserProvider.GetUserId();
            if (string.IsNullOrEmpty(currentUserId))
            {
                throw new Exception("User not found");

            }

            var questions = await _questionGateway.GetAll(cancellationToken);
            if (questions.Any(t => t.Title == question.Title))
            {
                throw new Exception("Title already exist!");
            }

            try
            {
                question.DateCreated = DateTime.Now;
                question.LastModified = DateTime.Now;
                question.AuthorId = currentUserId;
                await _questionGateway.Add(question, cancellationToken);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<Question> UpdateQuestion(Question question, CancellationToken cancellationToken)
        {
            var currentUserId = _requestUserProvider.GetUserId();
            if (string.IsNullOrEmpty(currentUserId))
            {
                throw new Exception("User not found");
            }

            var questionDateCreated = GetQuestion(question.Id).Result.DateCreated;
            if (questionDateCreated == null)
            {
                throw new Exception("Date created not found");
            }
            try
            {
                question.LastModified = DateTime.Now;
                question.DateCreated = questionDateCreated;
                question.AuthorId = currentUserId;
                await _questionGateway.Update(question, cancellationToken);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return question;
        }

        public Task<Question> GetQuestion(int? id)
        {
            if (id == null)
            {
                throw new Exception("Id not found");
            }

            var question = _questionGateway.GetQuestion(id);
            if (question == null)
            {
                throw new Exception("Question Id not found");
            }
            return question;
        }

        public bool CanUserEditQuestion(int? id)
        {
            var currentUserId = _requestUserProvider.GetUserId();
            if (string.IsNullOrEmpty(currentUserId))
            {
                return false;
            }
            var question = _questionGateway.GetQuestion(id);
            if (question == null)
            {
                throw new Exception("User not found");
            }

            return currentUserId == question.Result.AuthorId;
        }

        public async Task<List<Question>> GetUserQuestions()
        {
            var currentUserId = _requestUserProvider.GetUserId();
            if (string.IsNullOrEmpty(currentUserId))
            {
                throw new Exception("User not found");
            }

            return await _questionGateway.GetUserQuestions(currentUserId);
        }

        public int GetAnswersCount(int questionId)
        {
            var count = _answersGateway.GetAllAnswers(new CancellationToken()).Result.Count(x => x.QuestionId == questionId);
            return count;
        }

        public IQueryable<QuestionsListGroupViewModel> GetQuestionList()
        {
            return _questionGateway.GetQuestionList();
        }
        public Task UploadImage(IFormFile file)
        {
            var user = new ApplicationUser();
            var currentUserId = _requestUserProvider.GetUserId();
            if (string.IsNullOrEmpty(currentUserId))
            {
                throw new Exception("User not found");
            }

            var currentUser = _context.Users.Find(currentUserId);
            user.UserPhoto = ConvertToBytes(file);

            if (currentUser != null)
            {
                currentUser.UserPhoto = user.UserPhoto;
            }

            return _questionGateway.UploadUserPhoto(currentUser);
        }

        private byte[] ConvertToBytes(IFormFile image)
        {
            byte[] imageBytes = null;
            BinaryReader reader = new BinaryReader(image.OpenReadStream());
            imageBytes = reader.ReadBytes((int)image.Length);
            return imageBytes;
        }
    }
}

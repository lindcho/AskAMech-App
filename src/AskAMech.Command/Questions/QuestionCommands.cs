﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AskAMech.Command.Services;
using AskAMech.Data.DbGateways.Answers;
using AskAMech.Data.DbGateways.Questions;
using AskAMech.Domain;
using AskAMech.Domain.Models;
using Microsoft.AspNetCore.Http;

namespace AskAMech.Command.Questions
{
    public class QuestionCommands : IQuestionCommands
    {
        private readonly IQuestionGateway _questionGateway;
        private readonly IAnswerGateway _answersGateway;
        private readonly IRequestUserProvider _requestUserProvider;

        public QuestionCommands(IQuestionGateway questionGateway, IRequestUserProvider requestUserProvider, IAnswerGateway answerGateway)
        {
            _questionGateway = questionGateway ?? throw new NullReferenceException("QuestionGateway value cannot be null");
            _requestUserProvider = requestUserProvider ?? throw new NullReferenceException("RequestUserProvider value cannot be null");
            _answersGateway = answerGateway ?? throw new NullReferenceException("AnswerGateway value cannot be null");
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
            var question = _questionGateway.GetQuestion(id).Result;
            if (question == null)
            {
                throw new Exception("User not found");
            }

            return currentUserId == question.AuthorId;
        }

        public async Task<List<Question>> GetUserQuestions(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new Exception("User not found");
            }

            return await _questionGateway.GetUserQuestions(userId);
        }

        public int GetAnswersCount(int questionId)
        {
            var count = _answersGateway.GetAllAnswers(new CancellationToken())
                .Result.Count(x => x.QuestionId == questionId);
            return count;
        }

        public IQueryable<QuestionsListGroupViewModel> GetQuestionList()
        {
            return _questionGateway.GetQuestionList();
        }
        public Task UploadImage(IFormFile file)
        {
            var currentUser = _requestUserProvider.GetCurrentUserAsync().Result;

            if (currentUser == null) throw new Exception("User not found");

            currentUser.UserPhoto = ConvertToBytes(file);

            return _questionGateway.UploadUserPhoto(currentUser);
        }

        private static byte[] ConvertToBytes(IFormFile image)
        {
            byte[] imageBytes = null;
            var reader = new BinaryReader(image.OpenReadStream());
            imageBytes = reader.ReadBytes((int)image.Length);
            return imageBytes;
        }
    }
}

﻿using System.Collections.Generic;
using System.Threading;
using AskAMech.Command.Questions;
using AskAMech.Command.Services;
using AskAMech.Data.DbGateways;
using AskAMech.Domain.Models;
using NSubstitute;
using NSubstitute.ReturnsExtensions;

namespace AskAMech.Command.Test.Builders.Questions
{
    public class AskQuestionCommandBuilder
    {
        private readonly IQuestionGateway _questionGateway;
        private readonly IRequestUserProvider _requestUserProvider;

        public AskQuestionCommandBuilder()
        {
            _questionGateway = Substitute.For<IQuestionGateway>();
            _requestUserProvider = Substitute.For<IRequestUserProvider>();
        }

        public QuestionCommands Build()
        {
            return new QuestionCommands(_questionGateway, _requestUserProvider);
        }

        public AskQuestionCommandBuilder WithInvalidUserId(string userId)
        {
            _requestUserProvider.GetUserId().Returns(userId);
            return this;
        }
        public AskQuestionCommandBuilder WithQuestionId(int questionId)
        {
            _questionGateway.GetQuestion(questionId).Result.ReturnsNull();
            return this;
        }
        public AskQuestionCommandBuilder WithExistingQuestionTitle(List<Question> question)
        {
            _questionGateway.GetAll(Arg.Any<CancellationToken>()).Returns(question);
            return this;
        }
    }
}

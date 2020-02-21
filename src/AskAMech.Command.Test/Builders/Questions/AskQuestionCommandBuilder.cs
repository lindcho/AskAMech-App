using System.Collections.Generic;
using System.Threading;
using AskAMech.Command.Questions;
using AskAMech.Command.Services;
using AskAMech.Data.DbGateways.Answers;
using AskAMech.Data.DbGateways.Questions;
using AskAMech.Domain.Models;
using NSubstitute;
using NSubstitute.ReturnsExtensions;

namespace AskAMech.Command.Test.Builders.Questions
{
    public class AskQuestionCommandBuilder
    {
        private readonly IQuestionGateway _questionGateway;
        private readonly IRequestUserProvider _requestUserProvider;
        private readonly IAnswerGateway _answerGateway;

        public AskQuestionCommandBuilder()
        {
            _questionGateway = Substitute.For<IQuestionGateway>();
            _requestUserProvider = Substitute.For<IRequestUserProvider>();
            _answerGateway = Substitute.For<IAnswerGateway>();
        }

        public QuestionCommands Build()
        {
            return new QuestionCommands(_questionGateway, _requestUserProvider, _answerGateway);
        }

        public AskQuestionCommandBuilder WithInvalidUserId(string userId)
        {
            _requestUserProvider.GetUserId().Returns(userId);
            return this;
        }
        public AskQuestionCommandBuilder WithValidUserId(string userId)
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
        public AskQuestionCommandBuilder WithQuestionCreated(Question question)
        {
            _questionGateway.Add(question, Arg.Any<CancellationToken>());
            return this;
        }
        public AskQuestionCommandBuilder WithNewUpdatedQuestiond(Question question)
        {
            _questionGateway.Update(question, Arg.Any<CancellationToken>());
            return this;
        }
        public AskQuestionCommandBuilder WithQuestionToUpdate(int questionId, Question question)
        {
            _questionGateway.GetQuestion(questionId).Returns(question);
            return this;
        }
    }
}

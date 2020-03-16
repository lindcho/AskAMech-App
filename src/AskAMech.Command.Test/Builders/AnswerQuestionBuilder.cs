using AskAMech.Command.Answers;
using AskAMech.Command.Services;
using AskAMech.Data.DbGateways.Answers;
using AskAMech.Data.DbGateways.Questions;
using AskAMech.Domain.Models;
using NSubstitute;

namespace AskAMech.Command.Test.Builders
{
    public class AnswerQuestionBuilder
    {
        private readonly IAnswerGateway _answerGateway;
        private readonly IQuestionGateway _questionGateway;
        private readonly IRequestUserProvider _requestUserProvider;

        public AnswerQuestionBuilder()
        {
            _answerGateway = Substitute.For<IAnswerGateway>();
            _questionGateway = Substitute.For<IQuestionGateway>();
            _requestUserProvider = Substitute.For<IRequestUserProvider>();
        }

        public AnswersCommand Build()
        {
            return new AnswersCommand(_answerGateway, _questionGateway, _requestUserProvider);
        }

        public AnswerQuestionBuilder WithInvalidUserId(string userid)
        {
            _requestUserProvider.GetUserId().Returns(userid);
            return this;
        }
        public AnswerQuestionBuilder WithQuestion(Question question)
        {
            _questionGateway.GetQuestion(question.Id).Returns(question);
            return this;
        }

        public AnswerQuestionBuilder WithGeneratedUserId()
        {
             _requestUserProvider.GetUserId().Returns("1f7999f-28be-4322-bc69-612ef8cccc5c");
             return this;
        }
    }
}

using AskAMech.Command.Answers;
using AskAMech.Command.Services;
using AskAMech.Data.DbGateways.Answers;
using AskAMech.Data.DbGateways.Questions;
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
            _requestUserProvider = Substitute.For<RequestUserProvider>();
        }

        public AnswersCommand Build()
        {
            return new AnswersCommand(_answerGateway, _questionGateway, _requestUserProvider);
        }


    }
}

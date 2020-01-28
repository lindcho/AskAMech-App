using System.Threading;
using AskAMech.Command.Questions;
using AskAMech.Command.Services;
using AskAMech.Data.DbGateways;
using AskAMech.Domain.Models;
using AskAMech.Infrastructure.Data;

namespace AskAmech.Commands.Test
{
    public class AskQuestionCommandBuilder
    {
        private readonly IQuestionGateway _questionGateway;
        private readonly IQuestionCommands _questionCommand;
        private readonly IRequestUserProvider _requestUserProvider;
        private readonly ApplicationDbContext _context;

        public AskQuestionCommandBuilder(IQuestionGateway questionGateway, IQuestionCommands questionCommand, IRequestUserProvider requestUserProvider, ApplicationDbContext contex)
        {
            _questionGateway = questionGateway;
            _questionCommand = questionCommand;
            _requestUserProvider = requestUserProvider;
            _context = contex;
        }

        public AskQuestionCommandBuilder Build()
        {
            return new AskQuestionCommandBuilder(
                _questionGateway,
                _questionCommand,
                _requestUserProvider,
                _context);
        }

        //public AskQuestionCommandBuilder WithNewlyCreatedQuestion(Question question)
        //{
        //    _questionGateway.Add(question, new CancellationToken());

        //}
    }

    
}

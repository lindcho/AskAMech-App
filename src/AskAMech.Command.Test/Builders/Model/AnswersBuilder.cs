using AskAMech.Domain.Models;
using PeanutButter.RandomGenerators;

namespace AskAMech.Command.Test.Builders.Model
{
    public class AnswersBuilder : GenericBuilder<AnswersBuilder, Answer>
    {
        public AnswersBuilder WithId(int value)
        {
            return WithProp(question => question.AnswerId = value);
        }
        public AnswersBuilder WithAuthorId(string value)
        {
            return WithProp(question => question.AuthorId = value);
        }

    }
}

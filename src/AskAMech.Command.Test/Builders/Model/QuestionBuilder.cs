using AskAMech.Domain.Models;
using PeanutButter.RandomGenerators;

namespace AskAMech.Command.Test.Builders.Model
{
    public class QuestionBuilder : GenericBuilder<QuestionBuilder, Question>
    {
        public QuestionBuilder WithTitle(string value)
        {
            return WithProp(question => question.Title = value);
        }
    }
}

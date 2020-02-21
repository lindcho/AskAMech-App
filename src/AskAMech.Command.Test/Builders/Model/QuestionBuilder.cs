using System;
using AskAMech.Domain.Models;
using PeanutButter.RandomGenerators;

namespace AskAMech.Command.Test.Builders.Model
{
    public class QuestionBuilder : GenericBuilder<QuestionBuilder, Question>
    {
        public QuestionBuilder WithId(int value)
        {
            return WithProp(question => question.Id = value);
        }
        public QuestionBuilder WithTitle(string value)
        {
            return WithProp(question => question.Title = value);
        }
        public QuestionBuilder WithDateCreated(DateTime value)
        {
            return WithProp(question => question.DateCreated = value);
        }
    }
}

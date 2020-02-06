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
        public QuestionBuilder WithAuthorId(string value)
        {
            return WithProp(question => question.AuthorId = value);
        }
        public QuestionBuilder WithTitle(string value)
        {
            return WithProp(question => question.Title = value);
        }
        public QuestionBuilder WithDescription(string value)
        {
            return WithProp(question => question.Description = value);
        }

        public QuestionBuilder WithDateCreated(DateTime value)
        {
            return WithProp(question => question.DateCreated = value);
        }

        public QuestionBuilder WithLastModified(DateTime value)
        {
            return WithProp(question => question.LastModified = value);
        }
    }
}

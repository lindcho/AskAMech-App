using AskAMech.Domain.Models;
using PeanutButter.RandomGenerators;

namespace AskAMech.Command.Test.Builders.Model
{
   public class ApplicationUserBuilder : GenericBuilder<ApplicationUserBuilder, ApplicationUser>
    {
        public ApplicationUserBuilder WithApplicationUserId(string value)
        {
            return WithProp(applicationUser => applicationUser.Id = value);
        }
    }
}

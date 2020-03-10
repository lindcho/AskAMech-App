using System;
using System.Threading.Tasks;
using AskAMech.Data.DbGateways.User;
using AskAMech.Domain.Models;

namespace AskAMech.Command.User
{
    public class UserCommand : IUserCommand
    {
        private readonly IUserGateway _userGateway;

        public UserCommand(IUserGateway userGateway)
        {
            _userGateway = userGateway;
        }

        public async Task<ApplicationUser> GetUserProfile(string userId)
        {
            if (userId == null)
            {
                throw new Exception("UserId not found");
            }


            var user = await _userGateway.GetUserProfile(userId);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            return user;
        }
    }
}

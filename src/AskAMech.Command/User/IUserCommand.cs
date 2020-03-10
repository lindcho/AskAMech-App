using System.Threading.Tasks;
using AskAMech.Domain.Models;

namespace AskAMech.Command.User
{
    public interface IUserCommand
    {
        Task<ApplicationUser> GetUserProfile(string userId);
    }
}

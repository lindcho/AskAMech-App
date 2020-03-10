using System.Threading.Tasks;
using AskAMech.Domain.Models;

namespace AskAMech.Data.DbGateways.User
{
    public interface IUserGateway
    {
        Task<ApplicationUser> GetUserProfile(string userId);
    }
}

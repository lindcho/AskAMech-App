using System.Threading.Tasks;
using AskAMech.Domain.Models;

namespace AskAMech.Command.Services
{
    public interface IRequestUserProvider
    {
        string GetUserId();
        Task<ApplicationUser> GetCurrentUserAsync();
        Task<ApplicationUser> GetUserByUserId(string userId);
    }
}

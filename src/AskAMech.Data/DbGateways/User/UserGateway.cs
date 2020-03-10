using System.Threading.Tasks;
using AskAMech.Domain.Models;
using AskAMech.Infrastructure.Data;

namespace AskAMech.Data.DbGateways.User
{
    public class UserGateway : IUserGateway
    {
        private readonly ApplicationDbContext _context;

        public UserGateway(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<ApplicationUser> GetUserProfile(string userId)
        {
            var user = _context.Users.FindAsync(userId);

            return user;
        }
    }
}

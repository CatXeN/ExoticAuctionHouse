using AuthAPI.Data;
using AuthModels.Informations;
using AuthModels.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthAPI.Services
{
    public class UserService : IUserService
    {
        private readonly DataContext _context;

        public UserService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<GetUserInformation>> GetUsers()
        {
            var users = _context.Users.Select(x => new GetUserInformation()
            {
                Attributes = x.Attributes,
                Email = x.Email,
                Id = x.Id,
                Role = x.Role,
                Username = x.Username
            });

            return await users.ToListAsync();
        }
    }
}

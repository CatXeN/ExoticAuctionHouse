using AuthAPI.Data;
using AuthAPI.Helpers;
using AuthModels.Configs;
using AuthModels.Enums;
using AuthModels.Exceptions;
using AuthModels.Informations;
using AuthModels.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthAPI.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly DataContext _context;
        private readonly TokenConfig _config;

        public IdentityService(DataContext context, IOptions<TokenConfig> config)
        {
            _context = context;
            _config = config.Value;
        }

        public async Task CreateUser(UserInformation userInformation)
        {
            if (await _context.Users.AnyAsync(x => x.Username == userInformation.Username))
                throw new Exception("This username is already taken.");

            EncryptHelper.CreatePasswordHashAndSalt(userInformation.Password, out byte[] hash, out byte[] salt);

            var user = new User()
            {
                Email = userInformation.Email,
                PasswordHash = hash,
                PasswordSalt = salt,
                Role = userInformation.Role,
                Username = userInformation.Username,
                Attributes = ""
            };

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<string> GetToken(string username, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Username == username);

            if (user == null)
                throw new Exception("Username or password is wrong");

            if (!EncryptHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                throw new Exception("Username or password is wrong");

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, EnumHelper.GetDescription(user.Role))
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.SecurityKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddHours(24),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        public async Task<User> GetUserData(Guid userId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == userId);

            if (user == null)
                throw new UserNotFoundException("User not found");

            return user;
        }

        public async Task<bool> IsAdmin(string username)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);

            if (user == null)
                throw new UserNotFoundException($"{username}");

            return user.Role == Roles.Admin;
        }

        public async Task<Guid> SerachUserByEmail(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == email);

            if (user == null)
                throw new UserNotFoundException("User not found");

            return user.Id;
        }
    }
}

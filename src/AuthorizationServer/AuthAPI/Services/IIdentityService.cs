using AuthModels.Informations;
using AuthModels.Models;

namespace AuthAPI.Services
{
    public interface IIdentityService
    {
        Task CreateUser(UserInformation userInformation);
        Task<string> GetToken(string username, string password);
        Task<Guid> SerachUserByEmail(string email);
        Task<User> GetUserData(Guid userId);
        Task<bool> IsAdmin(string username);
    }
}

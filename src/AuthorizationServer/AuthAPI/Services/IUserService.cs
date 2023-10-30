using AuthModels.Informations;
using AuthModels.Models;

namespace AuthAPI.Services
{
    public interface IUserService
    {
        public Task<List<GetUserInformation>> GetUsers();
    }
}

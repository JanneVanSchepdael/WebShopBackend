using WebShopAPI.Models;

namespace WebShopAPI.Interfaces.IRepositories
{
    public interface IUserRepository
    {
        void Update(AppUser user);
        Task<AppUser> GetUserByIdAsync(int id);
        Task<AppUser> GetUserByUsernameAsync(string username);
    }
}

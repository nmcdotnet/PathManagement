using PathManagement.Models;

namespace PathManagement.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>?> GetAllAsync();

        Task<User?> GetByIdAsync(int id);
    }
}

using Microsoft.EntityFrameworkCore;
using PathManagement.Data;
using PathManagement.Models;

namespace PathManagement.Repositories
{
    public class SQLUserRepository : IUserRepository
    {
        private readonly PathManagementDbContext _pathManagementDbContext;

        public SQLUserRepository(PathManagementDbContext pathManagementDbContext)
        {
            _pathManagementDbContext = pathManagementDbContext;
        }
        public async Task<List<User>?> GetAllAsync()
        {
           return await _pathManagementDbContext.Set<User>().ToListAsync();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
          return await _pathManagementDbContext.Set<User>().FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}

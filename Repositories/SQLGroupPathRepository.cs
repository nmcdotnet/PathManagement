using Microsoft.EntityFrameworkCore;
using PathManagement.Data;
using PathManagement.Models.Domain;

namespace PathManagement.Repositories
{
    public class SQLGroupPathRepository : IGroupPathRepository
    {
        private readonly PathManagementDbContext _pathManagementDbContext;

        public SQLGroupPathRepository(PathManagementDbContext pathManagementDbContext)
        {
           _pathManagementDbContext = pathManagementDbContext;
        }
        public async Task<GroupPathModel> CreateAsync(GroupPathModel groupPathModel)
        {
            using var trans = await _pathManagementDbContext.Database.BeginTransactionAsync();
            try
            {
                await _pathManagementDbContext.AddAsync(groupPathModel);
                await _pathManagementDbContext.SaveChangesAsync();
                await trans.CommitAsync(); 
            }
            catch 
            {
                await trans.RollbackAsync();
            }
            return groupPathModel;
        }

        public async Task<List<GroupPathModel>?> GetAllAsync()
        {
            try
            {
              return  await _pathManagementDbContext.Groups.ToListAsync();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}

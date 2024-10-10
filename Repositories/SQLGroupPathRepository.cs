using Microsoft.EntityFrameworkCore;
using PathManagement.Data;
using PathManagement.Models;
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

        public async Task<GroupPathModel?> CreateAsync(GroupPathModel groupPathModel)
        {
            using var trans = await _pathManagementDbContext.Database.BeginTransactionAsync();
            try
            {
                await _pathManagementDbContext.AddAsync(groupPathModel);
                await _pathManagementDbContext.SaveChangesAsync();

                var addedGroupPath = await _pathManagementDbContext.Groups
                    .FirstOrDefaultAsync(g => g.Id == groupPathModel.Id);

                if (addedGroupPath != null)
                {
                    await trans.CommitAsync();
                    return addedGroupPath;
                }
                else
                {
                    await trans.RollbackAsync();
                    return null;
                }
            }
            catch
            {
                await trans.RollbackAsync();
                return null;    
            }
        }

        public async Task<List<GroupPathModel>?> GetAllAsync()
        {
            return await _pathManagementDbContext.Groups.ToListAsync();
        }

        public async Task<GroupPathModel?> GetByIdAsync(int id)
        {
            return await _pathManagementDbContext.Groups.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<GroupPathModel?> UpdateAsync(int id, GroupPathModel gpm)
        {
            using var trans = await _pathManagementDbContext.Database.BeginTransactionAsync();
            try
            {
                var path = await _pathManagementDbContext.Groups.FirstOrDefaultAsync(p => p.Id == id);
                if (path == null) return null;
                path.Name = gpm.Name;
                path.Description = gpm.Description;
                await _pathManagementDbContext.SaveChangesAsync();
                await trans.CommitAsync();
                return path;
            }
            catch (Exception)
            {
                await trans.RollbackAsync();
                return null;
            }
        }

        public async Task<GroupPathModel?> DeleteAsync(int id)
        {
            using var trans = await _pathManagementDbContext.Database.BeginTransactionAsync();
            try
            {
                GroupPathModel? path = await _pathManagementDbContext.Groups.FindAsync(id);
                if (path == null) { return null; }
                _pathManagementDbContext.Groups.Remove(path);
                await _pathManagementDbContext.SaveChangesAsync();
                await trans.CommitAsync();
                return path;
            }
            catch (Exception)
            {
                await trans.RollbackAsync();
                return null;
            }
        }
    }
}

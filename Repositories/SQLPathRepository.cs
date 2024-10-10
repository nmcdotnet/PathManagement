using Microsoft.EntityFrameworkCore;
using PathManagement.Data;
using PathManagement.Models.Domain;

namespace PathManagement.Repositories
{
    public class SQLPathRepository : IPathRepository
    {
        private readonly PathManagementDbContext _pathManagementDbContext;

        public SQLPathRepository(PathManagementDbContext dbContext)  //Inject Dbcontext
        { 
            _pathManagementDbContext = dbContext;
        }

        public async Task<PathModel?> CreateAsync(PathModel path)
        {
            using var trans = _pathManagementDbContext.Database.BeginTransaction();
            try
            {
                await _pathManagementDbContext.Paths.AddAsync(path);
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

        public async Task<List<PathModel>?> GetAllAsync()
        {
            return await _pathManagementDbContext.Paths.ToListAsync();
        }

        public async Task<List<PathModel>?> GetByIdAsync(int id)
        {
            var listById = await _pathManagementDbContext.Paths.Where(p=>p.Id == id).ToListAsync();
            if (listById == null) return null;
           return listById;
        }

        public async Task<PathModel?> UpdateAsync(int id, PathModel path)
        {
            using var trans = _pathManagementDbContext.Database.BeginTransaction();
            try
            {
                var existingPath = await _pathManagementDbContext.Paths.FirstOrDefaultAsync(path => path.Id == id);
                if (existingPath == null)
                {
                    return null;
                }
                existingPath.Path = path.Path;
                existingPath.Name = path.Name;
                existingPath.Description = path.Description;
                existingPath.GroupPath = path.GroupPath;
                await _pathManagementDbContext.SaveChangesAsync();
                await trans.CommitAsync();
                return existingPath;
            }
            catch (Exception)
            {
                await trans.RollbackAsync();
                return null;
            }
        }

        public async Task<PathModel?> DeleteAsync(int id)
        {
            using var trans = _pathManagementDbContext.Database.BeginTransaction();
            try
            {
                PathModel? existingPath = await _pathManagementDbContext.Paths.FirstOrDefaultAsync(p => p.Id == id);
                if (existingPath == null) return null;
                _pathManagementDbContext.Paths.Remove(existingPath);
                await _pathManagementDbContext.SaveChangesAsync();
                await trans.CommitAsync();
                return existingPath;
            }
            catch (Exception)
            {
                await trans.RollbackAsync();
                return null;
            }
        }
    }
}

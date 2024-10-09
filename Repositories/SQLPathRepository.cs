using Microsoft.EntityFrameworkCore;
using PathManagement.Data;
using PathManagement.Models.Domain;

namespace PathManagement.Repositories
{
    public class SQLPathRepository : IPathRepository
    {
        private readonly PathManagementDbContext _dbContext;
        public SQLPathRepository(PathManagementDbContext dbContext)  //Inject Dbcontext
        { 
            _dbContext = dbContext;
        }

        // Create new path
        public async Task<PathModel> CreateAsync(PathModel path)
        {
            await _dbContext.Paths.AddAsync(path); 
            await _dbContext.SaveChangesAsync();
            return path;
        }

        // Get all path list
        public async Task<List<PathModel>> GetAllAsync()
        {
            return await _dbContext.Paths.ToListAsync();
        }

        // GEt by id
        public async Task<List<PathModel>?> GetByIdAsync(int id)
        {
            var listById = await _dbContext.Paths.Where(p=>p.Id == id).ToListAsync();
            if (listById == null) return null;
           return listById;
        }

        //Update path
        public async Task<PathModel?> UpdateAsync(int id, PathModel path)
        {
            var existingPath = await _dbContext.Paths.FirstOrDefaultAsync(path =>path.Id == id);
            if (existingPath == null)
            {
                return null;
            }
            // Update value
            existingPath.Path = path.Path;
            existingPath.Name = path.Name;
            existingPath.Description = path.Description;
            existingPath.GroupPath = path.GroupPath;
            await _dbContext.SaveChangesAsync();
            
            return existingPath;

        }

        //Delete path
        public async Task<PathModel?> DeleteAsync(int id)
        {
            PathModel? existingPath = await _dbContext.Paths.FirstOrDefaultAsync(p => p.Id == id);
            if (existingPath == null) return null;
            _dbContext.Paths.Remove(existingPath); 
            await _dbContext.SaveChangesAsync();
            return existingPath;
        }

      

      
    }
}

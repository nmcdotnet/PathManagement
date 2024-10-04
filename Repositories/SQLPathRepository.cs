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
        public async Task<PathModel?> GetById(int id)
        {
           return await _dbContext.Paths.FirstOrDefaultAsync(path => path.Id == id);
        }

        //Update path
        public Task<PathModel> Update(PathModel path)
        {
            throw new NotImplementedException();
        }

        //Delete path
        public Task<PathModel> Delete(int id)
        {
            throw new NotImplementedException();
        }

      

      
    }
}

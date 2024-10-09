using PathManagement.Models.Domain;

namespace PathManagement.Repositories
{
    public interface IPathRepository
    {
        Task<List<PathModel>> GetAllAsync();

        Task<List<PathModel>?> GetByIdAsync(int id);

        Task<PathModel> CreateAsync(PathModel path);

        Task<PathModel?> UpdateAsync(int id, PathModel path);

        Task<PathModel?> DeleteAsync(int id);
    }
}

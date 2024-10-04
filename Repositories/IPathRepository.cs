using PathManagement.Models.Domain;

namespace PathManagement.Repositories
{
    public interface IPathRepository
    {
        Task<List<PathModel>> GetAllAsync();

        Task<PathModel?> GetById(int id);

        Task<PathModel> CreateAsync(PathModel path);

        Task<PathModel> Update(PathModel path);

        Task<PathModel> Delete(int id);
    }
}

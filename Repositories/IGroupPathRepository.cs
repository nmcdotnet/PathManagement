using PathManagement.Models;
using PathManagement.Models.Domain;

namespace PathManagement.Repositories
{
    public interface IGroupPathRepository
    {
       Task<GroupPathModel?> CreateAsync(GroupPathModel groupPathModel);

       Task<List<GroupPathModel>?> GetAllAsync();

       Task<GroupPathModel?> GetByIdAsync(int id);

       Task<GroupPathModel?> UpdateAsync(int id, GroupPathModel gpm);

        Task<GroupPathModel?> DeleteAsync(int id);
    }
}

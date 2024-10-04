using PathManagement.Models.Domain;
using PathManagement.Models.DTO;

namespace PathManagement.Models.Extensions
{
    public static class PathModelExtensions
    {

        //Convert Domain to DTO
        public static PathModelDto ToDto(this PathModel pathModel)
        {
            return new PathModelDto
            {
                Id = pathModel.Id,
                Name = pathModel.Name,
                Description = pathModel.Description,
                Path = pathModel.Path,
                GroupPathId = pathModel.GroupPathId
            };
        }

        //Convert DTO to Domain
        public static PathModel ToDomain(this PathModelDto pathModelDto)
        {
            return new PathModel
            {
                Id = pathModelDto.Id,
                Name = pathModelDto.Name,
                Description = pathModelDto.Description,
                Path = pathModelDto.Path,
                GroupPathId = pathModelDto.GroupPathId
            };
        }
    }
}

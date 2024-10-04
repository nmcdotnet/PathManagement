using AutoMapper;
using PathManagement.Models.Domain;
using PathManagement.Models.DTO;
namespace PathManagement.Mappings
{
    public class AutomapperProfiles : Profile
    {
        // Use auto mapper for convert Domain to Dto and Reverse
        public AutomapperProfiles()
        {
            CreateMap<PathModel,PathModelDto>().ReverseMap();
            CreateMap<CreatePathDto,PathModel>().ReverseMap();
        }
    }
}

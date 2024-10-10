using AutoMapper;
using PathManagement.Models;
using PathManagement.Models.Domain;
using PathManagement.Models.DTO;
namespace PathManagement.Mappings
{
    public class AutomapperProfiles : Profile
    {
        // Use auto mapper for convert Domain to Dto and Reverse
        public AutomapperProfiles()
        {
            // Map for Path
            CreateMap<PathModel,PathModelDto>().ReverseMap();
            CreateMap<CreatePathDto,PathModel>().ReverseMap();
            CreateMap<UpdatePathRequestDto, PathModel>().ReverseMap();

            //Map for Group Path
            CreateMap<GroupPathModel,AddGroupPathRequestDto>().ReverseMap();
            CreateMap<GroupPathModel, UpdateGroupRequestDto>().ReverseMap();
            CreateMap<GroupPathModel,GroupPathModelDto>().ReverseMap(); 

            // User map
            CreateMap<User,UserDto>().ReverseMap();


        }
    }
}

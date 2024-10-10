using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PathManagement.Models.DTO;
using PathManagement.Repositories;

namespace PathManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<Models.User>? userDomainList = await _userRepository.GetAllAsync();
            List<UserDto> userDtoList = _mapper.Map<List<UserDto>>(userDomainList);
            return Ok(userDtoList);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            Models.User? userDomain = await _userRepository.GetByIdAsync(id);
            return Ok(_mapper.Map<UserDto>(userDomain));
        }
    }
}

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PathManagement.Models.Domain;
using PathManagement.Models.DTO;
using PathManagement.Repositories;

namespace PathManagement.Controllers
{
    // api/GroupPath
    [Route("api/[controller]")]
    [ApiController]
    public class GroupPathController : ControllerBase
    {
        private readonly IGroupPathRepository _groupPathRepository;
        private readonly IMapper _mapper;
        private const string _id = "{id:int}";

        public GroupPathController(IGroupPathRepository groupPathRepository, IMapper mapper)
        {
            _groupPathRepository = groupPathRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddGroupPathRequestDto addGroupPathRequestDto)
        {
            var groupPathDomain = _mapper.Map<GroupPathModel>(addGroupPathRequestDto);   // Map to domain
            await _groupPathRepository.CreateAsync(groupPathDomain);
            var groupPathDto = _mapper.Map<GroupPathModelDto>(groupPathDomain);
            return Ok(groupPathDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var listGroupPath = await _groupPathRepository.GetAllAsync();
            if (listGroupPath.IsNullOrEmpty()) NotFound();
            return Ok(listGroupPath);
        }

        [HttpPost]
        [Route(_id)]
        public async Task<IActionResult> Update()
        {

        }

    }
}

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
            var groupDomain = await _groupPathRepository.CreateAsync(groupPathDomain);
            if (groupDomain == null) NotFound("Khong tim thay");
            var groupPathDto = _mapper.Map<GroupPathModelDto>(groupDomain);
            return Ok(groupPathDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var listGroupPath = await _groupPathRepository.GetAllAsync();
            if (listGroupPath.IsNullOrEmpty()) NotFound();

            return Ok(_mapper.Map<List<GroupPathModelDto>>(listGroupPath));
        }

        [HttpPut]
        [Route(_id)]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateGroupRequestDto updateGroupDto)
        {
            var group = _mapper.Map<GroupPathModel>(updateGroupDto);
            var groupUpdated = await _groupPathRepository.UpdateAsync(id, group);
            if(groupUpdated==null) NotFound();
            return Ok(_mapper.Map<GroupPathModelDto>(groupUpdated));
        }

        [HttpDelete]
        [Route(_id)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var group = await _groupPathRepository.DeleteAsync(id);
            if (group == null) NotFound();
            return Ok(_mapper.Map<GroupPathModelDto>(group));
        }
    }
}

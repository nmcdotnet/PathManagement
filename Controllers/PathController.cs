using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PathManagement.Data;
using PathManagement.Models.Domain;
using PathManagement.Models.DTO;
using PathManagement.Repositories;

namespace PathManagement.Controllers
{
    // address : https://localhost:5001;http://localhost:5125

    // https://localhost:5001/api/path
    [Route("api/[controller]")]
    [ApiController]
    public class PathController : ControllerBase
    {

        private const string _id = "{id:int}";
        private readonly IPathRepository _pathRepository;
        private readonly IMapper _mapper;

        public PathController(IPathRepository pathRepository, IMapper mapper)
        {
            _pathRepository = pathRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Create new path
        /// </summary>
        /// <param name="createPathDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePathDto createPathDto)
        {
            if (createPathDto == null) return BadRequest();
            PathModel pathDomain = _mapper.Map<PathModel>(createPathDto);   //Dto to domain
            PathModel pathDomainResponse = await _pathRepository.CreateAsync(pathDomain);
            PathModelDto pathDto = _mapper.Map<PathModelDto>(pathDomainResponse);   //Domain to dto
            return CreatedAtAction(nameof(GetById), new { id = pathDto.Id }, pathDto); // action name, route value, respone value
        }

        /// <summary>
        /// Get all path 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<PathModel> pathsDomain = await _pathRepository.GetAllAsync(); //Get path list domain
            var pathsDto = _mapper.Map<List<PathModelDto>>(pathsDomain); // Convert from domain to DTO
            return Ok(pathsDto);
        }

        /// <summary>
        /// Get path by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route(_id)]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            List<PathModel>? pathDomain = await _pathRepository.GetByIdAsync(id); // get path dto
            List<PathModelDto> pathDto = _mapper.Map<List<PathModelDto>>(pathDomain);//Domain => Dto
            return Ok(pathDto);
        }

        /// <summary>
        /// Update Path
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updatePathRequestDto"></param>
        /// <returns></returns>
        [HttpPut]
        [Route(_id)]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdatePathRequestDto updatePathRequestDto)
        {
            PathModel pathDomain = _mapper.Map<PathModel>(updatePathRequestDto);  // Map to Domain Model
            PathModel? pathUpdated = await _pathRepository.UpdateAsync(id, pathDomain);
            if (pathUpdated == null) return NotFound();
            var pathDto = _mapper.Map<PathModelDto>(pathUpdated); // Convert to Dto 
            return Ok(pathDto);
        }

        /// <summary>
        /// Delete Path
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route(_id)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var removedPath = await _pathRepository.DeleteAsync(id);
            if (removedPath == null) return NotFound();
            _mapper.Map<PathModelDto>(removedPath); // Convert to Dto
            return Ok(removedPath);
        }

    }
}

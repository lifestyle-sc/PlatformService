using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.Dtos;
using PlatformService.Models;

namespace PlatformService.Controllers
{
    [Route("api/platforms")]
    [ApiController]
    public class PlatformController : ControllerBase
    {
        private readonly IPlatformRepo _repository;
        private readonly IMapper _mapper;

        public PlatformController(IPlatformRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetPlatforms()
        {
            var platformsEntities = _repository.GetAllPlatforms();

            var platformToReturn = _mapper.Map<IEnumerable<PlatformDto>>(platformsEntities);

            return Ok(platformToReturn);
        }

        [HttpGet("{id:guid}", Name = "GetPlatform")]
        public IActionResult GetPlatform(Guid id)
        {
            var platformEntity = _repository.GetPlatformById(id);

            if (platformEntity == null)
                return NotFound();

            var platformToReturn = _mapper.Map<PlatformDto>(platformEntity);

            return Ok(platformToReturn);
        }

        [HttpPost]
        public IActionResult CreatePlatform([FromBody] PlatformForCreationDto platformForCreation)
        {
            if (platformForCreation == null)
                return BadRequest("The platformForCreationDto object sent by the client is null.");

            var platformEntity = _mapper.Map<Platform>(platformForCreation);

            _repository.CreatePlatform(platformEntity);
            _repository.SaveChanges();

            var platformToReturn = _mapper.Map<PlatformDto>(platformEntity);

            return CreatedAtRoute("GetPlatform", new { Id = platformToReturn.Id }, platformToReturn);
        }
    }
}

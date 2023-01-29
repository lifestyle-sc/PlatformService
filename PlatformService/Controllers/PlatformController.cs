using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.Dtos;

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

        [HttpGet("{id:guid}")]
        public IActionResult GetPlatform(Guid id)
        {
            var platformEntity = _repository.GetPlatformById(id);

            if (platformEntity == null)
                return NotFound();

            var platformToReturn = _mapper.Map<PlatformDto>(platformEntity);

            return Ok(platformToReturn);
        }
    }
}

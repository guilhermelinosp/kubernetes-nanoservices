using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;

namespace PlatformService.Controllers
{
	[Route("api/public/v1/[controller]")]
	[ApiController]
	public class PlatformController : ControllerBase
	{
		private readonly IMapper _mapper;
		private readonly IPlatformRepo _repository;

		public PlatformController(IPlatformRepo repository, IMapper mapper)
		{
			_mapper = mapper;
			_repository = repository;
		}


		[HttpGet]
		public ActionResult<Dtos.PlatformReadDto> GetPlatforms()
		{
			var platforms = _repository.GetAllPlatforms();

			return Ok(_mapper.Map<Dtos.PlatformReadDto[]>(platforms));
		}

		[HttpGet("{id:int}", Name = "GetPlatformById")]
		public ActionResult<Models.Platform> GetPlatformById(int id)
		{
			var platform = _repository.GetPlatformById(id);
			if (platform is null)
			{
				return NotFound();
			}

			return Ok(_mapper.Map<Dtos.PlatformReadDto>(platform));
		}

		[HttpPost]
		public ActionResult<Models.Platform> CreatePlatform(Dtos.PlatformCreateDto platformCreateDto)
		{
			var platform = _mapper.Map<Models.Platform>(platformCreateDto);
			_repository.CreatePlatform(platform);
			_repository.SaveChanges();

			var platformReadDto = _mapper.Map<Dtos.PlatformReadDto>(platform);

			return CreatedAtRoute(nameof(GetPlatformById), new { platformReadDto.Id }, platformReadDto);
		}

	}
}

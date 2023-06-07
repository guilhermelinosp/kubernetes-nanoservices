using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.AsyncDataService.Http;
using PlatformService.Data;
using PlatformService.Dtos;

namespace PlatformService.Controllers
{
	[Route("api/v1/[controller]")]
	[ApiController]
	public class PlatformController : ControllerBase
	{
		private readonly IMapper _mapper;
		private readonly IPlatformRepo _repository;
		private readonly ICommandDataClient _commandDataClient;

		public PlatformController(IPlatformRepo repository, IMapper mapper, ICommandDataClient commandDataClient)
		{
			_mapper = mapper;
			_repository = repository;
			_commandDataClient = commandDataClient;
		}


		[HttpGet]
		public ActionResult<PlatformReadDto> GetPlatforms()
		{
			var platforms = _repository.GetAllPlatforms();

			return Ok(_mapper.Map<PlatformReadDto[]>(platforms));
		}

		[HttpGet("{id:int}", Name = "GetPlatformById")]
		public ActionResult<Models.Platform> GetPlatformById(int id)
		{
			var platform = _repository.GetPlatformById(id);
			if (platform is null)
			{
				return NotFound();
			}

			return Ok(_mapper.Map<PlatformReadDto>(platform));
		}

		[HttpPost]
		public async Task<ActionResult<Models.Platform>> CreatePlatform(PlatformCreateDto platformCreateDto)
		{
			var platform = _mapper.Map<Models.Platform>(platformCreateDto);
			_repository.CreatePlatform(platform);
			_repository.SaveChanges();

			var platformReadDto = _mapper.Map<Dtos.PlatformReadDto>(platform);

			try
			{
				await _commandDataClient.SendPlatformToCommand(platformReadDto);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error in CreatePlatform: {ex.Message}");
			}

			return CreatedAtRoute(nameof(GetPlatformById), new { platformReadDto.Id }, platformReadDto);
		}

	}
}

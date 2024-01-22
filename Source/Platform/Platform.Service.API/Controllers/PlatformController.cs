using Microsoft.AspNetCore.Mvc;
using Platform.Service.Application.UseCases.Platform;
using Platform.Service.Domain.DTOs;

namespace Platform.Service.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class PlatformController(IPlatformUseCase platform) : Controller
{
	[HttpGet]
	[ProducesResponseType<IEnumerable<PlatformRead>>(StatusCodes.Status200OK)]
	public async Task<IActionResult> GetAllPlatforms()
	{
		return Ok(await platform.GetAllPlatforms());
	}

	[HttpGet("{platformId}")]
	[ProducesResponseType<PlatformRead>(StatusCodes.Status200OK)]
	public async Task<IActionResult> GetPlatformById([FromRoute] Guid platformId)
	{
		return Ok(await platform.GetPlatformById(platformId));
	}

	[HttpPost]
	public async Task<IActionResult> CreatePlatform([FromBody] PlatformCreate request)
	{
		await platform.CreatePlatform(request);
		return Created();
	}
}
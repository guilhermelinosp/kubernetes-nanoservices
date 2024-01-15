using Microsoft.AspNetCore.Mvc;
using Platform.Service.Application.UseCases.Platforms;
using Platform.Service.Domain.DTOs.Requests;
using Platform.Service.Domain.DTOs.Responses;

namespace Platform.Service.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class PlatformController(IPlatformUseCase platform) : Controller
{
	[HttpGet]
	[ProducesResponseType<IEnumerable<ResponsePlatform>>(StatusCodes.Status200OK)]
	public async Task<IActionResult> GetAllPlatforms()
	{
		return Ok(await platform.GetAllPlatforms());
	}

	[HttpGet("{platformId}")]
	[ProducesResponseType<ResponsePlatform>(StatusCodes.Status200OK)]
	public async Task<IActionResult> GetPlatformById([FromRoute] Guid platformId)
	{
		return Ok(await platform.GetPlatformById(platformId));
	}

	[HttpPost]
	public async Task<IActionResult> CreatePlatform([FromBody] RequestPlatform request)
	{
		await platform.CreatePlatform(request);
		return Created();
	}
}
using Command.Service.Application.UseCases.Platform;
using Command.Service.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Command.Service.API.Controllers;

[ApiController]
[Route("api/v1/c/[controller]")]
public class PlatformController(IPlatformUseCase platform) : Controller
{
	[HttpGet]
	public async Task<ActionResult<IEnumerable<ResponsePlatform>>> GetPlatforms()
	{
		Console.WriteLine("--> Getting Platforms from CommandsService");

		return Ok(await platform.GetAllPlatforms());
	}

	[HttpPost]
	public ActionResult TestInboundConnection()
	{
		Console.WriteLine("--> Inbound POST # Command Service");

		return Ok("Inbound test of from Platforms Controler");
	}
}
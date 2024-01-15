namespace Platform.Service.Domain.DTOs.Responses;

public class ResponsePlatform
{
	public Guid PlatformId { get; set; }

	public required string Name { get; set; }

	public required string Publisher { get; set; }

	public required string Cost { get; set; }
}
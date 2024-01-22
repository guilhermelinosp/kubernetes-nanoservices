namespace Platform.Service.Domain.DTOs;

public class PlatformPublished
{
	public int PlatformId { get; set; }
	public required string Name { get; set; }
	public required string Event { get; set; }
}
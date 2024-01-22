namespace Platform.Service.Domain.DTOs;

public class PlatformRead
{
	public int PlatformId { get; set; }

	public required string Name { get; set; }
   
	public required string Publisher { get; set; }
        
	public required string Cost { get; set; }
}
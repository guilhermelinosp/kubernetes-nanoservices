using System.ComponentModel.DataAnnotations;

namespace Platform.Service.Domain.DTOs;

public class PlatformCreate
{
	public required string Name { get; set; }

	public required string Publisher { get; set; }

	public required string Cost { get; set; }
}
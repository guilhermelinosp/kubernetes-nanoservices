using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Platform.Service.Domain.Entities;

[Table("TB_Platform")]
public class Platform
{
	[Key] public Guid PlatformId { get; set; } = Guid.NewGuid();

	public required string Name { get; set; }

	public required string Publisher { get; set; }

	public required string Cost { get; set; }

	public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

	public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
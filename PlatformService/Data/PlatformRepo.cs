using PlatformService.Models;

namespace PlatformService.Data
{
	public class PlatformRepo : IPlatformRepo
	{
		private readonly AppDbContext _context;
		public PlatformRepo(AppDbContext context)
		{
			_context = context;
		}

		public bool? SaveChanges()
		{
			return (_context.SaveChanges() >= 0);
		}

		public IEnumerable<Platform>? GetAllPlatforms()
		{
			return _context.Platforms!.ToList();
		}

		public Platform? GetPlatformById(int id)
		{
			return _context.Platforms!.FirstOrDefault(p => p.Id == id);
		}

		public void CreatePlatform(Platform platform)
		{
			if (platform == null)
			{
				throw new ArgumentNullException(nameof(platform));
			}

			_context.Platforms!.Add(platform);
		}
	}
}

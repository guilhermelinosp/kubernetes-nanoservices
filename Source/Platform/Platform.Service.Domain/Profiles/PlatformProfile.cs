using AutoMapper;
using Platform.Service.Domain.DTOs;

namespace Platform.Service.Domain.Profiles;

public class PlatformProfile : Profile
{
	public PlatformProfile()
	{
		CreateMap<Domain.Entities.Platform, PlatformRead>();
		CreateMap<PlatformCreate, Domain.Entities.Platform>();
	}
}
using AutoMapper;
using Platform.Service.Domain.DTOs.Requests;
using Platform.Service.Domain.DTOs.Responses;

namespace Platform.Service.Domain.Profiles;

public class PlatformProfile : Profile
{
	public PlatformProfile()
	{
		CreateMap<Domain.Entities.Platform, ResponsePlatform>();
		CreateMap<RequestPlatform, Domain.Entities.Platform>();
	}
}
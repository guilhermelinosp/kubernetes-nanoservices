using AutoMapper;
using Command.Service.Domain.DTOs;
using Command.Service.Domain.Entities;

namespace Command.Service.Domain.Profiles;

public class CommandProfile : Profile
{
	public CommandProfile()
	{
		CreateMap<Platform, ResponsePlatform>();
		CreateMap<RequestCommand, Entities.Command>();
		CreateMap<Entities.Command, ResponseCommand>();
	}
}
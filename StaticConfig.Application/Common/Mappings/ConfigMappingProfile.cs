using AutoMapper;
using StaticConfig.Application.Config.Responses;

namespace StaticConfig.Application.Common.Mappings;

public class ConfigMappingProfile : Profile
{
    public ConfigMappingProfile()
    {
        ApplyMappings();
    }

    private void ApplyMappings()
    {
        CreateMap<Domain.Config, GetConfigResponse>().ReverseMap();
    }
}
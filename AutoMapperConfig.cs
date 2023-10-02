using AutoMapper;
using Villa_Api.Model;
using Villa_Api.Model.DTO;

namespace Villa_Api;

public class AutoMapperConfig : Profile
{
    public AutoMapperConfig()
    {
        CreateMap<Villa, VillaDTO>().ReverseMap();
        CreateMap<Villa, VillaCreateDTO>().ReverseMap();
        CreateMap<Villa, VillaUpdateDTO>().ReverseMap();
    }
}
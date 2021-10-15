using BackEnd.Dtos;
using BackEnd.models;
using AutoMapper;

namespace BackEnd.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<City, CityDto>().ReverseMap();
            // CreateMap<CityDto, City>();
        }
    }
}
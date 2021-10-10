using AngularAPI.Dtos;
using AngularAPI.models;
using AutoMapper;

namespace AngularAPI.Helpers
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
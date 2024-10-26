using _2.BirdsDomain.Entities;
using _3.BirdsApplication.DTOs;
using AutoMapper;

namespace _4.BirdsInfrastructure.Mappings
{
    internal class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {         
            CreateMap<Security, SecurityDto>().ReverseMap();
        }
    }
}

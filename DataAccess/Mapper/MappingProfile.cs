using AutoMapper;
using Entity.DTO;
using Entity.Entities;

namespace DataAccess.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Planet Mappers
            CreateMap<PlanetDTO, Planet>();
            CreateMap<Planet, PlanetDTO>();

            // Satellite Mappers
            CreateMap<SatelliteDTO, Satellite>();
            CreateMap<Satellite, SatelliteDTO>();
        }
    }
}

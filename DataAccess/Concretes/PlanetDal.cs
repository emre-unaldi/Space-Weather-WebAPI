using AutoMapper;
using DataAccess.Abstracts;
using DataAccess.Contexts;
using Entity.DTO;
using Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess.Concretes
{
    public class PlanetDal : IPlanetDal
    {
        private readonly SpaceWeatherDbContext _dbContext;
        private readonly IMapper _mapper;

        public PlanetDal(SpaceWeatherDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new SpaceWeatherDbContext(serviceProvider.GetRequiredService<DbContextOptions<SpaceWeatherDbContext>>()))
            {
                if (context.Planets.Any())
                {
                    return;
                }

                context.Planets.AddRange(
                    new Planet(1, "Mars", 20, 3, 12, 24, 5),
                    new Planet(2, "Jupiter", 21, 3, 13, 24, 6),
                    new Planet(3, "Venüs", 22, 4, 14, 25, 7)
                );

                context.SaveChanges();
            }
        }

        public void Add(PlanetDTO planetDTO)
        {
            var addPlanet = _mapper.Map<Planet>(planetDTO);

            _dbContext.Planets.Add(addPlanet);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            Planet deletePlanet = _dbContext.Planets.Find(id);

            _dbContext.Planets.Remove(deletePlanet);
            _dbContext.SaveChanges();
        }
        
        public void Update(PlanetDTO planetDTO)
        {
            var exitingPlanet = _dbContext.Planets.SingleOrDefault(p => p.Id == planetDTO.Id);

            _dbContext.Planets.Remove(exitingPlanet);

            var updatePlanet = _mapper.Map<Planet>(planetDTO);

            _dbContext.Planets.Add(updatePlanet);
            _dbContext.SaveChanges();
        }

        public List<PlanetDTO> GetAll()
        {
            var planetList = _dbContext.Planets.OrderBy(planet => planet.Id).ToList<Planet>();
            List<PlanetDTO> planetListDto = _mapper.Map<List<PlanetDTO>>(planetList);

            return planetListDto;
        }

        public PlanetDTO GetById(int id)
        {
            Planet getByIdPlanet = _dbContext.Planets.Find(id);
            PlanetDTO planetDto = _mapper.Map<PlanetDTO>(getByIdPlanet);

            return planetDto;
        }

        public List<PlanetDTO> Pagination(int pageNumber, int pageSize)
        {
            List<Planet> planetList = _dbContext.Planets.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList<Planet>();
            List<PlanetDTO> planetDtoList = _mapper.Map<List<PlanetDTO>>(planetList);

            return planetDtoList;
        }
        
        public List<PlanetDTO> FilterByTemperature(int temperature)
        {
            List<Planet> filteredList = _dbContext.Planets.Where(planet => planet.Temperature > temperature).ToList();
            List<PlanetDTO> planetListDto = _mapper.Map<List<PlanetDTO>>(filteredList);

            return planetListDto;
        }

        public List<PlanetDTO> SortByNameAsc()
        {
            List<Planet> planetList = _dbContext.Planets.OrderBy(planet => planet.Name).ToList();
            List<PlanetDTO> planetListDto = _mapper.Map<List<PlanetDTO>>(planetList);

            return planetListDto;
        }

        public List<PlanetDTO> SortByNameDesc()
        {
            List<Planet> planetList = _dbContext.Planets.OrderByDescending(planet => planet.Name).ToList();
            List<PlanetDTO> planetListDto = _mapper.Map<List<PlanetDTO>>(planetList);

            return planetListDto;
        }
    }
}

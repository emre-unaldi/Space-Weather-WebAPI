using AutoMapper;
using DataAccess.Abstracts;
using DataAccess.Contexts;
using Entity.DTO;
using Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess.Concretes
{
    public class SatelliteDal : ISatelliteDal
    {
        private readonly SpaceWeatherDbContext _dbContext;
        private readonly IMapper _mapper;

        public SatelliteDal(SpaceWeatherDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new SpaceWeatherDbContext(serviceProvider.GetRequiredService<DbContextOptions<SpaceWeatherDbContext>>()))
            {
                if (context.Satellites.Any())
                {
                    return;
                }

                context.Satellites.AddRange(
                    new Satellite(1, "Titan", 20, 3, 12, 24, 1),
                    new Satellite(2, "Phobos", 21, 3, 13, 24, 2),
                    new Satellite(3, "Europa", 22, 4, 14, 25, 3)
                );

                context.SaveChanges();
            }
        }

        public void Add(Satellite satellite)
        {
            _dbContext.Satellites.Add(satellite);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            Satellite deleteSatellite = _dbContext.Satellites.Find(id);

            _dbContext.Satellites.Remove(deleteSatellite);
            _dbContext.SaveChanges();
        }
        public void Update(Satellite satellite)
        {
            Satellite exitingSatellite = _dbContext.Satellites.SingleOrDefault(satellite => satellite.Id == satellite.Id);

            _dbContext.Satellites.Remove(exitingSatellite);

            _dbContext.Satellites.Add(satellite);
            _dbContext.SaveChanges();
        }

        public List<SatelliteDTO> GetAll()
        {
            var satelliteList = _dbContext.Satellites.OrderBy(satellite => satellite.Id).ToList<Satellite>();
            List<SatelliteDTO> satelliteListDto = _mapper.Map<List<SatelliteDTO>>(satelliteList);

            return satelliteListDto;
        }

        public SatelliteDTO GetById(int id)
        {
            Satellite getByIdSatellite = _dbContext.Satellites.Find(id);
            SatelliteDTO satelliteDto = _mapper.Map<SatelliteDTO>(getByIdSatellite);

            return satelliteDto;
        }

        public List<SatelliteDTO> Pagination(int pageNumber, int pageSize)
        {
            List<Satellite> satelliteList = _dbContext.Satellites.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList<Satellite>();
            List<SatelliteDTO> satelliteListDto = _mapper.Map<List<SatelliteDTO>>(satelliteList);

            return satelliteListDto;
        }
        public List<SatelliteDTO> FilterByTemperature(int temperature)
        {
            List<Satellite> filteredList = _dbContext.Satellites.Where(satellite => satellite.Temperature > temperature).ToList();
            List<SatelliteDTO> satelliteListDto = _mapper.Map<List<SatelliteDTO>>(filteredList);

            return satelliteListDto;
        }

        public List<SatelliteDTO> SortByNameAsc()
        {
            List<Satellite> satelliteList = _dbContext.Satellites.OrderBy(satellite => satellite.Name).ToList();
            List<SatelliteDTO> satelliteListDto = _mapper.Map<List<SatelliteDTO>>(satelliteList);

            return satelliteListDto;
        }

        public List<SatelliteDTO> SortByNameDesc()
        {
            List<Satellite> satelliteList = _dbContext.Satellites.OrderByDescending(satellite => satellite.Name).ToList();
            List<SatelliteDTO> satelliteListDto = _mapper.Map<List<SatelliteDTO>>(satelliteList);

            return satelliteListDto;
        }
    }
}

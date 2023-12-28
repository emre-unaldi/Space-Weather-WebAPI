using Entity.DTO;

namespace DataAccess.Abstracts
{
    public interface IPlanetDal
    {
        void Add(PlanetDTO planetDTO);
        void Delete(int id);
        void Update(PlanetDTO planetDTO);
        List<PlanetDTO> GetAll();
        PlanetDTO GetById(int id);
        List<PlanetDTO> Pagination(int pageNumber, int pageSize);
        List<PlanetDTO> FilterByTemperature(int temperature);
        List<PlanetDTO> SortByNameAsc();
        List<PlanetDTO> SortByNameDesc();
    }
}

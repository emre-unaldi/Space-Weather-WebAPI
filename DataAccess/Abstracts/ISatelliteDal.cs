using Entity.DTO;
using Entity.Entities;

namespace DataAccess.Abstracts
{
    public interface ISatelliteDal
    {
        void Add(Satellite satellite);
        void Delete(int id);
        void Update(Satellite satellite);
        List<SatelliteDTO> GetAll();
        SatelliteDTO GetById(int id);
        List<SatelliteDTO> Pagination(int pageNumber, int pageSize);
        List<SatelliteDTO> FilterByTemperature(int temperature);
        List<SatelliteDTO> SortByNameAsc();
        List<SatelliteDTO> SortByNameDesc();
    }
}

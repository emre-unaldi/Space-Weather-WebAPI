using Core.Results;
using Entity.DTO;

namespace Business.Abstracts
{
    public interface IPlanetService
    {
        IResult Add(PlanetDTO planetDTO);
        IResult Delete(int id);
        IResult Update(PlanetDTO planetDTO);
        IDataResult<List<PlanetDTO>> GetAll();
        IDataResult<PlanetDTO> GetById(int id);
        IDataResult<List<PlanetDTO>> Pagination(int pageNumber, int pageSize);
        IDataResult<List<PlanetDTO>> FilterByTemperature(int temperature);
        IDataResult<List<PlanetDTO>> SortByNameAsc();
        IDataResult<List<PlanetDTO>> SortByNameDesc();
    }
}

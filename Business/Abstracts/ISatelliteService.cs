using Core.Results;
using Entity.DTO;
using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface ISatelliteService
    {
        IResult Add(Satellite satellite);
        IResult Delete(int id);
        IResult Update(Satellite satellite);
        IDataResult<List<SatelliteDTO>> GetAll();
        IDataResult<SatelliteDTO> GetById(int id);
        IDataResult<List<SatelliteDTO>> Pagination(int pageNumber, int pageSize);
        IDataResult<List<SatelliteDTO>> FilterByTemperature(int temperature);
        IDataResult<List<SatelliteDTO>> SortByNameAsc();
        IDataResult<List<SatelliteDTO>> SortByNameDesc();
    }
}

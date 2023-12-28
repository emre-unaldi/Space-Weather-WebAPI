using Business.Abstracts;
using Core.Results;
using DataAccess.Abstracts;
using Entity.DTO;
using Entity.Entities;

namespace Business.Concretes
{
    public class SatelliteManager : ISatelliteService
    {
        private ISatelliteDal _satelliteDal;

        public SatelliteManager(ISatelliteDal satelliteDal)
        {
            _satelliteDal = satelliteDal;
        }

        public IResult Add(Satellite satellite)
        {
            try
            {
                SatelliteDTO satellites = _satelliteDal.GetById(satellite.Id);

                if (satellite is not null)
                {
                    return new ErrorResult("Bu id ile bir uydu bulunmaktadır!!!");
                }
                else
                {
                    _satelliteDal.Add(satellite);
                    return new SuccessResult("Uydu eklendi.");
                }
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }

        public IResult Delete(int id)
        {
            try
            {
                SatelliteDTO satellite = _satelliteDal.GetById(id);

                if (satellite == null)
                    throw new Exception("Bu id ile bir uydu bulunmamaktadır!!!");

                _satelliteDal.Delete(id);
                return new SuccessResult("Uydu silindi.");
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }

        public IResult Update(Satellite satellite)
        {
            try
            {
                _satelliteDal.Update(satellite);
                return new SuccessResult("Uydu güncellendi.");
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }

        public IDataResult<List<SatelliteDTO>> GetAll()
        {
            try
            {
                return new SuccessDataResult<List<SatelliteDTO>>(_satelliteDal.GetAll(), "Uydular listelendi.");

            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<SatelliteDTO>>(ex.Message);
            }
        }

        public IDataResult<SatelliteDTO> GetById(int id)
        {
            try
            {
                SatelliteDTO satellite = _satelliteDal.GetById(id);

                if (satellite == null)
                    throw new Exception("Bu id ile bir uydu bulunmamaktadır!!!");

                return new SuccessDataResult<SatelliteDTO>(_satelliteDal.GetById(id), "Uydu listelendi.");
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<SatelliteDTO>(ex.Message);
            }
        }

        public IDataResult<List<SatelliteDTO>> Pagination(int pageNumber, int pageSize)
        {
            try
            {
                return new SuccessDataResult<List<SatelliteDTO>>(_satelliteDal.Pagination(pageNumber, pageSize), "Uydular sayfalandı.");

            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<SatelliteDTO>>(ex.Message);
            }
        }
        public IDataResult<List<SatelliteDTO>> FilterByTemperature(int temperature)
        {
            try
            {
                return new SuccessDataResult<List<SatelliteDTO>>(_satelliteDal.FilterByTemperature(temperature), "Uydular filtrelendi.");
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<SatelliteDTO>>(ex.Message);
            }
        }

        public IDataResult<List<SatelliteDTO>> SortByNameAsc()
        {
            try
            {
                return new SuccessDataResult<List<SatelliteDTO>>(_satelliteDal.SortByNameAsc(), "Uydular ascending olarak sıralandı.");

            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<SatelliteDTO>>(ex.Message);
            }
        }

        public IDataResult<List<SatelliteDTO>> SortByNameDesc()
        {
            try
            {
                return new SuccessDataResult<List<SatelliteDTO>>(_satelliteDal.SortByNameDesc(), "Uydular descending olarak sıralandı.");
            }
            catch (Exception ex)
            {

                return new ErrorDataResult<List<SatelliteDTO>>(ex.Message);
            }
        }
    }
}

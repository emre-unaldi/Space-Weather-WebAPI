using Business.Abstracts;
using Core.Results;
using DataAccess.Abstracts;
using Entity.DTO;

namespace Business.Concretes
{
    public class PlanetManager : IPlanetService
    {
        IPlanetDal _planetDal;

        public PlanetManager(IPlanetDal planetDal)
        {
            _planetDal = planetDal;
        }

        public IResult Add(PlanetDTO planetDTO)
        {
            try
            {
                PlanetDTO planet = _planetDal.GetById(planetDTO.Id);

                if (planet is not null)
                {
                    return new ErrorResult("Bu id ile bir gezegen bulunmaktadır!!!");
                }
                else
                {
                    _planetDal.Add(planetDTO);
                    return new SuccessResult("Gezegen eklendi.");
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
                PlanetDTO planet = _planetDal.GetById(id);

                if (planet is null)
                    throw new Exception("Bu id ile bir gezegen bulunmamaktadır!!!");

                _planetDal.Delete(id);
                return new SuccessResult("Gezegen silindi.");
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }

        public IResult Update(PlanetDTO planetDTO)
        {
            try
            {
                _planetDal.Update(planetDTO);
                return new SuccessResult("Gezegen güncellendi.");
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }

        public IDataResult<List<PlanetDTO>> GetAll()
        {
            try
            {
                return new SuccessDataResult<List<PlanetDTO>>(_planetDal.GetAll(), "Gezegenler listelendi.");

            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<PlanetDTO>>(ex.Message);
            }
        }

        public IDataResult<PlanetDTO> GetById(int id)
        {
            try
            {
                PlanetDTO planet = _planetDal.GetById(id);

                if (planet is null)
                    throw new Exception("Bu id ile bir gezegen bulunmaktadır!!!");

                return new SuccessDataResult<PlanetDTO>(_planetDal.GetById(id), "Gezegen listelendi.");
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<PlanetDTO>(ex.Message);
            }
        }

        public IDataResult<List<PlanetDTO>> Pagination(int pageNumber, int pageSize)
        {
            try
            {
                return new SuccessDataResult<List<PlanetDTO>>(_planetDal.Pagination(pageNumber, pageSize), "Gezegenler sayfalandı.");

            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<PlanetDTO>>(ex.Message);
            }
        }
        public IDataResult<List<PlanetDTO>> FilterByTemperature(int temperature)
        {
            try
            {
                return new SuccessDataResult<List<PlanetDTO>>(_planetDal.FilterByTemperature(temperature), "Gezegenler filtrelendi.");
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<PlanetDTO>>(ex.Message);
            }
        }

        public IDataResult<List<PlanetDTO>> SortByNameAsc()
        {
            try
            {
                return new SuccessDataResult<List<PlanetDTO>>(_planetDal.SortByNameAsc(), "Gezegenler ascending olarak sıralandı.");

            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<PlanetDTO>>(ex.Message);
            }
        }

        public IDataResult<List<PlanetDTO>> SortByNameDesc()
        {
            try
            {
                return new SuccessDataResult<List<PlanetDTO>>(_planetDal.SortByNameDesc(), "Gezegenler descending olarak sıralandı.");
            }
            catch (Exception ex)
            {

                return new ErrorDataResult<List<PlanetDTO>>(ex.Message);
            }
        }
    }
}

using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface ICarDal : IEntityRepository<Car>
    {
        List<CarDetailDto> GetCarDetails();
        CarDetailDto GetCarDetailsById(int id);
        List<CarDetailDto> GetCarDetailsByBrandId(int id);
        List<CarDetailDto> GetCarDetailsByColorId(int id);
    }
}

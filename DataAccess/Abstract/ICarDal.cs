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
        List<CarDetailDto> GetCarDetailsByFilters(List<string> brandNames, List<string> colorNames, decimal? minPrice, decimal? maxPrice, string? minYear, string? maxYear);
    }
}

using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IDataResult<List<CarImage>> GetAll();
        IDataResult<CarImage> GetById(int id);
        IResult Add(AddCarImageDto addCarImageDto);
        IResult Update(UpdateCarImageDto updateCarImageDto);
        IResult Delete(CarImage carImage);
        IDataResult<List<CarImage>> GetCarImagesByCarId(int carId);
    }
}

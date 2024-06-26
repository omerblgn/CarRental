﻿using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.Business;
using Core.Utilities.FileOperations;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        IFileService _fileService;

        public CarImageManager(ICarImageDal carImageDal, IFileService fileService)
        {
            _carImageDal = carImageDal;
            _fileService = fileService;
        }

        [SecuredOperation("carimage.add,moderator,admin")]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(AddCarImageDto addCarImageDto)
        {
            var result = BusinessRules.Run(CheckIfCarImageCountOfCarCorrect(addCarImageDto.CarId, addCarImageDto.FormFiles.Count));
            if (result != null)
            {
                return result;
            }

            foreach (var formFile in addCarImageDto.FormFiles)
            {
                string uploadPath = _fileService.Add(formFile, CreatePath(formFile));

                var carImage = new CarImage
                {
                    CarId = addCarImageDto.CarId,
                    ImagePath = uploadPath,
                    Date = DateTime.Now
                };

                _carImageDal.Add(carImage);
            }


            return new SuccessResult(Messages.CarImageAdded);
        }

        [SecuredOperation("carimage.delete,moderator,admin")]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Delete(CarImage carImage)
        {
            _fileService.Delete(carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.CarImageDeleted);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.Id == id));
        }

        public IDataResult<List<CarImage>> GetCarImagesByCarId(int carId)
        {
            var images = _carImageDal.GetAll(c => c.CarId == carId);
            if (images.Count == 0)
            {
                return new SuccessDataResult<List<CarImage>>(CreateDefaultCarImage(carId));
            }

            return new SuccessDataResult<List<CarImage>>(images);
        }

        [SecuredOperation("carimage.update,moderator,admin")]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(UpdateCarImageDto updateCarImageDto)
        {
            var updatedCarImage = _carImageDal.Get(c => c.Id == updateCarImageDto.Id);
            var newPath = _fileService.Update(updatedCarImage.ImagePath, updateCarImageDto.formFile, CreatePath(updateCarImageDto.formFile));

            updatedCarImage.CarId = updateCarImageDto.CarId;
            updatedCarImage.ImagePath = newPath;
            updatedCarImage.Date = DateTime.Now;

            _carImageDal.Update(updatedCarImage);
            return new SuccessResult(Messages.CarImageUpdated);
        }

        private IResult CheckIfCarImageCountOfCarCorrect(int carId, int addedImageCount)
        {
            var currentImageCount = _carImageDal.GetAll(c => c.CarId == carId).Count;
            var totalImageCount = currentImageCount + addedImageCount;
            if (totalImageCount > 5)
            {
                return new ErrorResult(Messages.CarImageCountOfCarError);
            }
            return new SuccessResult();
        }

        private static string CreatePath(IFormFile formFile)
        {
            var fileInfo = new FileInfo(formFile.FileName);
            string uploadPath = Path.Combine($@"wwwroot\Images\CarImages\{Guid.NewGuid()}{fileInfo.Extension}");
            return uploadPath;
        }

        private List<CarImage> CreateDefaultCarImage(int carId)
        {
            var defaultImage = new List<CarImage>
            {
                new CarImage {
                    CarId = carId,
                    ImagePath = Path.Combine(@"wwwroot\Images\CarImages\defaultCarImage.jpeg"),
                    Date = DateTime.Now
                }
            };
            return defaultImage;
        }
    }
}

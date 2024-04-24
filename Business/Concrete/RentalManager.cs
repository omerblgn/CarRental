using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        [SecuredOperation("rental.add,moderator,admin,user")]
        public IResult Add(Rental rental)
        {
            var result = BusinessRules.Run(IsRentable(rental));
            if (result != null)
            {
                return result;
            }

            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);
        }

        [SecuredOperation("rental.delete,moderator,admin")]
        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<Rental> GetById(int id)
        {
            var rental = _rentalDal.Get(r => r.Id == id);
            if (rental == null)
            {
                return new ErrorDataResult<Rental>(Messages.RentalNotFoundWithId);
            }
            return new SuccessDataResult<Rental>(rental);
        }

        public IDataResult<List<RentalDetailDto>> GetRentalsDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails());
        }

        public IResult IsRentable(Rental rental)
        {
            var rentalsOfCustomer = _rentalDal.GetAll(r => r.CustomerId == rental.CustomerId);
            if (rentalsOfCustomer.Any(r => r.ReturnDate == null || r.ReturnDate > DateTime.Now))
            {
                return new ErrorResult(Messages.CustomerHasUnreturnedCar);
            }

            var carToRent = _rentalDal.GetAll(r => r.CarId == rental.CarId);
            if (carToRent.Any(r => r.RentEndDate >= rental.RentStartDate && r.RentStartDate <= rental.RentEndDate))
            {
                return new ErrorResult(Messages.CarAlreadyRented);
            }

            return new SuccessResult();
        }

        public IResult ReturnCar(Rental rental)
        {
            var rentalToReturn = _rentalDal.Get(r => r.Id == rental.Id);
            if (rentalToReturn == null)
            {
                return new ErrorResult(Messages.RentalNotFound);
            }

            rentalToReturn.ReturnDate = DateTime.Now;

            _rentalDal.Update(rentalToReturn);
            return new SuccessResult(Messages.RentalReturn);
        }

        [SecuredOperation("rental.update,moderator,admin")]
        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }
    }
}

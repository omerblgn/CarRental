﻿using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
            var customerToRent = _rentalDal.Get(r => r.CustomerId == rental.CustomerId);
            if (customerToRent != null)
            {
                return new ErrorResult(Messages.RentalCustomerExist);
            }

            var rentalToAdd = _rentalDal.Get(r => r.CarId == rental.CarId);
            if (rentalToAdd != null)
            {
                return new ErrorResult(Messages.RentalExist);
            }

            rental.RentDate = DateTime.Now;
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);
        }

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

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }
    }
}

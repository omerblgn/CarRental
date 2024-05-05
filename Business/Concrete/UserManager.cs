using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using DataAccess.Abstract;
using Entities.DTOs;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        ICustomerService _customerService;

        public UserManager(IUserDal userDal, ICustomerService customerService)
        {
            _userDal = userDal;
            _customerService = customerService;
        }

        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }

        [SecuredOperation("user.delete,moderator,admin")]
        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }

        public IDataResult<User> GetByEmail(string email)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Email == email));
        }

        public IDataResult<UserDetailDto> GetUserDetailByEmail(string email)
        {
            return new SuccessDataResult<UserDetailDto>(_userDal.GetUserDetailByEmail(email));
        }

        public IResult UpdateUserDetail(UserDetailForUpdateDto user)
        {
            var updatedUser = _userDal.Get(u => u.Id == user.UserId);
            updatedUser.FirstName = user.FirstName;
            updatedUser.LastName = user.LastName;

            if (!string.IsNullOrEmpty(user.Password))
            {
                byte[] passwordHash, passwordSalt;
                HashingHelper.CreatePasswordHash(user.Password, out passwordHash, out passwordSalt);
                updatedUser.PasswordHash = passwordHash;
                updatedUser.PasswordSalt = passwordSalt;
            }
            _userDal.Update(updatedUser);

            var updatedCustomer = _customerService.GetById(user.CustomerId).Data;
            updatedCustomer.CompanyName = user.CompanyName;

            _customerService.Update(updatedCustomer);
            return new SuccessResult(Messages.UserUpdated);
        }

        public IDataResult<User> GetById(int id)
        {
            var user = _userDal.Get(u => u.Id == id);
            if (user == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFoundWithId);
            }
            return new SuccessDataResult<User>(user);
        }

        public IDataResult<List<OperationClaim>> GetClaims(int userId)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(userId));
        }

        [SecuredOperation("user.update,moderator,admin")]
        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.UserUpdated);
        }
    }
}

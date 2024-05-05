using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, CarRentalContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(int userId)
        {
            using (var context = new CarRentalContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                             on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == userId
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();
            }
        }

        public UserDetailDto GetUserDetailByEmail(string email)
        {
            using (var context = new CarRentalContext())
            {
                var result = from u in context.Users
                             join c in context.Customers on u.Id equals c.UserId
                             where u.Email == email
                             select new UserDetailDto
                             {
                                 UserId = u.Id,
                                 CompanyName = c.CompanyName,
                                 CustomerId = c.Id,
                                 Email = u.Email,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName
                             };
                return result.First();
            }
        }
    }
}

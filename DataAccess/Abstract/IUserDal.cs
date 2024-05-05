﻿using Core.DataAccess;
using Core.Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        List<OperationClaim> GetClaims(int userId);
        UserDetailDto GetUserDetailByEmail(string email);
    }
}

using System;
using System.Collections.Generic;
using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, NorthwindContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new NorthwindContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                                 on operationClaim.OperationId equals userOperationClaim.OperationId
                             where userOperationClaim.UserId == user.UserId
                             select new OperationClaim { OperationId = operationClaim.OperationId, OperationName = operationClaim.OperationName };
                return result.ToList();

            }
        }
    }
}

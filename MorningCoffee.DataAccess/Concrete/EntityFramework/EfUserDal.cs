using MorningCoffee.Core.DataAccess.EntityFramework;
using MorningCoffee.Core.Entities.Concrete;
using MorningCoffee.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MorningCoffee.DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, MorningCoffeeContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (MorningCoffeeContext context = new MorningCoffeeContext())
            {
                var result = from userOperationClaims in context.UserOperationClaims
                             join operationClaim in context.OperationClaims
                             on userOperationClaims.OperationClaimId equals operationClaim.Id
                             where userOperationClaims.UserId == user.Id
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();
            }
        }
    }
}

using MorningCoffee.Core.DataAccess;
using MorningCoffee.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace MorningCoffee.DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        List<OperationClaim> GetClaims(User user);
    }
}

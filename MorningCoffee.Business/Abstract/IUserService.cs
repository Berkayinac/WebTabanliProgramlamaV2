using MorningCoffee.Core.Entities.Concrete;
using MorningCoffee.Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace MorningCoffee.Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<User>> GetAll();
        IDataResult<List<User>> GetAllByName(string name);
        IDataResult<User> GetByEmail(string email);
        IResult Add(User user);
        IResult Update(User user);
        IResult Delete(User user);
        IDataResult<List<OperationClaim>> GetClaims(User user);
    }
}

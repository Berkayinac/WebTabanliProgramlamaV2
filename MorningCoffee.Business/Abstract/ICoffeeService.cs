using MorningCoffee.Core.Utilities.Results;
using MorningCoffee.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace MorningCoffee.Business.Abstract
{
    public interface ICoffeeService
    {
        IDataResult<List<Coffee>> GetAll();
        IDataResult<List<Coffee>> GetAllByHotCoffeeId(int hotCoffeeId);
        IDataResult<Coffee> GetByName(string name);
        IResult Add(Coffee coffee);
        IResult Delete(Coffee coffee);
        IResult Update(Coffee coffee);
    }
}

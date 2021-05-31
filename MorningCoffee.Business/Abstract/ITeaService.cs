using MorningCoffee.Core.Utilities.Results;
using MorningCoffee.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace MorningCoffee.Business.Abstract
{
    public interface ITeaService
    {
        IDataResult<List<Tea>> GetAll();
        IDataResult<List<Tea>> GetAllByIcedTeaId(int icedTeaId);
        IDataResult<Tea> GetByName(string name);
        IResult Add(Tea tea);
        IResult Delete(Tea tea);
        IResult Update(Tea tea);
    }
}

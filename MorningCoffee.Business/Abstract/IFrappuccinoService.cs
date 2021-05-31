using MorningCoffee.Core.Utilities.Results;
using MorningCoffee.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace MorningCoffee.Business.Abstract
{
    public interface IFrappuccinoService
    {
        IDataResult<List<Frappuccino>> GetAll();
        IDataResult<List<Frappuccino>> GetAllByFrappuccinoBlendedBeverageId(int frappuccinoBlendedBeverageId);
        IDataResult<Frappuccino> GetByName(string name);
        IResult Add(Frappuccino frappuccino);
        IResult Delete(Frappuccino frappuccino);
        IResult Update(Frappuccino frappuccino);
    }
}

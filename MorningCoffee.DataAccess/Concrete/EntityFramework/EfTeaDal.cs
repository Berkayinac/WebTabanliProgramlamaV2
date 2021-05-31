using MorningCoffee.Core.DataAccess.EntityFramework;
using MorningCoffee.DataAccess.Abstract;
using MorningCoffee.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace MorningCoffee.DataAccess.Concrete.EntityFramework
{
    public class EfTeaDal : EfEntityRepositoryBase<Tea, MorningCoffeeContext>, ITeaDal
    {
    }
}

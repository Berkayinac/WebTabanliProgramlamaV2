using MorningCoffee.Core.DataAccess;
using MorningCoffee.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace MorningCoffee.DataAccess.Abstract
{
    public interface ITeaDal : IEntityRepository<Tea>
    {
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace MorningCoffee.Core.Utilities.Results
{
    public interface IDataResult<T> : IResult
    {
         T Data { get; }
    }
}

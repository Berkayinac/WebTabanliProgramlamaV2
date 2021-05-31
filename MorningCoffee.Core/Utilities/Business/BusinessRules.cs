using MorningCoffee.Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace MorningCoffee.Core.Utilities.Business
{
    public class BusinessRules
    {
        public static IResult Run(params IResult[] results)
        {
            foreach (var result in results)
            {
                if (!result.Success)
                {
                    return new ErrorResult(result.Message);
                }
            }
            return null;
        }
    }
}

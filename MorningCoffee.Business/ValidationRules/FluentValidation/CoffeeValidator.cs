using FluentValidation;
using MorningCoffee.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace MorningCoffee.Business.ValidationRules.FluentValidation
{
    public class CoffeeValidator : AbstractValidator<Coffee>
    {
        public CoffeeValidator()
        {
            RuleFor(c => c.Name).MinimumLength(3);
            RuleFor(c => c.UnitPrice).GreaterThanOrEqualTo(10);
        }
    }
}

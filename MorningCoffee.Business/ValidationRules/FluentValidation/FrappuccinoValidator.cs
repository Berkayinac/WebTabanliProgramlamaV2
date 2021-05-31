using FluentValidation;
using MorningCoffee.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace MorningCoffee.Business.ValidationRules.FluentValidation
{
    public class FrappuccinoValidator : AbstractValidator<Frappuccino>
    {
        public FrappuccinoValidator()
        {
            RuleFor(c => c.Name).MinimumLength(3);
            RuleFor(c => c.UnitPrice).GreaterThanOrEqualTo(10);
        }
    }
}

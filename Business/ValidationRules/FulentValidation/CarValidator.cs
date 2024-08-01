using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FulentValidation
{
    public class CarValidator:AbstractValidator<Car>
    {

        public CarValidator()
        {
            RuleFor(p=> p.Description).NotEmpty();
            RuleFor(p => p.Description).MinimumLength(2);
            RuleFor(p=> p.Description).MaximumLength(20);
            RuleFor(p=> p.DailyPrice).NotEmpty();
            RuleFor(p => p.DailyPrice).LessThanOrEqualTo(10000);
            RuleFor(p=> p.ModelYear).NotEmpty();
            RuleFor(p => p.ModelYear).GreaterThanOrEqualTo(2005).When(p=> p.BrandId==1);

        }

    }
}

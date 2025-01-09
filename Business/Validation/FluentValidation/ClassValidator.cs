using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validation.FluentValidation
{
    public class ClassValidator : AbstractValidator<Class>
    {
        public ClassValidator()
        {
            RuleFor(c => c.Grade).NotEmpty();
            RuleFor(c => c.Letter).NotEmpty();
            RuleFor(c => c.Letter).Length(1);
        }
    }
}

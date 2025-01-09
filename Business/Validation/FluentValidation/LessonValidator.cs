using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validation.FluentValidation
{
    public class LessonValidator : AbstractValidator<Lesson>
    {
        public LessonValidator()
        {
            RuleFor(l=>l.Name).NotEmpty();
            //RuleFor(l => l.Name).MinimumLength(5).MaximumLength(50);
            //RuleFor(l=>l.Description).MinimumLength(15).MaximumLength(360);
        }
    }
}

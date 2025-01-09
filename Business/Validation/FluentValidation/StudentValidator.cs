using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validation.FluentValidation
{
    class StudentValidator : AbstractValidator<Student>
    {
        public StudentValidator()
        {
            RuleFor(s => s.FirstName).NotEmpty();
            RuleFor(s => s.LastName).NotEmpty();
            RuleFor(s => s.StudentNumber).Length(8);
            RuleFor(s => s.ClassId).NotEmpty();

        }
    }
}


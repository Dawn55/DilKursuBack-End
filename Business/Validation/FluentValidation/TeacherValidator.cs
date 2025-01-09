using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validation.FluentValidation
{
    public class TeacherValidator : AbstractValidator<Teacher>
    {

        public TeacherValidator()
        {
            RuleFor(t => t.FirstName).NotEmpty();
            RuleFor(t => t.LastName).NotEmpty();
            RuleFor(t => t.TeacherNumber).Length(8);
            
        }
    }
}

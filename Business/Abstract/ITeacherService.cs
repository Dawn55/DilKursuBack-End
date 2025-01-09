using Core.Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ITeacherService : IEntityService<Teacher>
    {
        IResult AddTeachWithUser(TeachWithUser teachWithUser);
    }
}

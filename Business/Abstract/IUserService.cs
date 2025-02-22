﻿using Core.Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
   public interface IUserService : IEntityService<User>
    {
        IDataResult<User> getUser(string email,string password);
    }
}

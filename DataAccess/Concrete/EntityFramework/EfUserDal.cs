using Core.DataAccess;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfBaseRepository<User, LanguageCourseContext>, IUserDal
    {
        public User getUser(User user)
        {
            return Get(u => u.Email == user.Email && u.Password == user.Password);
        }
    }
}

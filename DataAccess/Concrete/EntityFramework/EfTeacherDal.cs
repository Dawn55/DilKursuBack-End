using Core.DataAccess;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfTeacherDal : EfBaseRepository<Teacher, LanguageCourseContext>, ITeacherDal
    {
        IUserDal _userDal;
        public EfTeacherDal(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public void AddTeachWithUser(TeachWithUser teachWithUser)
        {
            _userDal.Add(new User { UserName = teachWithUser.UserName, Email = teachWithUser.Email, Password = teachWithUser.Password });
            var user = _userDal.Get(u => u.UserName == teachWithUser.UserName && u.Email == teachWithUser.Email && u.Password == teachWithUser.Password);
            Add(new Teacher
            {
                UserId = user.Id,
                FirstName = teachWithUser.FirstName,
                LastName = teachWithUser.LastName,
                TeacherNumber = teachWithUser.TeacherNumber
            });
        }
    }
}

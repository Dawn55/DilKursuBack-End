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
    public class EfStudentDal : EfBaseRepository<Student, LanguageCourseContext>, IStudentDal
    {
        IUserDal _userDal;
        public EfStudentDal(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public void AddStuWithUser(StuWithUser stuWithUser)
        {
            _userDal.Add(new User { UserName = stuWithUser.UserName, Email = stuWithUser.Email, Password = stuWithUser.Password });
            var user = _userDal.Get(u => u.UserName == stuWithUser.UserName && u.Email == stuWithUser.Email && u.Password == stuWithUser.Password);
            Add(new Student
            {
                UserId = user.Id,
                FirstName = stuWithUser.FirstName,
                LastName = stuWithUser.LastName,
                StudentNumber = stuWithUser.StudentNumber,
                ClassId = stuWithUser.ClassId
            });
        }
    }
}

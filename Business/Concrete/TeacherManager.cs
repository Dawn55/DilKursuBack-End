using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class TeacherManager : ITeacherService
    {
        ITeacherDal _teacherDal;
        public TeacherManager(ITeacherDal teacherDal)
        {
            _teacherDal = teacherDal;
        }
        public IResult Add(Teacher t)
        {
            _teacherDal.Add(t);
            return new SuccessResult("ÖğrenciEklendi");
        }

        public IResult AddTeachWithUser(TeachWithUser teachWithUser)
        {
            _teacherDal.AddTeachWithUser(teachWithUser);
            return new SuccessResult("Öğretmen Eklendi ve kullanıcı eklendi");
        }

        public IResult Delete(Teacher t)
        {
            _teacherDal.Delete(t.Id);
            return new SuccessResult("Öğrenci Silindi");
        }

        public IDataResult<List<Teacher>> GetAll()
        {
            return new SuccessDataResult<List<Teacher>>(_teacherDal.GetAll(), "Öğrenciler Listelendi");
        }

        public IDataResult<Teacher> GetById(int id)
        {
            return new SuccessDataResult<Teacher>(_teacherDal.Get(s => s.Id == id), "Öğrenci Bulundu");
        }

        public IResult Update(Teacher t)
        {
            _teacherDal.Update(t);
            return new SuccessResult(Messages.LessonUpdate);
        }
    }
}

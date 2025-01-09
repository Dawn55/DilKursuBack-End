using Business.Abstract;
using Business.Validation.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class StudentManager : IStudentService
    {
        IStudentDal _studentDal;

        public StudentManager(IStudentDal studentDal) 
        {
            _studentDal = studentDal;

        }
        [ValidationAspect(typeof(StudentValidator))]
        public IResult Add(Student t)
        {
            _studentDal.Add(t);
            return new SuccessResult("ÖğrenciEklendi");
        }
        

        public IResult AddStuWithUser(StuWithUser stuWithUser)
        {
            _studentDal.AddStuWithUser(stuWithUser);
            return new SuccessResult("Öğrenci ve Kullanıcı Eklendi");
        }

        [ValidationAspect(typeof(StudentValidator))]
        public IResult Delete(Student t)
        {
            _studentDal.Delete(t.Id);
            return new SuccessResult("Öğrenci Silindi");
        }

        public IDataResult<List<Student>> GetAll()
        {
             return new SuccessDataResult<List<Student>>(_studentDal.GetAll(), "Öğrenciler Listelendi");
        }

        public IDataResult<Student> GetById(int id)
        {
            return new SuccessDataResult<Student>(_studentDal.Get(s => s.Id == id), "Öğrenci Bulundu");
        }

        [ValidationAspect(typeof(StudentValidator))]
        public IResult Update(Student t)
        {
            _studentDal.Update(t);
            return new SuccessResult("Öğrenci Güncellendi");
        }
    }
}

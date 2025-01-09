using Business.Abstract;
using Business.Constants;
using Business.Validation.FluentValidation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Core.Aspects.Autofac.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Business;

namespace Business.Concrete
{
    public class LessonManager:ILessonService
    {
        private readonly ILessonDal lessonDal;
        public LessonManager(ILessonDal lessonDal) {
            this.lessonDal = lessonDal;
        }

        [ValidationAspect(typeof(LessonValidator))]
        public IResult Add(Lesson lesson)
        {
           var result = BusinessRules.Run(ChechifLessonNameExist(lesson.Name));
            if (result == null) {
                lessonDal.Add(lesson);
                return new SuccessResult(Messages.LessonAdded);

            }
            return result;
            
        }

        [ValidationAspect(typeof(LessonValidator))]
        public IResult Delete(Lesson lesson)
        {
            lessonDal.Delete(lesson.Id);
            return  new SuccessResult(Messages.LessonDeleted);
        }

        public IDataResult<List<Lesson>> GetAll()
        {
            List<Lesson> list = lessonDal.GetAll();
            return new SuccessDataResult<List<Lesson>>(list, Messages.LessonsListed);
        }

        public IDataResult<Lesson> GetById(int id)
        {
            var data = lessonDal.Get(l => l.Id == id);
            if (data == null)
            {
                return new ErrorDataResult<Lesson>(Messages.LessonNotFound);
            }
            return new SuccessDataResult<Lesson>(data, Messages.LessonFound);
        }

        [ValidationAspect(typeof(LessonValidator))]
        public IResult Update(Lesson lesson)
        {
            lessonDal.Update(lesson);
            return new SuccessResult(Messages.LessonUpdate);
        }
        private IResult ChechifLessonNameExist(string name)
        {
            var lesson = lessonDal.Get(l=>l.Name == name);
            if (lesson == null)
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.LessonsAlreadyExist);
        }
    }
}

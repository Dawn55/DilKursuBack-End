using Business.Abstract;
using Business.Constants;
using Business.Validation.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ClassManager : IClassService
    {

        IClassDal _classDal;
        public ClassManager(IClassDal classDal)
        {
            _classDal = classDal;
        }

        [ValidationAspect(typeof(ClassValidator))]
        public IResult Add(Class t)
        {
            _classDal.Add(t);
            return new SuccessResult();
        }

        [ValidationAspect(typeof(ClassValidator))]
        public IResult Delete(Class t)
        {
            _classDal.Delete(t.Id);
            return new SuccessResult();
        }

        public IDataResult<List<Class>> GetAll()
        {
            return new SuccessDataResult<List<Class>>(_classDal.GetAll());
        }

        public IDataResult<Class> GetById(int id)
        {
            return new SuccessDataResult<Class>(_classDal.Get(s => s.Id == id));
        }

        [ValidationAspect(typeof(ClassValidator))] 
        public IResult Update(Class t)
        {
            _classDal.Update(t);
            return new SuccessResult(Messages.LessonUpdate);
        }
    }
}

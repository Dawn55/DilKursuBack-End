using Business.Abstract;
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
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        [ValidationAspect(typeof(UserValidator))]
        public IResult Add(User t)
        {
           _userDal.Add(t);
            return new SuccessResult();
        }

        public IResult Delete(User t)
        {
            _userDal.Delete(t.Id);
            return new SuccessResult();
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }

        public IDataResult<User> GetById(int id)
        {
            return new SuccessDataResult<User>(_userDal.Get(s => s.Id == id));
        }

        public IDataResult<User> getUser(string email, string password)
        {
            return new SuccessDataResult<User>(_userDal.getUser(new User { Email = email, Password = password }));
        }

        [ValidationAspect(typeof(UserValidator))]
        public IResult Update(User t)
        {
            _userDal.Update(t);
            return new SuccessResult();
        }
    }
}

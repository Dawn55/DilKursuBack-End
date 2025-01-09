using Core.Entities;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Business.Abstract
{
    public interface IEntityService<T> where T: class,IEntity,new()
    {
        IDataResult<List<T>> GetAll();
        IResult Add(T t);
        IDataResult<T> GetById(int id);
        IResult Delete(T t);
        IResult Update(T t);
    }
}

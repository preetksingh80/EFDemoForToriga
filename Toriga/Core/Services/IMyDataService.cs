using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.Entities;

namespace Core.Services
{
    public interface IMyDataService<T>:IDisposable
    {
        ICollection<T> Find(Expression<Func<T, bool>> where);
        ICollection<T> GetAll();
       

    }
}
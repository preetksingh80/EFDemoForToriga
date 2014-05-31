using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Services.EF.Implementations
{
    public class MyDataService<T>: IMyDataService<T> where T : class, new() 
    {
        private readonly DbContext _context;

        public MyDataService(DbContext context)
        {
          _context = context;
        }

        public ICollection<T> Find(Expression<Func<T, bool>> @where)
        {
            return _context.Set<T>().Where(@where).ToList();
        }

        public ICollection<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }


        public void Dispose()
        {
            if(_context.Database.Connection.State == ConnectionState.Open ){ _context.Database.Connection.Close();}
            _context.Dispose();
        }
    }
}

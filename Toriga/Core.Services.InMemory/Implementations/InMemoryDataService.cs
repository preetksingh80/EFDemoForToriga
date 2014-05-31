using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Services.InMemory.Implementations
{
   public class InMemoryDataService<T>: IMyDataService<T>
    {
        private readonly List<T> _dataSource;

        public InMemoryDataService(IEnumerable<T> dataToSeed )
        {
            _dataSource = dataToSeed.ToList();

        }
        

        public ICollection<T> Find(Expression<Func<T, bool>> @where)
        {
            return _dataSource.Where(@where.Compile()).ToList();
        }

        public ICollection<T> GetAll()
        {
            return _dataSource;
        }

       public void Dispose()
       {
           
       }
    }
}

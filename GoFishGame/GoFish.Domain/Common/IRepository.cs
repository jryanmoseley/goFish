using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFish.Domain.Common
{
    public interface IRepository<T>
    {
        void Save(T entity);
        IEnumerable<T> GetAll();
        T Get(string id);
    }
}

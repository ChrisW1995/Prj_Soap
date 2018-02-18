using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Soap.Interface
{
    interface ISetTimeRepository<TEntity> : IDisposable
        where TEntity : class
    {
        void DeleteList(IEnumerable<TEntity> instance);
        void SaveChanges();
    }
}

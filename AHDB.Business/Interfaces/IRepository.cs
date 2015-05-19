using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHDB.Business
{
    public interface IRepository<T>
    {
        string Create(T obj);
        T Retrieve(int key);
        void Update(T obj);
        void Delete(string key);
    }
}
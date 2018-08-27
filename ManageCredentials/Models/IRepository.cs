using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManageCredentials.Models
{
    public interface IRepository<T> where T : class
    {
        void Create(T obj);
        IEnumerable<T> GetAll();
        void Update(T businessLead);
        void Delete(int id);
        T Get(int id);
    }
}

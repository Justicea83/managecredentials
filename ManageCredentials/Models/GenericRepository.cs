using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManageCredentials.Models
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private readonly UserDbContext context;
        public GenericRepository(UserDbContext ctx)
        {
            context = ctx;
        }

        public void Create(T obj)
        {
            context.Add<T>(obj);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            context.Remove<T>(Get(id));
            context.SaveChanges();
        }

        public virtual T Get(int id)
        {
            return context.Set<T>().Find(id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return context.Set<T>();
        }

        public void Update(T obj)
        {
            context.Update<T>(obj);
            context.SaveChanges();
        }

        //public void Delete(int id)
        //{
        //    context.Remove(Get(id));
        //    context.SaveChanges();
        //}

        //public BusinessLead Get(int id)
        //{
        //    return context.Lead.Find(id);
        //}

        //public IEnumerable<BusinessLead> Getall()
        //{
        //    return context.Lead;
        //}

        //public void Update(BusinessLead businessLead)
        //{
        //    context.Update(businessLead);
        //    context.SaveChanges();
        //}
    }
}

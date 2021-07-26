using HogeSchoolPXL.Data.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HogeSchoolPXL.Data.Repositories.Concrete
{
    public class GenericRepository<TEntity, TContext> : IRepository<TEntity> where TEntity: class where TContext : DbContext, new()
    {
        public bool Create(TEntity entity)
        {
            using (var context =new TContext())
            {
                context.Set<TEntity>().Add(entity);
                return context.SaveChanges()>0;
            }                      
        }

        public void Delete(TEntity entity)
        {
            using (var context = new TContext())
            {
                context.Set<TEntity>().Remove(entity);
                var result =  context.SaveChanges();
               // return result > 0;
            }
        }

        public List<TEntity> GetAll()
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().ToList();               
            }
        }

        public TEntity GetById(int id)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().Find(id);
            }
        }

        public bool Update(TEntity entity)
        {
            using (var context = new TContext())
            {
                context.Entry(entity).State=EntityState.Modified;
                return context.SaveChanges() > 0;
            }
        }
    }
}

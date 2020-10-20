using Core.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infrastructure.EF
{
    
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;

        public Repository(DbContext context)
        {
            Context = context;

        }

        public TEntity Get(object id)
        {
            return Context.Set<TEntity>().Find(id);
        }
       

        public List<TEntity> GetAll()
        {
            return Context.Set<TEntity>().ToList();
        }

        

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where(predicate);
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().SingleOrDefault(predicate);
        }

        public void Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }

        public void AddRange(List<TEntity> entities)
        {
            Context.Set<TEntity>().AddRange(entities);
        }

        public void Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().RemoveRange(entities);
        }

        public IEnumerable<TEntity> ExecuteStored(string ProcedureName, object[] parameters)
        {
            for (int i = 0; i < parameters.Length; i++)
                ProcedureName += " @p" + i.ToString() + ",";
            ProcedureName = ProcedureName.Remove(ProcedureName.Length - 1, 1);
            return Context.Set<TEntity>().FromSqlRaw(ProcedureName, parameters);            
        }

       



        public void Update(TEntity obj)
        {
            Context.Set<TEntity>().Update(obj);
        }

        public void Delete(object id)
        {
            var obj = Get(id);
            Context.Set<TEntity>().Remove(obj);
        }

       

        List<TEntity> IRepository<TEntity>.Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where(predicate).ToList();
        }

        public T GetMax<T>(Expression<Func<TEntity, int>> expression)
        {
            if (Context.Set<TEntity>().Count() == 0)
                return (T)Convert.ChangeType(0, typeof(T));
            return (T)Convert.ChangeType(Context.Set<TEntity>().Max(expression), typeof(T));
        }

        public int GetCount()
        {
            return Context.Set<TEntity>().Count();
        }
    }

}

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.Contracts
{

    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get(object id);
        int GetCount();
        List<TEntity> GetAll();
        void Update(TEntity obj);
        void Delete(object id);
        List<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);
        void Add(TEntity entity);
        void AddRange(List<TEntity> entities);

        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
        IEnumerable<TEntity> ExecuteStored(string ProcedureName, object[] parameters);
        T GetMax<T>(Expression<Func<TEntity, int>> expression);
    }

   
}

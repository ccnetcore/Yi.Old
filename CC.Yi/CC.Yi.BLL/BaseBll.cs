using CC.Yi.IBLL;
using CC.Yi.IDAL;
using CC.Yi.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CC.Yi.BLL
{
    public class BaseBll<T> : IBaseBll<T> where T : class, new()
    {
        public IBaseDal<T> CurrentDal;
        public DbContext Db;
        public BaseBll(IBaseDal<T> cd, DataContext _Db)
        {
            CurrentDal = cd;
            Db = _Db;
        }

        public async Task<T> GetEntityById(int id)
        {
            return await CurrentDal.GetEntityById(id); 
        }


        public IQueryable<T> GetAllEntities() 
        {
            return CurrentDal.GetAllEntities();
        }

        public IQueryable<T> GetEntities(Expression<Func<T, bool>> whereLambda)
        {
            return CurrentDal.GetEntities(whereLambda);
        }

        public int GetCount(Expression<Func<T, bool>> whereLambda) //统计数量
        {
            return CurrentDal.GetCount(whereLambda);
        }

        public IQueryable<IGrouping<S, T>> GetGroup<S>(Expression<Func<T, bool>> whereLambda, Expression<Func<T, S>> groupByLambda) //分组
        {
            return CurrentDal.GetGroup(whereLambda, groupByLambda);

        }

        public IQueryable<T> GetPageEntities<S>(int pageSize, int pageIndex, out int total, Expression<Func<T, bool>> whereLambda, Expression<Func<T, S>> orderByLambda, bool isAsc)
        {
            return CurrentDal.GetPageEntities(pageSize, pageIndex, out total, whereLambda, orderByLambda, isAsc);
        }

        public T Add(T entity)
        {
          T entityData= CurrentDal.Add(entity);
            Db.SaveChanges();
            return entityData;
        }

        public bool Add(IEnumerable<T> entities)
        {
            CurrentDal.AddRange(entities);
            return Db.SaveChanges() > 0;
        }

        public bool Update(T entity)
        {
            CurrentDal.Update(entity);
            return Db.SaveChanges() > 0;
        }

        public bool Update(T entity, params string[] propertyNames)
        {
            CurrentDal.Update(entity,propertyNames);
            return Db.SaveChanges() > 0;
        }

        public bool Delete(T entity)
        {
            CurrentDal.Delete(entity);
            return Db.SaveChanges() > 0;
        }
        public bool Delete(int id)
        {
            CurrentDal.Detete(id);
            return Db.SaveChanges() > 0;
        }

        public bool Delete(IEnumerable<int> ids)
        {
            foreach (var id in ids)
            {
                CurrentDal.Detete(id);
            }
            return Db.SaveChanges()>0;
        }
        public bool Delete(Expression<Func<T, bool>> where)
        {
            IQueryable<T> entities =  CurrentDal.GetEntities(where);
            if (entities != null)
            {
                CurrentDal.DeteteRange(entities);

                return Db.SaveChanges()>0;
            }
            return false;
        }

    }
}

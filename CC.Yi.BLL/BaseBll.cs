using CC.Yi.DALFactory;
using CC.Yi.IBLL;
using CC.Yi.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CC.Yi.BLL
{
    public class BaseBll<T> : IBaseBll<T> where T : class, new()
    {
        public IBaseDal<T> CurrentDal;
        public BaseBll(IBaseDal<T> cd)
        {
            CurrentDal = cd;
        }
        //public abstract void SetCurrentDal();
        //public BaseBll()//基类的构造方法
        //{
        //    SetCurrentDal();//该方法由子类去实现
        //}

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
            CurrentDal.Add(entity);
            DbSession.SaveChanges();
            return entity;
        }

        public bool Update(T entity)
        {
            CurrentDal.Update(entity);
            return DbSession.SaveChanges() > 0;
        }

        public bool Delete(T entity)
        {
            CurrentDal.Delete(entity);
            return DbSession.SaveChanges() > 0;
        }
        public IDbSession DbSession
        {
            get
            {
                return DbSessionFactory.GetCurrentDbSession();
            }
        }
        public bool Delete(int id)
        {
            CurrentDal.Detete(id);
            return DbSession.SaveChanges() > 0;
        }

        public int DeleteList(List<int> ids)
        {
            foreach (var id in ids)
            {
                CurrentDal.Detete(id);
            }
            return DbSession.SaveChanges();//这里把SaveChanges方法提到了循环体外，自然就与数据库交互一次
        }

    }
}

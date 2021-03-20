using System;
using System.Linq;
using System.Linq.Expressions;

namespace CC.Yi.IDAL
{
    public interface IBaseDal<T> where T : class, new()
    {
        #region
        //得到全部实体
        #endregion
        IQueryable<T> GetAllEntities();

        #region
        //通过表达式得到实体
        #endregion
        IQueryable<T> GetEntities(Expression<Func<T, bool>> whereLambda);

        #region
        //通过表达式得到实体，分页版本
        #endregion
        IQueryable<T> GetPageEntities<S>(int pageSize, int pageIndex, out int total, Expression<Func<T, bool>> whereLambda, Expression<Func<T, S>> orderByLambda, bool isAsc);

        #region
        //通过表达式统计数量
        #endregion
        int GetCount(Expression<Func<T, bool>> whereLambda);

        #region
        //通过表达式分组
        #endregion
        IQueryable<IGrouping<S, T>> GetGroup<S>(Expression<Func<T, bool>> whereLambda, Expression<Func<T, S>> groupByLambda);

        #region
        //添加单个实体
        #endregion
        T Add(T entity);

        #region
        //更新单个实体
        #endregion
        bool Update(T entity);

        #region
        //删除单个实体
        #endregion
        bool Delete(T entity);

        #region
        //通过id删除实体
        #endregion
        bool Detete(int id);
    }
}

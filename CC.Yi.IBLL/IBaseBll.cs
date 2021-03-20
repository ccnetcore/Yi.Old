using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CC.Yi.IBLL
{
    public interface IBaseBll<T> where T : class, new()
    {
        IQueryable<T> GetEntities(Expression<Func<T, bool>> whereLambda);

        int GetCount(Expression<Func<T, bool>> whereLambda);//统计数量

        #region
        //分组
        #endregion
        IQueryable<IGrouping<S, T>> GetGroup<S>(Expression<Func<T, bool>> whereLambda, Expression<Func<T, S>> groupByLambda);

        IQueryable<T> GetPageEntities<S>(int pageSize, int pageIndex, out int total, Expression<Func<T, bool>> whereLambda, Expression<Func<T, S>> orderByLambda, bool isAsc);

        T Add(T entity);

        bool Update(T entity);

        bool Delete(T entity);
        bool Delete(int id);
        int DeleteList(List<int> ids);
    }
}

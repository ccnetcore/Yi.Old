using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Yi.Framework.Interface
{
    public interface IBaseService<T> where T : class, new()
    {
        #region
        //通过id得到实体
        #endregion
        Task<T> GetEntityById(int id);

        #region
        //通过表达式得到实体
        #endregion
        Task<T> GetEntity(Expression<Func<T, bool>> whereLambda);

        #region
        //得到全部实体
        #endregion
        Task<IEnumerable<T>> GetAllEntitiesAsync();

        #region
        //通过表达式得到实体
        #endregion
        Task<IEnumerable<T>> GetEntitiesAsync(Expression<Func<T, bool>> whereLambda);

        #region
        //通过表达式得到实体，分页版本
        #endregion
        Task<int> GetCountAsync(Expression<Func<T, bool>> whereLambda);

        #region
        //通过表达式统计数量
        #endregion
        IQueryable<IGrouping<S, T>> GetGroup<S>(Expression<Func<T, bool>> whereLambda, Expression<Func<T, S>> groupByLambda);

        #region
        //通过表达式分组
        #endregion
        Task<Tuple<IEnumerable<T>, int>> GetPageEntities<S>(int pageSize, int pageIndex, Expression<Func<T, bool>> whereLambda, Expression<Func<T, S>> orderByLambda, bool isAsc);

        #region
        //添加实体
        #endregion
        Task<bool> AddAsync(T entity);

        #region
        //添加多个实体
        #endregion
        Task<bool> AddAsync(IEnumerable<T> entities);

        #region
        //更新实体
        #endregion
        Task<bool> UpdateAsync(T entity);

        #region
        //更新多个实体
        #endregion
        Task<bool> UpdateListAsync(IEnumerable<T> entities);

        #region
        //更新实体部分属性
        #endregion
        Task<bool> DeleteAsync(T entity);

        #region
        //删除实体
        #endregion
        Task<bool> DeleteAsync(int id);

        #region
        //通过id删除实体
        #endregion
        Task<bool> DeleteAsync(IEnumerable<int> ids);

        #region
        //通过id列表删除多个实体
        #endregion
        Task<bool> DeleteAsync(Expression<Func<T, bool>> where);
    }
}

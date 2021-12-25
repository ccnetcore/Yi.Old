using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Yi.Framework.Common.Enum;
using Yi.Framework.Interface;
using Yi.Framework.Model.ModelFactory;

namespace Yi.Framework.Service
{
    public class BaseService<T> : IBaseService<T> where T : class, new()
    {
        public DbContext _Db;
        public DbContext _DbRead;
        public IDbContextFactory _DbFactory;
        public BaseService(IDbContextFactory DbFactory)
        {
            _DbFactory = DbFactory;
            _Db = DbFactory.ConnWriteOrRead(WriteAndReadEnum.Write);
            _DbRead = DbFactory.ConnWriteOrRead(WriteAndReadEnum.Read);
        }

        public async Task<T> GetEntityById(int id)
        {
            return await _Db.Set<T>().FindAsync(id);
        }


        public async Task<IEnumerable<T>> GetAllEntitiesAsync()
        {
            return await _Db.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetEntitiesAsync(Expression<Func<T, bool>> whereLambda)
        {
            return await _Db.Set<T>().Where(whereLambda).ToListAsync();
        }

        public async Task<int> GetCountAsync(Expression<Func<T, bool>> whereLambda) //统计数量
        {
            return await _Db.Set<T>().CountAsync(whereLambda);
        }

        public IQueryable<IGrouping<S, T>> GetGroup<S>(Expression<Func<T, bool>> whereLambda, Expression<Func<T, S>> groupByLambda) //分组
        {
            return _Db.Set<T>().Where(whereLambda).GroupBy(groupByLambda).AsQueryable();
        }

        public async Task<Tuple<IEnumerable<T>, int>> GetPageEntities<S>(int pageSize, int pageIndex, Expression<Func<T, bool>> whereLambda, Expression<Func<T, S>> orderByLambda, bool isAsc)
        {
            int total = await GetCountAsync(whereLambda);

            IEnumerable<T> pageData;
            if (isAsc)
            {
                pageData = await _Db.Set<T>().Where(whereLambda)
                              .OrderBy<T, S>(orderByLambda)
                              .Skip(pageSize * (pageIndex - 1))
                              .Take(pageSize).ToListAsync();
            }
            else
            {
                pageData = await _Db.Set<T>().Where(whereLambda)
                                  .OrderByDescending<T, S>(orderByLambda)
                                  .Skip(pageSize * (pageIndex - 1))
                                  .Take(pageSize).ToListAsync();
            }

            return Tuple.Create<IEnumerable<T>, int>(pageData, total);
        }

        public async Task<bool> AddAsync(T entity)
        {
            _Db.Set<T>().Add(entity);
            return await _Db.SaveChangesAsync() > 0;
        }

        public async Task<bool> AddAsync(IEnumerable<T> entities)
        {
            _Db.Set<T>().AddRange(entities);
            return await _Db.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            _Db.Set<T>().Update(entity);
            return await _Db.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateListAsync(IEnumerable<T> entities)
        {
            _Db.Set<T>().UpdateRange(entities);
            return await _Db.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            _Db.Set<T>().Remove(entity);
            return await _Db.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            _Db.Set<T>().Remove(await GetEntityById(id));
            return await _Db.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(IEnumerable<int> ids)
        {
            foreach (var id in ids)
            {
                _Db.Set<T>().RemoveRange(await GetEntityById(id));
            }
            return await _Db.SaveChangesAsync() > 0;
        }
        public async Task<bool> DeleteAsync(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> entities = await GetEntitiesAsync(where);
            if (entities != null)
            {
                _Db.Set<T>().RemoveRange(entities);

                return await _Db.SaveChangesAsync() > 0;
            }
            return false;
        }

        public async Task<T> GetEntity(Expression<Func<T, bool>> whereLambda)
        {
          return await _Db.Set<T>().Where(whereLambda).FirstOrDefaultAsync();
        }
    }
}

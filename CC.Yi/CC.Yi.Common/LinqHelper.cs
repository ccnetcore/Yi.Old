using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace CC.Yi.Common
{
   public static class LinqHelper
    {
        //T是列表类型，S是排序的属性
        public static IQueryable GetPageEntities<T,S>(IQueryable<T> myData, int pageSize, int pageIndex, out int total, Expression<Func<T, bool>> whereLambda=null, Expression<Func<T, S>> orderByLambda=null, bool isAsc=false)
        {
            total = myData.Where(whereLambda).Count();
            if (isAsc)
            {
                var pageData = myData.Where(whereLambda)
                              .OrderBy<T,S>(orderByLambda)
                              .Skip(pageSize * (pageIndex - 1))
                              .Take(pageSize).AsQueryable();
                return pageData;
            }
            else
            {
                var pageData = myData.Where(whereLambda)
                                 .OrderByDescending<T, S>(orderByLambda)
                                 .Skip(pageSize * (pageIndex - 1))
                                 .Take(pageSize).AsQueryable();
                return pageData;
            }
        }
    }
}

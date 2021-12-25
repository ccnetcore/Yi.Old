using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Yi.Framework.Model.ModelFactory
{
    public static class DbContextExtend
    { 
        public static DbContext ToWriteOrRead(this DbContext dbContext, string conn)
        {
            if (dbContext is DataContext)
            {

                var context= (DataContext)dbContext; // context 是 EFCoreContext 实例；

                return context.ToWriteOrRead(conn);
            }
            else
                throw new Exception();
        }
    }
}

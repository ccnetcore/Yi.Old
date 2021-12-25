using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Yi.Framework.Common.Enum;

namespace Yi.Framework.Model.ModelFactory
{
    public  interface IDbContextFactory
    {
        public DbContext ConnWriteOrRead(WriteAndReadEnum writeAndRead);
    }
}

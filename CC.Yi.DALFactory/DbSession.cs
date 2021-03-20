using CC.Yi.DAL;
using CC.Yi.IDAL;
using CC.Yi.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace CC.Yi.DALFactory
{
    public partial class DbSession : IDbSession
    {
        public int SaveChanges()
        {
            return DbContentFactory.GetCurrentDbContent().SaveChanges();
        }
        public DataContext GetDbContent()
        {
            return DbContentFactory.GetCurrentDbContent();
        }

    }
}

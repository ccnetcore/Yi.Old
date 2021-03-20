using CC.Yi.DAL;
using CC.Yi.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CC.Yi.DALFactory
{
    public partial class DbSession : IDbSession
    {
        public IstudentDal studentDal
        {
            get { return StaticDalFactory.GetstudentDal(); }
        }

    }
}
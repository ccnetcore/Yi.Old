
using CC.Yi.IBLL;
using CC.Yi.IDAL;
using CC.Yi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CC.Yi.BLL
{
    public partial class studentBll : BaseBll<student>, IstudentBll
        {
            public studentBll(IBaseDal<student> cd,DataContext _Db):base(cd,_Db)
            {
                CurrentDal = cd;
                DbSession = _Db;
            }
        }
    public partial class propBll : BaseBll<prop>, IpropBll
        {
            public propBll(IBaseDal<prop> cd,DataContext _Db):base(cd,_Db)
            {
                CurrentDal = cd;
                DbSession = _Db;
            }
        }
}
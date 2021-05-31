using CC.Yi.IDAL;
using CC.Yi.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace CC.Yi.DAL
{
    public partial class studentDal : BaseDal<student>, IstudentDal
    {
        public studentDal(DataContext _Db):base(_Db)
        {
            Db = _Db;
        }
    }
    public partial class propDal : BaseDal<prop>, IpropDal
    {
        public propDal(DataContext _Db):base(_Db)
        {
            Db = _Db;
        }
    }
}
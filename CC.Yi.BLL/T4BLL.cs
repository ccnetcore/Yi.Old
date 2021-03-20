
using CC.Yi.IBLL;
using CC.Yi.IDAL;
using CC.Yi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CC.Yi.BLL
{
    public partial class studentBll : BaseBll<student>, IstudentBll
        {
            public studentBll(IBaseDal<student> cd):base(cd)
            {
                CurrentDal = cd;
            }
        }
}
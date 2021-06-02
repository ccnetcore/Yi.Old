using CC.Yi.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CC.Yi.IBLL
{
   public partial interface IstudentBll : IBaseBll<student>
    {
        Task<bool> DelListByUpdateList(List<int> Ids);
    }
}
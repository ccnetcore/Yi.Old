
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
                Db = _Db;
            }

            public async Task<bool> DelListByUpdateList(List<int> Ids)
            {
                var entitys = await CurrentDal.GetEntities(u => Ids.Contains(u.id)).ToListAsync();
                foreach (var entity in entitys)
                {
                    entity.is_delete = (short)ViewModel.Enum.DelFlagEnum.Deleted;
                }
                return Db.SaveChanges() > 0;
            }

        }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yi.Framework.Model.Models;

namespace Yi.Framework.Interface
{
   public interface IMouldService : IBaseService<mould> 
    {
        Task<bool> DelListByUpdateAsync(List<int> _ids);
        Task<IEnumerable<mould>> GetAllEntitiesTrueAsync();

        /// <summary>
        /// 得到该接口属于哪个菜单的
        /// </summary>
        /// <param name="_mould"></param>
        /// <returns></returns>
        Task<menu> GetMenuByMould(mould _mould);
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yi.Framework.Interface;
using Yi.Framework.Model.Models;

namespace Yi.Framework.Service
{
   public class LoopModelService:BaseService<loopModel>, ILoopModelService
    {
        public LoopModelService(DbContext Db) : base(Db)
        {
        }
        public async Task<bool> DelListByUpdateAsync(List<int> _ids)
        {
            var loopModelList = await GetEntitiesAsync(u => _ids.Contains(u.id));
            loopModelList.ToList().ForEach(u => u.is_delete = (short)Common.Enum.DelFlagEnum.Deleted);
            return await UpdateListAsync(loopModelList);
        }
        public async Task<IEnumerable<loopModel>> GetAllEntitiesTrueAsync()
        {
            return await GetEntitiesAsync(u => u.is_delete == (short)Common.Enum.DelFlagEnum.Normal);
        }
        public async Task<bool> AddEntitesAsync(List<loopModel> _loopModels)
        {
            _loopModels.ToList().ForEach(u => u.is_delete = (short)Common.Enum.DelFlagEnum.Normal);
            return await AddEntitesAsync(_loopModels);
        }
        public async Task<IEnumerable<loopModel>> GetEntitiesTrueByIdAsync(List<int> _ids)
        {
            return await GetEntitiesAsync(u => _ids.Contains(u.id));
        }
        public async Task<bool> UpdateEntitesAsync(List<loopModel> _loopModels)
        {
            return await UpdateEntitesAsync(_loopModels);
        }
    }
}

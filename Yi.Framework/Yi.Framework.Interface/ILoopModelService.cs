using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yi.Framework.Model.Models;

namespace Yi.Framework.Interface
{
   public interface ILoopModelService:IBaseService<loopModel>
    {
        Task<bool> DelListByUpdateAsync(List<int> _ids);
        Task<IEnumerable<loopModel>> GetAllEntitiesTrueAsync();
        Task<IEnumerable<loopModel>> GetEntitiesTrueByIdAsync(List<int> _ids);
        Task<bool> AddEntitesAsync(List<loopModel> _loopModels);
        Task<bool> UpdateEntitesAsync(List<loopModel> _loopModels);
    }
}

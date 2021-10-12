using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yi.Framework.Model.Models;

namespace Yi.Framework.Interface
{
   public interface IMouldService:IBaseService<mould>
    {
        Task<bool> DelListByUpdateAsync(List<int> _ids);
        Task<IEnumerable<mould>> GetAllEntitiesTrueAsync();
        Task<IEnumerable<mould>> GetEntitiesTrueByIdAsync(List<int> _ids);
        Task<bool> AddEntitesAsync(List<mould> _moulds);
        Task<bool> UpdateEntitesAsync(List<mould> _moulds);
    }
}

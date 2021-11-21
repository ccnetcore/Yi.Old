using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yi.Framework.DTOModel;
using Yi.Framework.Model.Models;

namespace Yi.Framework.Interface
{
    public partial interface IStockService:IBaseService<stock>
    {
        void ResumeStock(CartDto cartDtos, long orderId, object _cacheClientDB);
        void DecreaseStock(CartDto cartDtos, long orderId);
    }
}

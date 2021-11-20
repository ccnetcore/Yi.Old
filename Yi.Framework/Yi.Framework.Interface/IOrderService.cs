using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yi.Framework.DTOModel;
using Yi.Framework.Model.Models;

namespace Yi.Framework.Interface
{
    public partial interface IOrderService:IBaseService<order>
    {
        Task<order> CreateOrder(OrderDto orderDto,user _user);
    }
}

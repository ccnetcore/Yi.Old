using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yi.Framework.DTOModel
{
    /// <summary>
    /// 订单号+购物车实体集合
    /// </summary>
    public class OrderCartDto
    {
        public long OrderId { get; set; }
        public List<CartDto> Carts { get; set; }// 订单详情
    }
}

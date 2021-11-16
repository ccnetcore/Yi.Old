using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yi.Framework.DTOModel
{
    public class OrderDto
    {
        public long addressId { get; set; } // 收获人地址id
        public byte paymentType { get; set; }// 付款类型
        public List<CartDto> carts { get; set; }// 订单详情
    }
}

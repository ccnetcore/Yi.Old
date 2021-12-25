using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yi.Framework.Common.QueueModel
{
    /// <summary>
    /// 下单成功后的实体
    /// </summary>
    public class OrderCreateQueueModel
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        public long UserId { get; set; }
        /// <summary>
        /// 订单Id
        /// </summary>
        public long OrderId { get; set; }
        /// <summary>
        /// sku ID 集合
        /// </summary>
        public List<long> SkuIdList { get; set; }

        /// <summary>
        /// 尝试次数
        /// </summary>
        public int TryTime { get; set; }

        public OrderTypeEnum OrderType { get; set; }

        public enum OrderTypeEnum
        {
            Normal,
            Seckill
        }

    }
}

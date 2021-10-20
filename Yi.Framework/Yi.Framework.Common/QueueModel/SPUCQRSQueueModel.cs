using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yi.Framework.Common.QueueModel
{
    /// <summary>
    /// 以SPU为单位
    /// </summary>
    public class SPUCQRSQueueModel
    {
        public long SpuId { get; set; }

        /// <summary>
        /// enum SPUCQRSQueueModelType
        /// </summary>
        public int CQRSType { get; set; }
    }

    /// <summary>
    /// 操作类型
    /// </summary>
    public enum SPUCQRSQueueModelType
    {
        Insert = 0,
        Update = 1,
        Delete = 2,
        Search = 3
    }
}

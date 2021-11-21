using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yi.Framework.Common.Const
{
   public class RabbitConst
    {
        private const string prefix = "Yi.Framework.";
        public const  string SMS_Exchange = prefix+"SMS.Exchange";
        public const  string SMS_Queue_Send = prefix+ "SMS.Queue.Send";


        public const string GoodsWarmup_Exchange = prefix + "GoodsWarmup.Exchange";
        public const string GoodsWarmup_Queue_Send = prefix + "GoodsWarmup.Queue.Send";

        public const string PageWarmup_Exchange = prefix + "PageWarmup.Exchange";
        public const string PageWarmup_Queue_Send = prefix + "PageWarmup.Queue.Send";

        public const string Order_Stock_Decrease_Exchange = prefix + "Order_Stock_Decrease_Exchange";
        public const string Order_Stock_Decrease_Queue = prefix + "Order_Stock_Decrease_Queue";

        public const string Order_Stock_Resume_Exchange = prefix + "Order_Stock_Resume_Exchange";
        public const string Order_Stock_Resume_Queue = prefix + "Order_Stock_Resume_Queue";

        public const string OrderCreate_Delay_Exchange = prefix + "OrderCreate_Delay_Exchange";
        public const string OrderCreate_Delay_Queue = prefix + "OrderCreate_Delay_Queue";


        
    }
}

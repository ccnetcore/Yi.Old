using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yi.Framework.Model.Models
{
    public class order : baseModel<string>
    {
        [Comment("总金额，单位为分")]
        public double? total_pay { get; set; }
        [Comment("实付金额。单位:分。如:20007，表示:200元7分")]
        public double? actual_pay { get; set; }
        [Comment("支付类型，1、在线支付，2、货到付款")]
        public int payment_type { get; set; }
        [Comment("邮费。单位:分。如:20007，表示:200元7分")]
        public int? post_fee { get; set; }
        [Comment("promotion_ids")]
        public string promotion_ids { get; set; }
        [Comment("订单创建时间")]
        public DateTime creat_time { get; set; }
        [Comment("物流名称")]
        public string shipping_name { get; set; }
        [Comment("物流单号")]
        public string shipping_code { get; set; }
        [Comment("买家留言")]
        public string buyer_message { get; set; }
        [Comment("买家昵称")]
        public string buyer_nick { get; set; }
        [Comment("买家是否已经评价,0未评价，1已评价")]
        public int? buyer_rate { get; set; }
        [Comment("收获地址（省）")]
        public string receiver_state { get; set; }
        [Comment("收获地址（市）")]
        public string receiver_city { get; set; }
        [Comment("收获地址（区/县）")]
        public string receiver_district { get; set; }
        [Comment("收获地址（街道、住址等详细地址）")]
        public string receiver_address { get; set; }
        [Comment("收货人手机")]
        public string receiver_mobile { get; set; }
        [Comment("收货人邮编")]
        public string receiver_zip { get; set; }
        [Comment("收货人")]
        public string receiver { get; set; }
        [Comment("发票类型:0无发票1普通发票，2电子发票，3增值税发票")]
        public int? invoice_type { get; set; }
        [Comment("订单来源：1:app端，2：pc端，3：M端，4：微信端，5：手机qq端")]
        public int? source_type { get; set; }
        [Comment("sku")]
        public sku sku { get; set; }
    }
}

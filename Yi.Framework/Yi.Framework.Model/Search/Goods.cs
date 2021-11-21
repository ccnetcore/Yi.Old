using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yi.Framework.Model.Models;

namespace Yi.Framework.Model.Search
{
    [ElasticsearchType(IdProperty = "id")]//主键声明，且主键必须是属性
    public class Goods
    {
        public long id { get; set; } 
        public spu spu { get; set; }
        public string title;  //标题
        public DateTime? createTime;
        public List<sku> skus;  //sku信息的json结构数据
       
    }
}

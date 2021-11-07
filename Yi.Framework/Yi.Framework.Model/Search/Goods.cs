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
        public string all;  //所有需要被搜索的信息，包括品牌，分类，标题
        public string subtitle;  //子标题
        public brand brand;
        public category cid1;
        public category cid2;
        public category cid3;
        public DateTime? createTime;


        public HashSet<double> price = new HashSet<double>();  //是所有sku的价格集合。方便根据价格进行筛选过滤
        public List<sku> skus;  //sku信息的json结构数据
        public Dictionary<string, object> specs = new Dictionary<string, object>();  //可搜索的规格参数，key是参数名，值是参数值
    }
}

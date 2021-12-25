using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yi.Framework.Model.Search
{ 
    public class SearchRequest
    {
        public static readonly int DEFAULT_PAGE = 1;
        public static readonly int DEFAULT_SIZE = 20;
        public string key { get; set; }
        public int page { get; set; }
        //排序字段
        public string sortBy { get; set; }
        //是否降序
        public bool descending { get; set; }
        //过滤字段
        public Dictionary<string, string> filter = new Dictionary<string, string>();

        public int getPage()
        {
            if (page == 0)
            {
                return DEFAULT_PAGE;
            }
            // 获取页码时做一些校验，不能小于1
            return Math.Max(DEFAULT_PAGE, page);
        }

        public int getSize()
        {
            return DEFAULT_SIZE;
        }


    }
}

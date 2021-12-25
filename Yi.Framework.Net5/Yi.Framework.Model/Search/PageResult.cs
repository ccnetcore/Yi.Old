using System;
using System.Collections.Generic;
using System.Text;

namespace Yi.Framework.Model.Search
{
	public class  PageResult<T>
	{
        public static readonly long serialVersionUID = 4612105649493688532L;
        public long total; // 总记录数
        public int totalPages; //总页数
        public List<T> rows; // 每页显示的数据集合

        public PageResult(long total, List<T> rows)
        {
            this.total = total;
            this.rows = rows;
        }
    }
}

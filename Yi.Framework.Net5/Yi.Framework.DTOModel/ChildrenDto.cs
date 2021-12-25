using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yi.Framework.DTOModel
{
 public   class ChildrenDto<T>
    {
       public int parentId { get; set; }
        public T data { get; set; }
    }
}

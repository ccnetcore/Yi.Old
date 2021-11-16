using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yi.Framework.DTOModel
{
	public class CartDto
	{
		public long skuId { get; set; }//商品skuId
		public int num { get; set; } //购买数量
	}
}

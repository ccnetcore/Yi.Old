using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yi.Framework.Interface;
using Yi.Framework.Model.Models;
using Yi.Framework.Model.Search;

namespace Yi.Framework.Service
{
	
	public class PageDetailService : IPageDetailService
    {
		private IGoodsService _goodsService;
		public PageDetailService(IGoodsService goodsService)
		{
			_goodsService = goodsService;

		}
		public Goods loadModel(long spuId)
        {
		var data=_goodsService.QuerySpuByPage(1,1,"",1);
			return new Goods();
		}
    }
}

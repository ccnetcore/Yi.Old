//using CC.Yi.Common;
//using CC.Yi.IBLL;
//using CC.Yi.Model;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Logging;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace CC.Yi.API.Controllers
//{
//    [Route("[controller]/[action]")]
//    [ApiController]
//    public class PlateController : Controller
//    {
//        private IplateBll _plateBll;
//        private ILogger<PlateController> _logger;
//        short delFlagNormal = (short)ViewModel.Enum.DelFlagEnum.Normal;
//        public PlateController(IplateBll plateBll, ILogger<PlateController> logger)
//        {
//            _plateBll = plateBll;
//            _logger = logger;
//        }

//        [HttpGet]
//        public async Task<Result> GetPlates()
//        {
//            var data =await  _plateBll.GetEntities(u=>u.is_delete==delFlagNormal).AsNoTracking().ToListAsync();
//            return Result.Success().SetData(data);
//        }

//        [Authorize(Policy = "板块管理")]
//        [HttpPost]
//        public Result AddPlate(plate myPlate)
//        {
//            _plateBll.Add(myPlate);
//            return Result.Success();
//        }

//        [Authorize(Policy = "板块管理")]
//        [HttpPost]
//        public Result UpdatePlate(plate myPlate)
//        {
//            _plateBll.Update(myPlate);
//            return Result.Success();
//        }

//        [Authorize(Policy = "板块管理")]
//        [HttpPost]
//        public Result delPlateList(List<int> Ids)
//        {
//            _plateBll.DelListByUpdateList(Ids);
//            return Result.Success();
//        }
//    }
//}

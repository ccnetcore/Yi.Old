using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yi.Framework.Common.Models;
using Yi.Framework.Interface;
using Yi.Framework.Model.Models;

namespace Yi.Framework.ApiMicroservice.Controllers
{
    [Route("api/yi/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class MouldController : ControllerBase
    {
        private IMouldService _mouldService;
        public MouldController(IMouldService mouldService)
        {
            _mouldService = mouldService;
        }
        [HttpGet]
        public async Task<Result> GetMould()
        {
            return Result.Success().SetData(await _mouldService.GetAllEntitiesTrueAsync());
        }

        /// <summary>
        /// 更
        /// </summary>
        /// <param name="_mould"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<Result> UpdateMould(mould _mould)
        {
            await _mouldService.UpdateAsync(_mould);
            return Result.Success();

        }

        /// <summary>
        /// 删
        /// </summary>
        /// <param name="_ids"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<Result> DelListMould(List<int> _ids)
        {
            await _mouldService.DelListByUpdateAsync(_ids);
            return Result.Success();
        }

        /// <summary>
        /// 增
        /// </summary>
        /// <param name="_mould"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<Result> AddMould(mould _mould)
        {
            await _mouldService.AddAsync(_mould);
            return Result.Success();
        }


    }
}

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
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private IMenuService _menuService;
        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }
        [HttpGet]
        public async Task<Result> GetMenu()
        {
            return Result.Success().SetData(await _menuService.GetAllEntitiesTrueAsync());
        }

        /// <summary>
        /// 更
        /// </summary>
        /// <param name="_menu"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<Result> UpdateMenu(menu _menu)
        {
            await _menuService.UpdateAsync(_menu);
            return Result.Success();

        }

        /// <summary>
        /// 删
        /// </summary>
        /// <param name="_ids"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<Result> DelListMenu(List<int> _ids)
        {
            await _menuService.DelListByUpdateAsync(_ids);
            return Result.Success();
        }

        /// <summary>
        /// 增
        /// </summary>
        /// <param name="_menu"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<Result> AddMenu(menu _menu)
        {
            await _menuService.AddAsync(_menu);
            return Result.Success();
        }
    }
}

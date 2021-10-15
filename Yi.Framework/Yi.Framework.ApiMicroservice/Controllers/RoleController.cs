using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yi.Framework.Common.Models;
using Yi.Framework.DTOModel;
using Yi.Framework.Interface;
using Yi.Framework.Model.Models;

namespace Yi.Framework.ApiMicroservice.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }
        [HttpGet]
        public async Task<Result> GetRole()
        {
            return Result.Success().SetData(await _roleService.GetAllEntitiesTrueAsync());
        }

        /// <summary>
        /// 更
        /// </summary>
        /// <param name="_role"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<Result> UpdateRole(role _role)
        {
            await _roleService.UpdateAsync(_role);
            return Result.Success();

        }

        /// <summary>
        /// 删
        /// </summary>
        /// <param name="_ids"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<Result> DelListRole(List<int> _ids)
        {
            await _roleService.DelListByUpdateAsync(_ids);
            return Result.Success();
        }

        /// <summary>
        /// 增
        /// </summary>
        /// <param name="_role"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<Result> AddRole(role _role)
        {
            await _roleService.AddAsync(_role);
            return Result.Success();
        }

        /// <summary>
        /// 给角色设置菜单，多个角色与多个菜单，让每一个角色都设置，ids1为角色，ids2为菜单
        /// </summary>
        /// <param name="idsListDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<Result> SetMenuByRole(IdsListDto<int>  idsListDto)
        {
            foreach(var id in idsListDto.ids1)
            {
              await _roleService.SetMenusByRolesId(idsListDto.ids2, id);
            }
            return Result.Success();
        }
    }
}

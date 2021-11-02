using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Yi.Framework.Common.Models;
using Yi.Framework.DTOModel;
using Yi.Framework.Interface;
using Yi.Framework.Model.Models;
using Yi.Framework.WebCore;

namespace Yi.Framework.ApiMicroservice.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
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
        [HttpPost]
        public async Task<IActionResult> GetRoleFlie()
        {
            var roleList = await _roleService.GetAllEntitiesTrueAsync();
            Dictionary<string, string> dt = new();
            dt.Add("输出", "文件");
            var byteStream = Excel.ExportExcel(roleList.ToList(), dt).ToString();
            MemoryStream s = new MemoryStream();
            StreamWriter writer = new StreamWriter(s);
            writer.Write(byteStream);
            writer.Flush();
            //stream.Read(byteStream, 0, byteStream.Length);
            return new FileStreamResult(s, "application/vnd.ms-excel");
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
        /// 根据用户id得到该用户有哪些角色
        /// 用于显示用户详情中的角色说明
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<Result> GetRolesByUserId(int userId)
        {
           
            return Result.Success().SetData(await _roleService.GetRolesByUserId(userId));
        }
        /// <summary>
        /// 给角色设置菜单，多个角色与多个菜单，让每一个角色都设置，ids1为角色，ids2为菜单
        /// 用于设置角色
        /// </summary>
        /// <param name="idsListDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<Result> SetMenuByRole(IdsListDto<int>  idsListDto)
        {
            await _roleService.SetMenusByRolesId(idsListDto.ids2, idsListDto.ids1);
            return Result.Success();
        }
        /// <summary>
        /// 用于给角色设置菜单的时候，点击一个角色，显示这个角色拥有的并列的菜单
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<Result> GetTopMenusByRoleId(int roleId)
        {
           
            return Result.Success().SetData(await _roleService.GetTopMenusByRoleId(roleId) ); ;
        }       
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS.Model.Entity.User;
using TMS.Service.User.Role;

namespace TMS.API.Controllers.User
{
    /// <summary>
    /// 系统管理-角色API
    /// </summary>
    [Route("RoleAPI")]
    [ApiController]
    //[Authorize]
    public class RoleAPIController : Controller
    {
        private readonly IRoleService _roleService;

        /// <summary>
        /// 角色注入
        /// </summary>
        /// <param name="roleService"></param>
        public RoleAPIController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        /// <summary>
        /// 角色信息显示
        /// </summary>
        /// <param name="roleName">角色名称查询</param>
        /// <returns></returns>
        [Route("GetRoles")]
        [HttpGet]
        public async Task<IActionResult> GetRolesAsync(string roleName)
        {
            List<RoleModel> data = await _roleService.GetRolesAsync(roleName);
            //判断
            if (data != null)
                return Ok(new { code = true, meta = 200, msg = "获取成功", count = data.Count, data = data });
            else
                return Ok(new { code = false, meta = 500, msg = "获取失败", count = data.Count, data = "" });
        }
    }
}

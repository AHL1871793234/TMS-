using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS.Common.MyFilters;
using TMS.Service.User.Menu;

namespace TMS.API.Controllers.User
{
    /// <summary>
    /// 系统管理-菜单API
    /// </summary>
    [Route("MenuAPI")]
    [ApiController]
    [ApiWrapException]
    [ApiWrapResult]
    //[Authorize]

    public class MenuAPIController : Controller
    {
        public readonly IMenuService _menuService;

        /// <summary>
        /// 菜单注入
        /// </summary>
        /// <param name="menuService"></param>
        public MenuAPIController(IMenuService menuService)
        {
            _menuService = menuService;
        }


        /// <summary>
        /// 根据用户Id显示菜单
        /// </summary>
        /// <returns></returns>
        [Route("GetMenus")]
        [HttpGet]
        public async Task<IActionResult> GetMenusAsync()
        {
            return Ok(await _menuService.GetMenusAsync());
        }

        /// <summary>
        /// Tree菜单
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("Tree")]
        public async Task<IActionResult> TreeAsync()
        {
            return Ok(await _menuService.Tree());
        }


        /// <summary>
        /// 根据角色Id获取该角色的所有菜单Id
        /// </summary>
        /// <param name="roleID">角色ID</param>
        /// <returns></returns>
        [HttpGet, Route("Menu_ID")]
        public async Task<IActionResult> Menu_ID(int roleID)
        {
            return Ok(await _menuService.Menu_ID(roleID));
        }


        /// <summary>
        /// 分配权限
        /// </summary>
        /// <param name="roleId">要分配的角色Id</param>
        /// <param name="intList">权限菜单Id集合</param>
        /// <returns></returns>
        [HttpPost, Route("AddRoleMenu")]
        public async Task<IActionResult> AddRoleMenu(int roleId, string intList)
        {
            return Ok(await _menuService.AddRoleMenu(roleId, intList));
        }
    }
}

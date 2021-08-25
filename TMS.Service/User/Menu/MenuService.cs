using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.IRepository.User;
using TMS.Model.Entity.User;

namespace TMS.Service.User.Menu
{
    public class MenuService:IMenuService
    {
        private readonly IMenuRepository _menu;

        public MenuService(IMenuRepository menu)
        {
            _menu = menu;
        }

        /// <summary>
        /// 根据用户ID显示菜单
        /// </summary>
        /// <returns></returns>
        public async Task<List<MenuModel>> GetMenusAsync()
        {
            return await _menu.GetMenusAsync();
        }

        /// <summary>
        /// 菜单
        /// </summary>
        /// <returns></returns>
        public async Task<List<Dictionary<string, object>>> Tree(/*int roleID*/)
        {
            return await _menu.Tree();
        }

        /// <summary>
        /// 根据角色ID获取菜单Id
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public async Task<List<int>> Menu_ID(int roleId)
        {
            return await _menu.Menu_ID(roleId);
        }

        /// <summary>
        /// 分配权限
        /// </summary>
        /// <param name="roleId">要分配的角色Id</param>
        /// <param name="intList">权限菜单Id集合</param>
        /// <returns></returns>
        public async Task<bool> AddRoleMenu(int roleId, string intList)
        {
            return await _menu.AddRoleMenu(roleId, intList);
        }

    }
}

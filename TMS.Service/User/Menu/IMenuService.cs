using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Model.Entity.User;

namespace TMS.Service.User.Menu
{
    public interface IMenuService
    {
        /// <summary>
        /// 根据用户ID显示菜单
        /// </summary>
        /// <returns></returns>
        Task<List<MenuModel>> GetMenusAsync();

        /// <summary>
        /// 菜单
        /// </summary>
        /// <returns></returns>
        Task<List<Dictionary<string, object>>> Tree(/*int roleID*/);

        /// <summary>
        /// 根据角色ID获取菜单Id
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        Task<List<int>> Menu_ID(int roleId);

        /// <summary>
        /// 分配权限
        /// </summary>
        /// <param name="roleId">要分配的角色Id</param>
        /// <param name="intList">权限菜单Id集合</param>
        /// <returns></returns>
        Task<bool> AddRoleMenu(int roleId, string intList);
    }
}

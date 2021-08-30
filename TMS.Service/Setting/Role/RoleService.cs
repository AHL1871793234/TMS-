using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.IRepository.User;
using TMS.Model.Entity.Setting;

namespace TMS.Service.User.Role
{
    public class RoleService:IRoleService
    {
        private readonly IRoleRepository _role;

        public RoleService(IRoleRepository role)
        {
            _role = role;
        }

        /// <summary>
        /// 显示角色信息
        /// </summary>
        /// <param name="roleName">角色名称</param>
        /// <returns></returns>
        public async Task<List<RoleModel>> GetRolesAsync(string roleName)
        {
            return await _role.GetRolesAsync(roleName);
        }
    }
}

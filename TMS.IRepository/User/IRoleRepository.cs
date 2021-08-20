using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Model.Entity.User;

namespace TMS.IRepository.User
{
    public interface IRoleRepository
    {
        /// <summary>
        /// 显示角色信息
        /// </summary>
        /// <param name="roleName">角色名称</param>
        /// <returns></returns>
        Task<List<RoleModel>> GetRolesAsync(string roleName);
    }
}

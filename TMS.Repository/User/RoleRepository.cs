using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Common.DB;
using TMS.IRepository.User;
using TMS.Model.Entity.User;

namespace TMS.Repository.User
{
    public class RoleRepository: IRoleRepository
    {
        private readonly DapperClientHelper _SqlDB; //连接数据库

        public RoleRepository(IDapperFactory dapperFactory)
        {
            _SqlDB = dapperFactory.CreateClient("SqlDb");
        }


        /// <summary>
        /// 显示角色信息
        /// </summary>
        /// <param name="roleName">角色名称</param>
        /// <returns></returns>
        public async Task<List<RoleModel>> GetRolesAsync(string roleName)
        {
            string sql = "select RoleID,RoleName,RoleMsg,RoleCreateName,RoleCreateTime,RoleStatus from RoleModel";
            List<RoleModel> data = await _SqlDB.QueryAsync<RoleModel>(sql);
            if (!string.IsNullOrEmpty(roleName))
            {
                data = data.Where(x => x.RoleName.Contains(roleName)).ToList();
            }
            return data;
        }
    }
}

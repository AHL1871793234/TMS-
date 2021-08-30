using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Model.Entity.Setting
{
    /// <summary>
    /// 角色表
    /// </summary>
    public class RoleModel
    {
        /// <summary>
        /// 角色Id
        /// </summary>
        public int RoleID { get; set; }
        /// <summary>
        /// 角色名称
        /// </summary>
        public string RoleName { get; set; }
        /// <summary>
        /// 别名/描述
        /// </summary>
        public string RoleMsg { get; set; }
        /// <summary>
        /// 角色状态
        /// </summary>
        public int RoleStatus { get; set; }
        /// <summary>
        /// 创建人/上级领导/上级角色
        /// </summary>
        public string RoleCreateName { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime RoleCreateTime { get; set; }


        public string RoleCreateDate { get { return RoleCreateTime.ToString("yyyy-MM-dd HH:ss"); } }
    }
}

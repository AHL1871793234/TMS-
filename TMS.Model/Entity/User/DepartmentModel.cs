using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Model.Entity.User
{
    /// <summary>
    /// 部门表
    /// </summary>
    public class DepartmentModel
    {
        /// <summary>
        /// 部门Id
        /// </summary>
        public int DepartmentID { get; set; }
        /// <summary>
        /// 部门名称
        /// </summary>
        public string DepartmentName { get; set; }
        /// <summary>
        /// 上级部门ID
        /// </summary>
        public int DepartmentParentID { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime DepartmentCreateTime { get; set; }
        /// <summary>
        /// 部门状态
        /// </summary>
        public int DepartmentStatus { get; set; }
    }
}

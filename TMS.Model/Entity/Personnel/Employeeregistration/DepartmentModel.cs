using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Model.Entity.Personnel.Employeeregistration
{
    /// <summary>
    /// 部门表
    /// </summary>
    public class DepartmentModel
    {
        /// <summary>
        /// 部门主键自增不为空
        /// </summary>
        public int DepartmentID { get; set; }
        /// <summary>
        /// 部门名称
        /// </summary>
        public string DepartmentName { get; set; }
        /// <summary>
        /// 上级ID
        /// </summary>
        public int DepartmentParentID { get; set; }
        /// <summary>
        /// 部门创建时间
        /// </summary>
        public DateTime DepartmentCreateTime { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int DepartmentStatus { get; set; }
    }
}

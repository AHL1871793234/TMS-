using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Model.ViewModel
{
    /// <summary>
    /// 部门视图Id
    /// </summary>
    public class DepartmentViewModel
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

        /// <summary>
        /// 上级部门名称
        /// </summary>
        public string UpName { get; set; }


        public string DepartmentCreateDate { get { return DepartmentCreateTime.ToString("yyyy-MM-dd HH:ss"); } }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Model.ViewModel
{
    /// <summary>
    /// 离职视图
    /// </summary>
    public  class LeaveToDealViewModel
    {
        /// <summary>
        /// 员工名称
        /// </summary>
        public string EmployeeName { get; set; }
        /// <summary>
        /// 部门名称
        /// </summary>
        public string DepartmentName { get; set; }
        /// <summary>
        /// 职位名称
        /// </summary>
        public string PositionName { get; set; }
        /// <summary>
        /// 上级负责人
        /// </summary>
        public string EmployeeParentName { get; set; }
        /// <summary>
        /// 员工入职时间
        /// </summary>
        public DateTime EmployeeEntryTime { get; set; }
        /// <summary>
        /// 员工离职时间
        /// </summary>
        public DateTime EmployeeEndWorkTime { get; set; }
        /// <summary>
        /// 员工离职原因
        /// </summary>
        public string EmployeeLeaveSession { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime DepartmentCreateTime { get; set; }
        /// <summary>
        /// 审批状态
        /// </summary>
        public int ExamineStatus { get; set; }
        /// <summary>
        /// 审批人
        /// </summary>
        public string ExamineName { get; set; }
    }
}

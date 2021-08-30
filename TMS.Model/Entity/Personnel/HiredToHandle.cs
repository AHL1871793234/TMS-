using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Model.Entity.Personnel
{
    /// <summary>
    /// 入职办理表
    /// </summary>
    public class HiredToHandle
    {
        /// <summary>
        /// 员工ID
        /// </summary>
        public int EmployeeID    { get; set; }
        /// <summary>
        /// 部门ID
        /// </summary>
        public int DepartmentID  { get; set; }
        /// <summary>
        /// 职位ID
        /// </summary>
        public int PositionID    { get; set; }
        /// <summary>
        /// 审批ID
        /// </summary>
        public int ExamineID { get; set; }
    }
}

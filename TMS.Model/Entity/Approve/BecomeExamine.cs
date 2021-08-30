using System;
using System.Collections.Generic;

#nullable disable

namespace TMS.Model.Entity.Approve
{
    /// <summary>
    /// 转正审批联查
    /// </summary>
    public partial class BecomeExamine
    {
        /// <summary>
        /// 转正审批ID
        /// </summary>
        public int BecomeExamineId { get; set; }
        /// <summary>
        /// 员工表外键ID
        /// </summary>
        public int? EmployeeId { get; set; }
        /// <summary>
        /// 部门表外键ID
        /// </summary>
        public int? DepartmentId { get; set; }
        /// <summary>
        /// 职位表外键ID
        /// </summary>
        public int? PositionId { get; set; }
        /// <summary>
        /// 审批表外键ID
        /// </summary>
        public int? ExamineId { get; set; }
        /// <summary>
        /// 转正审批状态
        /// </summary>
        public int? BecomeStatus { get; set; }
    }
}

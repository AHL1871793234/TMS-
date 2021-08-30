using System;
using System.Collections.Generic;

#nullable disable

namespace TMS.Model.Entity.Approve
{
    /// <summary>
    /// 入职审批
    /// </summary>
    public partial class EntryExamine
    {
        /// <summary>
        /// 入职审批ID
        /// </summary>
        public int EntryExamineId { get; set; }
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
        /// 入职审批状态
        /// </summary>
        public int? EntryExamineStatus { get; set; }
    }
}

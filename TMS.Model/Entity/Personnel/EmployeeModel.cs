using System;
using System.Collections.Generic;

#nullable disable

namespace TMS.Model.Entity.Personnel
{
    /// <summary>
    /// 员工表
    /// </summary>
    public partial class EmployeeModel
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeSex { get; set; }
        public string EmployeePhone { get; set; }
        public int? EmployeeType { get; set; }
        public DateTime? EmployeeEntryTime { get; set; }
        public DateTime? EmployeeEndWorkTime { get; set; }
        public string EmployeeLeaveSession { get; set; }
        public DateTime? EmployeeProposerTime { get; set; }
        public string EmployeeParentName { get; set; }
        public DateTime? CreateTime { get; set; }
        public int? EmployeeStatus { get; set; }
    }
}

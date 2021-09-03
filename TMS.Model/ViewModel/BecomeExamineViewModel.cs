using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Model.ViewModel
{
    /// <summary>
    /// 转正审批联查
    /// </summary>
    public class BecomeExamineViewModel
    {
        public string EmployeeName { get; set; }
        public string DepartmentName { get; set; }
        public string PositionName { get; set; }
        public DateTime EmployeeEntryTime { get; set; }
        public DateTime EmployeeProposerTime { get; set; }
        public int ExamineStatus { get; set; }
        public string ExamineName { get; set; }
        public DateTime CreateTime { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Model.ViewModel
{
    /// <summary>
    /// 员工登记表
    /// </summary>
    public class EmployeeRegistration
    {
        /// <summary>
        /// 员工表
        /// </summary>
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeSex { get; set; }
        public string EmployeePhone { get; set; }
        public DateTime EmployeeEntryTime { get; set; }
        public int EmployeeType { get; set; }
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 部门表
        /// </summary>
        public string DepartmentName { get; set; }
        public int DepartmentStatus { get; set; }
        /// <summary>
        /// 职位表
        /// </summary>
        public string PositionName { get; set; }
        /// <summary>
        /// 用户表
        /// </summary>
        public string UserSchool { get; set; }
        public string UseMajor { get; set; }
        public string UserHomePlace { get; set; }
    }
}

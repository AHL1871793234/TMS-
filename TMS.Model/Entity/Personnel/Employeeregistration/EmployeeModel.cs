using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Model.Entity.Personnel.Employeeregistration
{
    /// <summary>
    /// 员工登记表
    /// </summary>
    public class EmployeeModel
    {
        /// <summary>
        /// 员工ID
        /// </summary>
        public int EmployeeID { get; set; }
        /// <summary>
        /// 员工姓名
        /// </summary>
        public string EmployeeName { get; set; }
        /// <summary>
        /// 员工性别
        /// </summary>
        public string EmployeeSex { get; set; }
        /// <summary>
        /// 员工手机
        /// </summary>
        public string EmployeePhone { get; set; }
        /// <summary>
        /// 员工类别（1：正式员工2：实习生3：试用工）
        /// </summary>
        public int EmployeeType { get; set; }
        /// <summary>
        /// 员工入职申请
        /// </summary>
        public DateTime EmployeeEntryTime { get; set; }
        /// <summary>
        /// 员工最后工作日
        /// </summary>
        public DateTime EmployeeEndWorkTime { get; set; }
        /// <summary>
        /// 员工离职时间
        /// </summary>
        public string EmployeeLeaveSession { get; set; }
        /// <summary>
        /// 员工申请时间
        /// </summary>
        public DateTime EmployeeProposerTime { get; set; }
        /// <summary>
        /// 上级负责人
        /// </summary>
        public string EmployeeParentName { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int EmployeeStatus { get; set; }
    }
}

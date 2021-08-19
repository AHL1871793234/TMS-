using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.IRepository.Goodsandmaterials;
using TMS.Model.ViewModel;
using TMS.IRepository.Personnel;
using TMS.Model.Entity;

namespace TMS.Service.Personnel
{
    public class EmployeeregistrationService:IEmployeeregistrationService
    {
        public readonly IEmployeeregistrationRepository employeeregistration;

        public EmployeeregistrationService(IEmployeeregistrationRepository _employeeregistration)
        {
            employeeregistration = _employeeregistration;
        }

        /// <summary>
        /// 人事模块—员工登记—显示
        /// </summary>
        /// <param name="EmpName"></param>
        /// <param name="EmpDeparName"></param>
        /// <param name="PosterName"></param>
        /// <param name="EmpPhone"></param>
        /// <param name="EmpType"></param>
        /// <returns></returns>
        public List<EmployeeRegistration> GetEmployeeRegistrations(string EmpName, int EmpDeparName, int PosterName, string EmpPhone, int EmpType)
        {
            return employeeregistration.GetEmployeeRegistrations(EmpName, EmpDeparName, PosterName, EmpPhone, EmpType);
        }

        /// <summary>
        /// 人事模块—员工登记—添加
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        public bool AddEmployeeRegistrations(UserModel userModel)
        {
            return employeeregistration.AddEmployeeRegistrations(userModel);
        }
    }
}

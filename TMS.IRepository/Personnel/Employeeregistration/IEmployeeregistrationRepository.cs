using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Model.Entity;
using TMS.Model.ViewModel;

namespace TMS.IRepository.Personnel
{
    public interface IEmployeeregistrationRepository
    {
        /// <summary>
        /// 人事模块—员工登记—显示接口
        /// </summary>
        /// <param name="EmpName"></param>
        /// <param name="EmpDeparName"></param>
        /// <param name="PosterName"></param>
        /// <param name="EmpPhone"></param>
        /// <param name="EmpType"></param>
        /// <returns></returns>
        List<EmployeeRegistration> GetEmployeeRegistrations(string EmpName, int EmpDeparName, int PosterName, string EmpPhone, int EmpType);

        /// <summary>
        /// 人事模块—员工登记—添加
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        bool AddEmployeeRegistrations(UserModel userModel);
    }
}

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS.Service.Personnel;
using Microsoft.AspNetCore.Hosting;
using TMS.Model.ViewModel;

namespace TMS.API.Controllers.Personnel.Employeeregistration
{
    /// <summary>
    /// 员工登记API
    /// </summary>
    public class EmployeeregistrationAPIController : Controller
    {
        /// <summary>
        /// 员工登记服务
        /// </summary>
        public readonly IEmployeeregistrationService _employeeregistration;
        [Obsolete]
        private readonly IHostingEnvironment _hostingEnvironment;

        /// <summary>
        /// 构造函数注入
        /// </summary>
        /// <param name="employeeregistration"></param>
        /// <param name="hostingEnvironment"></param>
        [Obsolete]
        public EmployeeregistrationAPIController(IEmployeeregistrationService employeeregistration, IHostingEnvironment hostingEnvironment)
        {
            _employeeregistration = employeeregistration;
            _hostingEnvironment = hostingEnvironment;
        }

        /// <summary>
        /// 人事模块—员工登记—显示API
        /// </summary>
        /// <returns></returns>
        [Route(nameof(GetEmployeeRegistrations))]
        [HttpGet]
        public IActionResult GetEmployeeRegistrations(string EmpName, int EmpDeparName, int PosterName, string EmpPhone, int EmpType)
        {
            try
            {
                List<EmployeeRegistration> data = _employeeregistration.GetEmployeeRegistrations(EmpName, EmpDeparName, PosterName, EmpPhone, EmpType);
                if (data != null)
                {
                    return Ok(new { code = true, meta = 200, msg = "获取成功", count = data.Count, data = data });
                }
                else
                {
                    return Ok(new { code = false, meta = 500, msg = "获取失败", count = data.Count, data = "" });
                }
            }
            catch (Exception)
            {
                return Ok(new { code = false, meta = 500, msg = "获取失败", count = 0, data = "" });
            }
        }
    }
}

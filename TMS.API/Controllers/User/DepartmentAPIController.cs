using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS.Common.MyFilters;
using TMS.Service.User;

namespace TMS.API.Controllers.User
{
    /// <summary>
    /// 系统管理-部门API
    /// </summary>
    [Route("DepartmentAPI")]
    [ApiController]
    [ApiWrapException]
    [ApiWrapResult]
    //[Authorize]
    public class DepartmentAPIController : Controller
    {
        private readonly IDepartmentService _department;

        /// <summary>
        /// 注入
        /// </summary>
        /// <param name="department"></param>
        public DepartmentAPIController(IDepartmentService department)
        {
            _department = department;
        }

        /// <summary>
        /// 部门信息显示
        /// </summary>
        /// <param name="depName">部门名称查询</param>
        /// <returns></returns>
        [Route("GetDepartment")]
        [HttpGet]
        public async Task<IActionResult> GetDepartmentsAsync(string depName)
        {
            return Ok(await _department.GetDepartmentsAsync(depName));

        }
    }
}

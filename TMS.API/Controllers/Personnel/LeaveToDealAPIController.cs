using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS.Common.MyFilters;
using TMS.Repository.Personnel;
using TMS.Service.Personnel;

namespace TMS.API.Controllers.Personnel
{
    /// <summary>
    /// 离职办理
    /// </summary>
    [Route("LeaveToDealAPI")]
    [ApiController]
    [ApiWrapException]
    [ApiWrapResult]
    //[Authorize]
    public class LeaveToDealAPIController : Controller
    {
        /// <summary>
        /// 入职办理
        /// </summary>
        public readonly ILeaveToDealService _leaveToDealRepository;

        private readonly IHostingEnvironment _hostingEnvironment;

        /// <summary>
        /// 构造函数注入
        /// </summary>
        /// <param name="positiveToDealService"></param>
        /// <param name="hostingEnvironment"></param>
        [Obsolete]
        public LeaveToDealAPIController( ILeaveToDealService positiveToDealService, IHostingEnvironment hostingEnvironment)
        {
            _leaveToDealRepository = positiveToDealService;
            _hostingEnvironment = hostingEnvironment;
        }
        /// <summary>
        /// 人事模块—离职办理—显示
        /// </summary>
        /// <param name="EmpName">员工姓名</param>
        /// <param name="EmpDeparName">部门名称</param>
        /// <param name="PosterName">职位名称</param>
        /// <param name="EntryTime">入职日期</param>
        /// <param name="LeaveTime">离职日期</param>
        /// <param name="ExamineStatus">审批状态</param>
        /// <returns></returns>
        [Route(nameof(GetLeaveToDealViewModel)), HttpGet]
        public async Task<IActionResult> GetLeaveToDealViewModel(string EmpName, string EmpDeparName, string PosterName, DateTime? EntryTime, DateTime? LeaveTime, int ExamineStatus)
        {
            return Ok(await _leaveToDealRepository.GetLeaveToDealViewModel(EmpName, EmpDeparName, PosterName, EntryTime, LeaveTime, ExamineStatus));
        }
    }
}

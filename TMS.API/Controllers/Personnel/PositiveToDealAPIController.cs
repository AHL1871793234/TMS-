using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS.Common.MyFilters;
using TMS.Service.Personnel;

namespace TMS.API.Controllers.Personnel
{
    /// <summary>
    /// 转正办理
    /// </summary>
    [Route("PositiveToDealAPI")]
    [ApiController]
    [ApiWrapException]
    [ApiWrapResult]
    //[Authorize]
    public class PositiveToDealAPIController : Controller
    {
        /// <summary>
        /// 转正办理
        /// </summary>
        public readonly IPositiveToDealService _positiveToDealService1;

        private readonly IHostingEnvironment _hostingEnvironment;

        /// <summary>
        /// 构造函数注入
        /// </summary>
        /// <param name="positiveToDealService"></param>
        /// <param name="hostingEnvironment"></param>
        [Obsolete]
        public PositiveToDealAPIController(IPositiveToDealService positiveToDealService, IHostingEnvironment hostingEnvironment)
        {
            _positiveToDealService1 = positiveToDealService;
            _hostingEnvironment = hostingEnvironment;
        }
        /// <summary>
        /// 人事模块—转正办理—显示
        /// </summary>
        /// <param name="EmpName">员工姓名</param>
        /// <param name="EmpDeparName">部门名称</param>
        /// <param name="PosterName">职位名称</param>
        /// <param name="EntryTime">入职日期</param>
        /// <param name="ProposerTime">申请日期</param>
        /// <param name="ExamineStatus">审批状态</param>
        /// <returns></returns>
        [Route(nameof(GetLeaveToDealViewModel)), HttpGet]
        public async Task<IActionResult> GetLeaveToDealViewModel(string EmpName, string EmpDeparName, string PosterName, DateTime? EntryTime, DateTime? ProposerTime, int ExamineStatus)
        {
            return Ok(await _positiveToDealService1.GetPositiveToDealViewModels(EmpName, EmpDeparName, PosterName, EntryTime, ProposerTime, ExamineStatus));
        }
    }
}

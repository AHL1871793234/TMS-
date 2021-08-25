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
    /// 入职办理
    /// </summary>
    [Route("HiredToHandlerAPI")]
    [ApiController]
    [ApiWrapException]
    [ApiWrapResult]
    //[Authorize]
    public class HiredToHandlerAPIController : Controller
    {
        /// <summary>
        /// 入职办理
        /// </summary>
        public readonly IHiredToHandlerService _hiredToHandlerService;

        private readonly IHostingEnvironment _hostingEnvironment;

        /// <summary>
        /// 构造函数注入
        /// </summary>
        /// <param name="positiveToDealService"></param>
        /// <param name="hostingEnvironment"></param>
        [Obsolete]
        public HiredToHandlerAPIController(IHiredToHandlerService positiveToDealService, IHostingEnvironment hostingEnvironment)
        {
            _hiredToHandlerService = positiveToDealService;
            _hostingEnvironment = hostingEnvironment;
        }
        /// <summary>
        /// 入职办理—显示
        /// </summary>
        /// <param name="EmpName"></param>
        /// <param name="EmpDeparName"></param>
        /// <param name="PosterName"></param>
        /// <param name="EntryTime"></param>
        /// <param name="CreateTime"></param>
        /// <param name="ExamineStatus"></param>
        /// <returns></returns>
        [Route(nameof(GetHiredToHandlerViewModels)), HttpGet]
        public async Task<IActionResult> GetHiredToHandlerViewModels(string EmpName, string EmpDeparName, string PosterName, DateTime? EntryTime, DateTime? CreateTime, int ExamineStatus)
        {
            return Ok(await _hiredToHandlerService.GetHiredToHandlerViewModels(EmpName, EmpDeparName, PosterName, EntryTime, CreateTime, ExamineStatus));
        }
    }
}

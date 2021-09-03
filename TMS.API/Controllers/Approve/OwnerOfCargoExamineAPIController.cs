using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS.Model.ViewModel;
using TMS.Service;

namespace TMS.API.Controllers.Approve
{
    /// <summary>
    /// 货主审批合同管理
    /// </summary>
    [Route("OwnerOfCargoExamineAPI")]
    [ApiController]
    //[Authorize]
    public class OwnerOfCargoExamineAPIController : Controller
    {
        public readonly IOwnerOfCargoExamineService _ownerOfCargoExamineService;

        private readonly IHostingEnvironment _hostingEnvironment;

        /// <summary>
        /// 构造函数进行注入
        /// </summary>
        /// <param name="ownerOfCargoExamineService"></param>
        /// <param name="hostingEnvironment"></param>
        public OwnerOfCargoExamineAPIController(IOwnerOfCargoExamineService ownerOfCargoExamineService, IHostingEnvironment hostingEnvironment)
        {
            _ownerOfCargoExamineService = ownerOfCargoExamineService;
            _hostingEnvironment = hostingEnvironment;
        }

        /// <summary>
        /// 货主合同审批-显示+查询
        /// </summary>
        /// <param name="OwnerOfCargoContractTitle">合同标题</param>
        /// <param name="OwnerOfCargoContractUnit">货主单位</param>
        /// <param name="OwnerOfCargoContractName">货主负责人</param>
        /// <param name="CircuitResponsibleName">经办人</param>
        /// <param name="DateOfSigningTime">签订时间</param>
        /// <returns></returns>
        [Route(nameof(GetOwnerOfCargoExamine)), HttpGet]
        public async Task<IActionResult> GetOwnerOfCargoExamine(string OwnerOfCargoContractTitle, string OwnerOfCargoContractUnit, string OwnerOfCargoContractName, string CircuitResponsibleName, DateTime? DateOfSigningTime)
        {
            try
            {
                List<OwnerOfCargoExamineViewModel> data = await _ownerOfCargoExamineService.GetOwnerOfCargoExamine(OwnerOfCargoContractTitle, OwnerOfCargoContractUnit, OwnerOfCargoContractName, CircuitResponsibleName, DateOfSigningTime);
                //判断
                if (data != null)
                    return Ok(new { code = true, meta = 200, msg = "获取成功", count = data.Count, data = data });
                else
                    return Ok(new { code = false, meta = 500, msg = "获取失败", count = data.Count, data = "" });
            }
            catch (Exception)
            {
                return Ok(new { code = false, meta = 500, msg = "获取失败", count = 0, data = "" });
            }
        }

        /// <summary>
        /// 货主合同审批-查看合同审批详情信息
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [Route(nameof(EditOwnerOfCargoExamine)), HttpGet]
        public async Task<IActionResult> EditOwnerOfCargoExamine(string name)
        {
            try
            {
                OwnerOfCargoExamineViewModel data = await _ownerOfCargoExamineService.EditOwnerOfCargoExamine(name);
                if (data != null)
                    return Ok(new { code = true, meta = 200, msg = "获取成功", data = data });
                else
                    return Ok(new { code = false, meta = 500, msg = "获取失败", data = "" });
            }
            catch (Exception)
            {
                return Ok(new { code = false, meta = 500, msg = "获取失败", data = "" });
            }
        }

        /// <summary>
        /// 合同通过并转批
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        [Route(nameof(EditPassAccommodation)), HttpPost]
        public async Task<IActionResult> EditPassAccommodation(string title)
        {
            try
            {
                bool data = await _ownerOfCargoExamineService.EditPassAccommodation(title);
                if (data == true)
                    return Ok(new { code = true, meta = 200, msg = "审核通过，已转批上级领导进行二次审批", data = data });
                else
                    return Ok(new { code = false, meta = 500, msg = "审核未通过", data = "" });
            }
            catch (Exception)
            {
                return Ok(new { code = false, meta = 500, msg = "审核异常", data = "" });
            }
        }

        /// <summary>
        /// 拒绝(审批未通过)
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        [Route(nameof(EditNoPass)), HttpPost]
        public async Task<IActionResult> EditNoPass(string title)
        {
            try
            {
                bool data = await _ownerOfCargoExamineService.EditNoPass(title);
                if (data == true)
                    return Ok(new { code = true, meta = 200, msg = "审核拒绝(审核未通过)", data = data });
                else
                    return Ok(new { code = false, meta = 500, msg = "审核异常", data = "" });
            }
            catch (Exception)
            {
                return Ok(new { code = false, meta = 500, msg = "审核异常", data = "" });
            }
        }

        /// <summary>
        /// 审批通过并终止审批
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        [Route(nameof(EditPassEnd)), HttpPost]
        public async Task<IActionResult> EditPassEnd(string title)
        {
            try
            {
                bool data = await _ownerOfCargoExamineService.EditPassEnd(title);
                if (data == true)
                    return Ok(new { code = true, meta = 200, msg = "审核通过,该审核已结束", data = data });
                else
                    return Ok(new { code = false, meta = 500, msg = "审核未通过", data = "" });
            }
            catch (Exception)
            {
                return Ok(new { code = false, meta = 500, msg = "审核异常", data = "" });
            }
        }

    }
}

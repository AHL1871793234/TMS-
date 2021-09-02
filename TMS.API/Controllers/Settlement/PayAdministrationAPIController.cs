using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS.Model.Entity.Settlement;
using TMS.Service;

namespace TMS.API.Controllers.Settlement
{
    /// <summary>
    /// 结算管理-应付费用管理
    /// </summary>
    [Route("PayAdministrationAPI")]
    [ApiController]
    //[Authorize]
    public class PayAdministrationAPIController : Controller
    {
        //用户服务
        public readonly IPayAdministrationService _AdministrationService;

        private readonly IHostingEnvironment _hostingEnvironment;

        /// <summary>
        /// 构造函数进行注入
        /// </summary>
        /// <param name="payAdministration"></param>
        /// <param name="hostingEnvironment"></param>
        public PayAdministrationAPIController(IPayAdministrationService payAdministration, IHostingEnvironment hostingEnvironment)
        {
            _AdministrationService = payAdministration;
            _hostingEnvironment = hostingEnvironment;
        }

        /// <summary>
        /// 应付费用管理-显示+查询
        /// </summary>
        /// <param name="ChargeOwnerOfCargoUnit"></param>
        /// <param name="PayType"></param>
        /// <param name="CheckType"></param>
        /// <param name="CircuitResponsibleName"></param>
        /// <param name="ProfessionalTime"></param>
        /// <returns></returns>
        [Route(nameof(GetPayAdministration)), HttpGet]
        public async Task<IActionResult> GetPayAdministration(string ChargeOwnerOfCargoUnit, string PayType, string CheckType, string CircuitResponsibleName, DateTime? ProfessionalTime)
        {
            try
            {
                List<PayAdministration> data = await _AdministrationService.GetPayAdministration(ChargeOwnerOfCargoUnit, PayType, CheckType, CircuitResponsibleName, ProfessionalTime);
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
        /// 应付费用管理-添加数据
        /// </summary>
        /// <param name="payAdministration"></param>
        /// <returns></returns>
        [Route(nameof(AddPayAdministration)), HttpPost]
        public async Task<IActionResult> AddPayAdministration([FromForm] PayAdministration payAdministration)
        {
            try
            {
                bool data = await _AdministrationService.AddPayAdministration(payAdministration);
                if (data == true)
                    return Ok(new { code = data, meta = 200, msg = "添加成功" });
                else
                    return Ok(new { code = data, meta = 500, msg = "添加失败" });
            }
            catch (Exception)
            {
                return Ok(new { code = false, meta = 500, msg = "添加失败" });
            }
        }

        /// <summary>
        /// 应付费用管理-删除数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route(nameof(DelPayAdministration)), HttpDelete]
        public async Task<IActionResult> DelPayAdministration(string id)
        {
            try
            {
                bool data = await _AdministrationService.DelPayAdministration(id);
                if (data == true)
                    return Ok(new { code = data, meta = 200, msg = "删除成功" });
                else
                    return Ok(new { code = data, meta = 500, msg = "删除失败" });
            }
            catch (Exception)
            {
                return Ok(new { code = false, meta = 500, msg = "删除失败" });
            }
        }

        /// <summary>
        /// 应付费用管理-反填获取详细信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route(nameof(EditPayAdministration)), HttpGet]
        public async Task<IActionResult> EditPayAdministration(int id)
        {
            try
            {
                PayAdministration data = await _AdministrationService.EditPayAdministration(id);
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
        /// 应付费用管理-修改数据
        /// </summary>
        /// <param name="payAdministration"></param>
        /// <returns></returns>
        [Route(nameof(UpdPayAdministration)), HttpPost]
        public async Task<IActionResult> UpdPayAdministration([FromForm] PayAdministration payAdministration)
        {
            try
            {
                bool data = await _AdministrationService.UpdPayAdministration(payAdministration);
                if (data == true)
                    return Ok(new { code = data, meta = 200, msg = "修改成功" });
                else
                    return Ok(new { code = data, meta = 500, msg = "修改失败" });
            }
            catch (Exception)
            {
                return Ok(new { code = false, meta = 500, msg = "修改失败" });
            }
        }
    }
}

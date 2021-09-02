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
    /// 结算管理-应收费用管理
    /// </summary>
    [Route("ChargeAPI")]
    [ApiController]
    //[Authorize]
    public class ChargeAPIController : Controller
    {
        //用户服务
        public readonly IChargeService _chargeService;

        private readonly IHostingEnvironment _hostingEnvironment;

        /// <summary>
        /// 构造函数进行注入
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="hostingEnvironment"></param>
        public ChargeAPIController(IChargeService chargeServic, IHostingEnvironment hostingEnvironment)
        {
            _chargeService = chargeServic;
            _hostingEnvironment = hostingEnvironment;
        }
        /// <summary>
        /// 应收费用管理-显示API
        /// </summary>
        /// <param name="ChargeOwnerOfCargoUnit"></param>
        /// <param name="PayType"></param>
        /// <param name="CheckType"></param>
        /// <param name="CircuitResponsibleName"></param>
        /// <param name="ProfessionalTime"></param>
        /// <returns></returns>
        [Route(nameof(GetCharge)), HttpGet]
        public async Task<IActionResult> GetCharge(string ChargeOwnerOfCargoUnit, string PayType, string CheckType, string CircuitResponsibleName, DateTime? ProfessionalTime)
        {
            try
            {
                List<Charge> data = await _chargeService.GetCharges(ChargeOwnerOfCargoUnit, PayType, CheckType, CircuitResponsibleName, ProfessionalTime);
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
        /// 应收费用管理-添加数据
        /// </summary>
        /// <param name="charge"></param>
        /// <returns></returns>
        [Route(nameof(AddCharges)), HttpPost]
        public async Task<IActionResult> AddCharges([FromForm] Charge charge)
        {
            try
            {
                bool data = await _chargeService.AddCharges(charge);
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
        /// 应用费用管理—删除数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route(nameof(DelCharges)), HttpDelete]
        public async Task<IActionResult> DelCharges(string id)
        {
            try
            {
                bool data = await _chargeService.DelCharges(id);
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
        /// 应用费用管理—反填数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route(nameof(EditCharges)), HttpGet]
        public async Task<IActionResult> EditCharges(int id)
        {
            try
            {
                Charge data = await _chargeService.EditCharge(id);
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
        /// 应用费用管理—修改数据
        /// </summary>
        /// <param name="charge"></param>
        /// <returns></returns>
        [Route(nameof(UpdCharge)), HttpPost]
        public async Task<IActionResult> UpdCharge([FromForm] Charge charge)
        {
            try
            {
                bool data = await _chargeService.UpdCharge(charge);
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

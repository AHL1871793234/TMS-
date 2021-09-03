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
    /// 销项发票管理-付款管理
    /// </summary>
    [Route("PaymentAPI")]
    [ApiController]
    //[Authorize]
    public class PaymentAPIController : Controller
    {
        //用户服务
        public readonly IPaymentService _paymentService;

        private readonly IHostingEnvironment _hostingEnvironment;

        /// <summary>
        /// 构造函数进行注入
        /// </summary>
        /// <param name="outputNvoice"></param>
        /// <param name="hostingEnvironment"></param>
        public PaymentAPIController(IPaymentService paymentService, IHostingEnvironment hostingEnvironment)
        {
            _paymentService = paymentService;
            _hostingEnvironment = hostingEnvironment;
        }

        /// <summary>
        /// 销项发票管理-付款管理-显示+查询
        /// </summary>
        /// <param name="PaymentTitle"></param>
        /// <param name="PayTime"></param>
        /// <param name="ReceiptsNvoiceType"></param>
        /// <param name="CommonContractStatus"></param>
        /// <param name="CommonContractName"></param>
        /// <returns></returns>
        [Route(nameof(GetPayment)), HttpGet]
        public async Task<IActionResult> GetPayment(string PaymentTitle, DateTime? PayTime, string ReceiptsNvoiceType, int CommonContractStatus, string CommonContractName)
        {
            try
            {
                List<Payment> data = await _paymentService.GetPayment(PaymentTitle, PayTime, ReceiptsNvoiceType, CommonContractStatus, CommonContractName);
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
        /// 销项发票管理-付款管理-添加数据
        /// </summary>
        /// <param name="payment"></param>
        /// <returns></returns>
        [Route(nameof(AddPayment)), HttpPost]
        public async Task<IActionResult> AddPayment([FromForm] Payment payment)
        {
            try
            {
                bool data = await _paymentService.AddPayment(payment);
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
        /// 销项发票管理-付款管理-删除数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route(nameof(DelPayment)), HttpDelete]
        public async Task<IActionResult> DelPayment(string id)
        {
            try
            {
                bool data = await _paymentService.DelPayment(id);
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
        /// 销项发票管理-付款管理-反填获取详情信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route(nameof(EditPayment)), HttpGet]
        public async Task<IActionResult> EditPayment(int id)
        {
            try
            {
                Payment data = await _paymentService.EditPayment(id);
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
        /// 销项发票管理-付款管理-修改数据
        /// </summary>
        /// <param name="payment"></param>
        /// <returns></returns>
        [Route(nameof(UpdPayment)), HttpPost]
        public async Task<IActionResult> UpdPayment([FromForm] Payment payment)
        {
            try
            {
                bool data = await _paymentService.UpdPayment(payment);
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

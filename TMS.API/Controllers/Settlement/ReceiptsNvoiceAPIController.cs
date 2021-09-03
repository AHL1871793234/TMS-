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
    /// 进项发票管理-显示+查询
    /// </summary>
    [Route("ReceiptsNvoiceAPI")]
    [ApiController]
    //[Authorize]
    public class ReceiptsNvoiceAPIController : Controller
    {
        //用户服务
        public readonly IReceiptsNvoiceService _receiptsNvoice;

        private readonly IHostingEnvironment _hostingEnvironment;

        /// <summary>
        /// 构造函数进行注入
        /// </summary>
        /// <param name="receiptsNvoice"></param>
        /// <param name="hostingEnvironment"></param>
        public ReceiptsNvoiceAPIController(IReceiptsNvoiceService receiptsNvoice, IHostingEnvironment hostingEnvironment)
        {
            _receiptsNvoice = receiptsNvoice;
            _hostingEnvironment = hostingEnvironment;
        }

        /// <summary>
        /// 进项发票管理-显示+查询
        /// </summary>
        /// <param name="ChargeOwnerOfCargoUnit"></param>
        /// <param name="ReceiptsNvoiceType"></param>
        /// <param name="CheckType"></param>
        /// <param name="InvoiceTime"></param>
        /// <returns></returns>
        [Route(nameof(GetReceiptsNvoice)), HttpGet]
        public async Task<IActionResult> GetReceiptsNvoice(string ChargeOwnerOfCargoUnit, string ReceiptsNvoiceType, string CheckType, DateTime? InvoiceTime)
        {
            try
            {
                List<ReceiptsNvoice> data = await _receiptsNvoice.GetReceiptsNvoice(ChargeOwnerOfCargoUnit, ReceiptsNvoiceType, CheckType, InvoiceTime);
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
        /// 进项发票管理-添加数据
        /// </summary>
        /// <param name="receiptsNvoice"></param>
        /// <returns></returns>
        [Route(nameof(AddReceiptsNvoice)), HttpPost]
        public async Task<IActionResult> AddReceiptsNvoice([FromForm] ReceiptsNvoice receiptsNvoice)
        {
            try
            {
                bool data = await _receiptsNvoice.AddReceiptsNvoice(receiptsNvoice);
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
        /// 进项发票管理-删除数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route(nameof(DelReceiptsNvoice)), HttpDelete]
        public async Task<IActionResult> DelReceiptsNvoice(string id)
        {
            try
            {
                bool data = await _receiptsNvoice.DelReceiptsNvoice(id);
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
        /// 进项发票管理-反填相关详情数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route(nameof(EditReceiptsNvoice)), HttpGet]
        public async Task<IActionResult> EditReceiptsNvoice(int id)
        {
            try
            {
                ReceiptsNvoice data = await _receiptsNvoice.EditReceiptsNvoice(id);
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
        /// 进项发票管理-修改数据
        /// </summary>
        /// <param name="receiptsNvoice"></param>
        /// <returns></returns>
        [Route(nameof(UpdReceiptsNvoice)), HttpPost]
        public async Task<IActionResult> UpdReceiptsNvoice([FromForm] ReceiptsNvoice receiptsNvoice)
        {
            try
            {
                bool data = await _receiptsNvoice.UpdReceiptsNvoice(receiptsNvoice);
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

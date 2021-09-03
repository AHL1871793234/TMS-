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
    /// 销项发票管理
    /// </summary>
    [Route("OutputNvoiceAPI")]
    [ApiController]
    //[Authorize]
    public class OutputNvoiceAPIController : Controller
    {
        //用户服务
        public readonly IOutputNvoiceService _outputNvoice;

        private readonly IHostingEnvironment _hostingEnvironment;

        /// <summary>
        /// 构造函数进行注入
        /// </summary>
        /// <param name="outputNvoice"></param>
        /// <param name="hostingEnvironment"></param>
        public OutputNvoiceAPIController(IOutputNvoiceService outputNvoice, IHostingEnvironment hostingEnvironment)
        {
            _outputNvoice = outputNvoice;
            _hostingEnvironment = hostingEnvironment;
        }

        /// <summary>
        /// 销项发票管理-显示+查询
        /// </summary>
        /// <param name="OutputNvoiceName"></param>
        /// <param name="ReceiptsNvoiceType"></param>
        /// <param name="InvoiceTime"></param>
        /// <returns></returns>
        [Route(nameof(GetOutputNvoice)), HttpGet]
        public async Task<IActionResult> GetOutputNvoice(string OutputNvoiceName, string ReceiptsNvoiceType, DateTime? InvoiceTime)
        {
            try
            {
                List<OutputNvoice> data = await _outputNvoice.GetOutputNvoice(OutputNvoiceName, ReceiptsNvoiceType, InvoiceTime);
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
        /// 销项发票管理-添加数据
        /// </summary>
        /// <param name="outputNvoice"></param>
        /// <returns></returns>
        [Route(nameof(AddOutputNvoice)), HttpPost]
        public async Task<IActionResult> AddOutputNvoice([FromForm] OutputNvoice outputNvoice)
        {
            try
            {
                bool data = await _outputNvoice.AddOutputNvoice(outputNvoice);
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
        /// 销项发票管理-删除数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route(nameof(DelOutputNvoice)), HttpDelete]
        public async Task<IActionResult> DelOutputNvoice(string id)
        {
            try
            {
                bool data = await _outputNvoice.DelOutputNvoice(id);
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
        /// 销项发票管理-反填获取详情信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route(nameof(EditOutputNvoice)), HttpGet]
        public async Task<IActionResult> EditOutputNvoice(int id)
        {
            try
            {
                OutputNvoice data = await _outputNvoice.EditOutputNvoice(id);
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
        /// 销项发票管理-修改数据
        /// </summary>
        /// <param name="outputNvoice"></param>
        /// <returns></returns>
        [Route(nameof(UpdOutputNvoice)), HttpPost]
        public async Task<IActionResult> UpdOutputNvoice([FromForm] OutputNvoice outputNvoice)
        {
            try
            {
                bool data = await _outputNvoice.UpdOutputNvoice(outputNvoice);
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

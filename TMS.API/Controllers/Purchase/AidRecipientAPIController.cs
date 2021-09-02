using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS.Model.Entity.Purchase;
using TMS.Service;

namespace TMS.API.Controllers.Purchase
{
    /// <summary>
    /// 物资领用API
    /// </summary>
    [Route("AidRecipientAPI")]
    [ApiController]
    //[Authorize]
    public class AidRecipientAPIController : Controller
    {
        /// <summary>
        /// 物资管理—物资领用
        /// </summary>
        /// <returns></returns>
        public readonly IAidRecipientService _aidRecipientService;

        private readonly IHostingEnvironment _hostingEnvironment;

        /// <summary>
        /// 构造函数注入
        /// </summary>
        /// <param name="aidRecipientService"></param>
        /// <param name="hostingEnvironment"></param>
        public AidRecipientAPIController(IAidRecipientService aidRecipientService, IHostingEnvironment hostingEnvironment)
        {
            _aidRecipientService = aidRecipientService;
            _hostingEnvironment = hostingEnvironment;
        }
        /// <summary>
        /// 物资领用显示API
        /// </summary>
        /// <param name="Proposer"></param>
        /// <param name="ProposerTime"></param>
        /// <param name="CommonContractStatus"></param>
        /// <param name="CommonContractName"></param>
        /// <param name="AidRecipientsStatus"></param>
        /// <returns></returns>
        [Route(nameof(GetAidRecipient)), HttpGet]
        public IActionResult GetAidRecipient(string Proposer, DateTime? ProposerTime, int CommonContractStatus, string CommonContractName, int AidRecipientsStatus)
        {
            try
            {
                //数据集
                List<AidRecipient> data = _aidRecipientService.GetAidRecipient(Proposer, ProposerTime, CommonContractStatus, CommonContractName, AidRecipientsStatus);
                //判断数据是否为空
                if (data != null)
                {
                    return Ok(new { code = true, meta = 200, msg = "获取成功", count = data.Count, data = data });
                }
                else
                {
                    return Ok(new { code = false, meta = 500, msg = "获取失败", count = data.Count, data = "" });
                }
            }
            catch (Exception)
            {
                return Ok(new { code = false, meta = 500, msg = "获取失败", count = 0, data = "" });
            }

        }

        /// <summary>
        /// 删除领用信息API(假删)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route(nameof(DelAidRecipient)), HttpDelete]
        public IActionResult DelAidRecipient(string id)
        {
            try
            {
                bool data = _aidRecipientService.DelAidRecipient(id);
                if (data == true)
                {
                    return Ok(new { code = data, mate = 200, msg = "删除成功!" });
                }
                else
                {
                    return Ok(new { code = data, mate = 500, msg = "删除失败!" });
                }
            }
            catch (Exception)
            {
                return Ok(new { code = 0, mate = 500, msg = "删除失败,处里异常!" });
            }

        }


        /// <summary>
        /// 物资领用反填详情信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route(nameof(EditAidRecipient)), HttpGet]
        public IActionResult EditAidRecipient(int id)
        {
            //异常处理
            try
            {
                //获取数据集信息
                AidRecipient data = _aidRecipientService.EditAidRecipient(id);
                //判断数据是否存在
                if (data != null)
                {
                    return Ok(new { code = data, mate = 200, msg = "获取相关信息成功!" });
                }
                else
                {
                    return Ok(new { code = data, mate = 500, msg = "获取相关信息失败!" });
                }
            }
            catch (Exception)
            {
                return Ok(new { code = 0, mate = 500, msg = "获取相关信息失败!" });
            }
        }
    }
}

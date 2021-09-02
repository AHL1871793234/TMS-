using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS.Model.Entity.Purchase;
using TMS.Service.Purchase.StockManagement;

namespace TMS.API.Controllers.Purchase
{
    /// <summary>
    /// 物资入库API
    /// </summary>
    [Route("StockManagementAPI")]
    [ApiController]
    //[Authorize]
    public class StockManagementAPIController : Controller
    {
        /// <summary>
        /// 物资管理—物资入库
        /// </summary>
        /// <returns></returns>
        public readonly IStockManagementService _stockManagement;

        private readonly IHostingEnvironment _hostingEnvironment;

        /// <summary>
        /// 构造函数注入
        /// </summary>
        /// <param name="stockManagementService"></param>
        /// <param name="hostingEnvironment"></param>
        public StockManagementAPIController(IStockManagementService stockManagementService, IHostingEnvironment hostingEnvironment)
        {
            _stockManagement = stockManagementService;
            _hostingEnvironment = hostingEnvironment;
        }
        /// <summary>
        /// 物资管理—物资入库—显示API
        /// </summary>
        /// <param name="storageName">货物名称</param>
        /// <param name="TextureId">材料</param>
        /// <param name="placeOfOrigin">产地</param>
        /// /// <param name="payType">支付方式</param>
        /// /// <param name="proposer">登记人</param>
        /// <returns></returns>
        [Route(nameof(GetStorageAdministrations)), HttpGet]
        public IActionResult GetStorageAdministrations(string storageName="", int TextureId=0, string placeOfOrigin="", string payType="", string proposer="")
        {
            try
            {
                //数据集
                List<StorageAdministration> data = _stockManagement.GetStorageAdministrations(storageName, TextureId, placeOfOrigin, payType, proposer);
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
        /// 物资管理—添加物资采购信息API
        /// </summary>
        /// <param name="goodsAndMaterials"></param>
        /// <returns></returns>
        //[Route(nameof(AddStorageAdministrations)), HttpPost]
        //public IActionResult AddStorageAdministrations([FromForm] StorageAdministration storageAdministration)
        //{
        //    //异常处理
        //    try
        //    {
        //        //获取数据集
        //        bool data = _stockManagement.AddStorageAdministration(storageAdministration);
        //        //判断数据是否为真(是否存在)
        //        if (data == true)
        //        {
        //            return Ok(new { code = data, meta = 200, msg = "添加成功" });
        //        }
        //        else
        //        {
        //            return Ok(new { code = data, meta = 500, msg = "添加失败" });
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        return Ok(new { code = 0, meta = 500, msg = "添加失败，处里异常!" });
        //    }
        //}

        /// <summary>
        /// 物资管理—删除入库信息（假删）
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route(nameof(DelStorageAdministrations)), HttpDelete]
        public IActionResult DelStorageAdministrations(string id)
        {
            try
            {
                bool data = _stockManagement.DelStorageAdministrations(id);
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
        /// 物资管理—查看详情(反填)API
        /// </summary>
        /// <param name="id">货物ID</param>
        /// <returns></returns>
        [Route(nameof(EditStorageAdministration)), HttpGet]
        public IActionResult EditStorageAdministration(int id)
        {
            //异常处理
            try
            {
                //获取数据集信息
                StorageAdministration data = _stockManagement.EditStorageAdministration(id);
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

        /// <summary>
        /// 物资管理—修改入库信息API
        /// </summary>
        /// <param name="goodsAndMaterials">货物数据</param>
        /// <returns></returns>
        //[Route(nameof(UpdGoodsAndMaterials)), HttpPost]
        //public IActionResult UpdGoodsAndMaterials([FromForm] GoodsAndMaterials goodsAndMaterials)
        //{
        //    //异常处理
        //    try
        //    {
        //        //获取数据将
        //        bool data = _goodsandmaterials.UpdGoodsAndMaterials(goodsAndMaterials);
        //        //判断数据是否存在
        //        if (data == true)
        //        {
        //            return Ok(new { code = data, mate = 200, msg = "修改成功!" });
        //        }
        //        else
        //        {
        //            return Ok(new { code = data, mate = 500, msg = "修改失败!" });
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        return Ok(new { code = 0, mate = 500, msg = "修改失败!" });
        //    }

        //}
    }
}

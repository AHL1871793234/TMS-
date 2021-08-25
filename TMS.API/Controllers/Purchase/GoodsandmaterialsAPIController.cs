using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS.IRepository;
using TMS.Service;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;
using TMS.Model.Entity.Purchase;

namespace TMS.API.Controllers
{
    /// <summary>
    /// 物资管理API
    /// </summary>
    [Route("GoodsandmaterialsAPI")]
    [ApiController]
    //[Authorize]
    public class GoodsandmaterialsAPIController : Controller
    {
        /// <summary>
        /// 物资管理—物资采购
        /// </summary>
        /// <returns></returns>
        public readonly IGoodsandmaterialsService _goodsandmaterials;

        private readonly IHostingEnvironment _hostingEnvironment;

        /// <summary>
        /// 构造函数注入
        /// </summary>
        /// <param name="goodsandmaterials"></param>
        /// <param name="hostingEnvironment"></param>
        public GoodsandmaterialsAPIController(IGoodsandmaterialsService goodsandmaterials, IHostingEnvironment hostingEnvironment)
        {
            _goodsandmaterials = goodsandmaterials;
            _hostingEnvironment = hostingEnvironment;
        }

        /// <summary>
        /// 物资管理—物资采购—显示API
        /// </summary>
        /// <param name="cargoName">货物名称</param>
        /// <param name="productionPlace">产地</param>
        /// <param name="proposerName">申请人</param>
        /// <returns></returns>
        [Route(nameof(GetGoodsAndMaterials)), HttpGet]
        public IActionResult GetGoodsAndMaterials(string cargoName="", string productionPlace="", string proposerName="")
        {
            try
            {
                //数据集
                List<GoodsAndMaterials> data = _goodsandmaterials.GetGoodsAndMaterials(cargoName, productionPlace, proposerName);
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
        [Route(nameof(AddGoodsAndMaterials)), HttpPost]
        public IActionResult AddGoodsAndMaterials([FromForm]GoodsAndMaterials goodsAndMaterials)
        {
            //异常处理
            try
            {
                //获取数据集
                bool data = _goodsandmaterials.AddGoodsAndMaterials(goodsAndMaterials);
                //判断数据是否为真(是否存在)
                if (data == true)
                {
                    return Ok(new { code = data, meta = 200, msg = "添加成功" });
                }
                else
                {
                    return Ok(new { code = data, meta = 500, msg = "添加失败" });
                }
            }
            catch (Exception)
            {
                return Ok(new { code = 0, meta = 500, msg = "添加失败，处里异常!" });
            }
        }

        /// <summary>
        /// 物资管理—删除采购信息（假删）API
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route(nameof(DelGoodsAndMaterials)), HttpDelete]
        public IActionResult DelGoodsAndMaterials(string id)
        {
            try
            {
                bool data = _goodsandmaterials.DelGoodsAndMaterials(id);
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
        [Route(nameof(EditGoodsAndMaterials)), HttpGet]
        public IActionResult EditGoodsAndMaterials(int id)
        {
            //异常处理
            try
            {
                //获取数据集信息
                GoodsAndMaterials data = _goodsandmaterials.EditGoodsAndMaterials(id);
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
        /// 物资管理—修改采购信息API
        /// </summary>
        /// <param name="goodsAndMaterials">货物数据</param>
        /// <returns></returns>
        [Route(nameof(UpdGoodsAndMaterials)), HttpPost]
        public IActionResult UpdGoodsAndMaterials([FromForm]GoodsAndMaterials goodsAndMaterials)
        {
            //异常处理
            try
            {
                //获取数据将
                bool data = _goodsandmaterials.UpdGoodsAndMaterials(goodsAndMaterials);
                //判断数据是否存在
                if (data == true)
                {
                    return Ok(new { code = data, mate = 200, msg = "修改成功!" });
                }
                else
                {
                    return Ok(new { code = data, mate = 500, msg = "修改失败!" });
                }
            }
            catch (Exception)
            {
                return Ok(new { code = 0, mate = 500, msg = "修改失败!" });
            }
            
        }

        /// <summary>
        /// 物资管理—提交审批API
        /// </summary>
        /// <param name="commonContractStatus"></param>
        /// <returns></returns>
        [Route(nameof(UpdContractStatus)), HttpGet]
        public IActionResult UpdContractStatus(int commonContractStatus)
        {
            try
            {
                bool data = _goodsandmaterials.UpdContractStatus(commonContractStatus);
                if (data == true)
                {
                    return Ok(new { code = data, mate = 200, msg = "提交成功" });
                }
                else
                {
                    return Ok(new { code = data, mate = 500, msg = "提交失败" });
                }
            }
            catch (Exception)
            {
                return Ok(new { code = 0, mate = 500, msg = "提交失败" });
            }
        }
    }
}

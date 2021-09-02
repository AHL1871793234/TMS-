using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS.Model.ViewModel;
using TMS.Service.Purchase.MaterialStatistics;

namespace TMS.API.Controllers.Purchase
{
    /// <summary>
    /// 物资统计API
    /// </summary>
    [Route("MaterialStatisticsAPI")]
    [ApiController]
    //[Authorize]
    public class MaterialStatisticsAPIController : Controller
    {
        /// <summary>
        /// 物资管理—物资统计显示+查询
        /// </summary>
        /// <returns></returns>
        public readonly IMaterialStatisticsService _materialStatisticsService;

        private readonly IHostingEnvironment _hostingEnvironment;

        /// <summary>
        /// 构造函数注入
        /// </summary>
        /// <param name="materialStatisticsService"></param>
        /// <param name="hostingEnvironment"></param>
        public MaterialStatisticsAPIController(IMaterialStatisticsService materialStatisticsService, IHostingEnvironment hostingEnvironment)
        {
            _materialStatisticsService = materialStatisticsService;
            _hostingEnvironment = hostingEnvironment;
        }

        /// <summary>
        /// 物资统计
        /// </summary>
        /// <param name="GoodsAndMaterialsName">货物名称</param>
        /// <param name="GoodsAndMaterialsTypeName">类别</param>
        /// <param name="TextureName">材质</param>
        /// <param name="PlaceOfOrigin">产地</param>
        /// <returns></returns>
        [Route(nameof(GetMaterialStatistics)), HttpGet]
        public IActionResult GetMaterialStatistics(string GoodsAndMaterialsName, string GoodsAndMaterialsTypeName, string TextureName, string PlaceOfOrigin)
        {
            try
            {
                //数据集
                List<MaterialStatisticsViewModel> data = _materialStatisticsService.GetMaterialStatistics(GoodsAndMaterialsName, GoodsAndMaterialsTypeName, TextureName, PlaceOfOrigin);
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

    }
}

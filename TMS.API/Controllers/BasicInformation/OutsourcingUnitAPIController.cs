using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS.Common.MyFilters;
using TMS.Model.Entity;
using TMS.Service.BasicInformation;

namespace TMS.API.Controllers.BasicInformation
{
    /// <summary>
    /// 基本信息-外协单位管理API
    /// </summary>
    [Route("OutsourcingUnitAPI")]
    [ApiController]
    [ApiWrapException]
    [ApiWrapResult]
    //[Authorize]
    public class OutsourcingUnitAPIController : Controller
    {
        private readonly IOutsourcingUnitService _outsourcingUnit;

        /// <summary>
        /// 注入
        /// </summary>
        /// <param name="outsourcingUnit"></param>
        public OutsourcingUnitAPIController(IOutsourcingUnitService outsourcingUnit)
        {
            _outsourcingUnit = outsourcingUnit;
        }

        /// <summary>
        /// 外协单位显示
        /// </summary>
        /// <param name="name">外协单位名称查询</param>
        /// <param name="phone">外协单位手机号查询</param>
        /// <returns></returns>
        [Route(nameof(GetOutsourcingUnits)), HttpGet]
        public async Task<IActionResult> GetOutsourcingUnits(string name, string phone)
        {
            return Ok(await _outsourcingUnit.GetOutsourcingUnits(name, phone));
        }

        /// <summary>
        /// 添加外协单位
        /// </summary>
        /// <param name="model">信息</param>
        /// <returns></returns>
        [Route(nameof(AddOutsourcingUnit)), HttpPost]
        public async Task<IActionResult> AddOutsourcingUnit([FromForm]OutsourcingUnit model)
        {
            return Ok(await _outsourcingUnit.AddOutsourcingUnit(model));
        }

        /// <summary>
        /// 删除外协单位
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        [Route(nameof(DelOutsourcingUnit)), HttpDelete]
        public async Task<IActionResult> DelOutsourcingUnit(string id)
        {
            return Ok(await _outsourcingUnit.DelOutsourcingUnit(id));
        }

        /// <summary>
        /// 反填外协单位
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        [Route(nameof(EditOutsourcingUnit)),HttpGet]
        public async Task<IActionResult> EditOutsourcingUnit(int id)
        {
            return Ok(await _outsourcingUnit.EditOutsourcingUnit(id));
        }

        /// <summary>
        /// 修改外协单位
        /// </summary>
        /// <param name="model">信息</param>
        /// <returns></returns>
        [Route("UpdOutsourcingUnit"), HttpPost]
        public async Task<IActionResult> UpdOutsourcingUnit([FromForm]OutsourcingUnit model)
        {
            return Ok(await _outsourcingUnit.UpdOutsourcingUnit(model));
        }

    }
}

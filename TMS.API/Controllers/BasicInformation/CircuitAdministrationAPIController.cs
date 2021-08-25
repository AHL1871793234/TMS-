using log4net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS.Common.MyFilters;
using TMS.Model.Entity;
using TMS.Service;

namespace TMS.API.Controllers.BasicInformation
{
    /// <summary>
    /// 基本信息—线路API
    /// </summary>
    [Route("CircuitAdministrationAPI")]
    [ApiController]
    [ApiWrapException]
    [ApiWrapResult]
    //[Authorize]
    public class CircuitAdministrationAPIController : Controller
    {
        private ILog log = LogManager.GetLogger(Startup.repository.Name, typeof(CircuitAdministrationAPIController));

        private readonly ICircuitAdministrationService _circuit;

        /// <summary>
        /// 注入
        /// </summary>
        /// <param name="circuit"></param>
        public CircuitAdministrationAPIController(ICircuitAdministrationService circuit)
        {
            _circuit = circuit;
        }

        /// <summary>
        /// 显示线路信息
        /// </summary>
        /// <param name="circuitName">线路名称</param>
        /// <param name="startAddress">起点</param>
        /// <param name="endAddress">终点</param>
        /// <param name="whether">是否是外协</param>
        /// <param name="phone">货主手机号</param>
        /// <param name="units">货主单位</param>
        /// <returns></returns>
        [Route(nameof(GetCircuits)), HttpGet]
        public async Task<IActionResult> GetCircuits(string circuitName, string startAddress, string endAddress, string whether, string phone, string units)
        {
            return Ok(await _circuit.GetCircuits(circuitName, startAddress, endAddress, whether, phone, units));
        }

        /// <summary>
        /// 添加线路信息
        /// </summary>
        /// <param name="model">信息</param>
        /// <returns></returns>
        [Route(nameof(AddCircuit)), HttpPost]
        public async Task<IActionResult> AddCircuit([FromForm]CircuitAdministration model)
        {
            return Ok(await _circuit.AddCircuit(model));
        }

        /// <summary>
        /// 删除线路信息
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        [Route(nameof(DelCircuit)),HttpDelete]
        public async Task<IActionResult> DelCircuit(string id)
        {
            return Ok(await _circuit.DelCircuit(id));
        }

        /// <summary>
        /// 反填线路信息
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        [Route(nameof(EditCircuit)),HttpGet]
        public async Task<IActionResult> EditCircuit(int id)
        {
            return Ok(await _circuit.EditCircuit(id));
        }

        /// <summary>
        /// 修改线路信息
        /// </summary>
        /// <param name="model">信息</param>
        /// <returns></returns>
        [Route(nameof(UpdCircuit)), HttpPost]
        public async Task<IActionResult> UpdCircuit([FromForm]CircuitAdministration model)
        {
            return Ok(await _circuit.UpdCircuit(model));
        }

        /// <summary>
        /// 小修改
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="status">状态</param>
        /// <returns></returns>
        [ Route(nameof(SmallUpd)), HttpPost]
        public async Task<IActionResult> SmallUpd(int id, int status)
        {
            return Ok(await _circuit.SmallUpd(id, status));
        }
        /// <summary>
        /// 抛出异常，验证异常过滤器
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("GetValue")]
        public IActionResult GetValue()
        {
            int i = 10;
            int j = 0;
            int c = i / j;
            return Ok(c);
        }

        /// <summary>
        /// Log4Net测试
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("Log4net")]
        public IActionResult Log4net()
        {
            log.Info("index view");
            log.Error("Controller Error");
            return View();
        }
    }
}

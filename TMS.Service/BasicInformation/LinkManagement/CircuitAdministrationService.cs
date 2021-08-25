using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.IRepository.BasicInformation;
using TMS.Model.Entity.BasicInformation;

namespace TMS.Service
{
    public class CircuitAdministrationService: ICircuitAdministrationService
    {
        private readonly ICircuitAdministrationRepository _circuit;

        public CircuitAdministrationService(ICircuitAdministrationRepository circuit)
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
        public async Task<List<CircuitAdministration>> GetCircuits(string circuitName, string startAddress, string endAddress, string whether, string phone, string units)
        {
            return await _circuit.GetCircuits(circuitName, startAddress, endAddress, whether, phone, units);
        }

        /// <summary>
        /// 反填线路信息
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public async Task<CircuitAdministration> EditCircuit(int id)
        {
            return await _circuit.EditCircuit(id);
        }

        /// <summary>
        /// 删除线路信息
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public async Task<bool> DelCircuit(string id)
        {
            return await _circuit.DelCircuit(id);
        }

        /// <summary>
        /// 添加线路信息
        /// </summary>
        /// <param name="model">信息</param>
        /// <returns></returns>
        public async Task<bool> AddCircuit(CircuitAdministration model)
        {
            return await _circuit.AddCircuit(model);
        }

        /// <summary>
        /// 修改线路信息
        /// </summary>
        /// <param name="model">信息</param>
        /// <returns></returns>
        public async Task<bool> UpdCircuit(CircuitAdministration model)
        {
            return await _circuit.UpdCircuit(model);
        }

        /// <summary>
        /// 小修改
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="status">状态</param>
        /// <returns></returns>
        public async Task<bool> SmallUpd(int id, int status)
        {
            return await _circuit.SmallUpd(id, status);
        }
    }
}

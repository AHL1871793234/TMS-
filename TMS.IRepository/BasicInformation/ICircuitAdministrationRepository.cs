using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Model.Entity;

namespace TMS.IRepository.BasicInformation
{
    public interface ICircuitAdministrationRepository
    {
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
        Task<List<CircuitAdministration>> GetCircuits(string circuitName, string startAddress, string endAddress, string whether, string phone, string units);

        /// <summary>
        /// 反填线路信息
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        Task<CircuitAdministration> EditCircuit(int id);

        /// <summary>
        /// 删除线路信息
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        Task<bool> DelCircuit(string id);

        /// <summary>
        /// 添加线路信息
        /// </summary>
        /// <param name="model">信息</param>
        /// <returns></returns>
        Task<bool> AddCircuit(CircuitAdministration model);

        /// <summary>
        /// 修改线路信息
        /// </summary>
        /// <param name="model">信息</param>
        /// <returns></returns>
        Task<bool> UpdCircuit(CircuitAdministration model);

        /// <summary>
        /// 小修改
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="status">状态</param>
        /// <returns></returns>
        Task<bool> SmallUpd(int id, int status);
    }
}



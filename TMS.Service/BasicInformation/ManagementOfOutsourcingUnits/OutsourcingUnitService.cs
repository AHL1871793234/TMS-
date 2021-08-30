using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.IRepository.BasicInformation;
using TMS.Model.Entity.BasicInformation;

namespace TMS.Service.BasicInformation
{
    public class OutsourcingUnitService: IOutsourcingUnitService
    {
        private readonly IOutsourcingUnitRepository _outsourcing;

        public OutsourcingUnitService(IOutsourcingUnitRepository outsourcing)
        {
            _outsourcing = outsourcing;
        }

        /// <summary>
        /// 外协单位显示
        /// </summary>
        /// <param name="name">外协单位名称查询</param>
        /// <param name="phone">外协单位手机号查询</param>
        /// <returns></returns>
        public async Task<List<OutsourcingUnit>> GetOutsourcingUnits(string name, string phone)
        {
            return await _outsourcing.GetOutsourcingUnits(name, phone);
        }

        /// <summary>
        /// 反填外协单位
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public async Task<OutsourcingUnit> EditOutsourcingUnit(int id)
        {
            return await _outsourcing.EditOutsourcingUnit(id);
        }

        /// <summary>
        /// 删除外协单位
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public async Task<bool> DelOutsourcingUnit(string id)
        {
            return await _outsourcing.DelOutsourcingUnit(id);
        }

        /// <summary>
        /// 添加外协单位
        /// </summary>
        /// <param name="model">信息</param>
        /// <returns></returns>
        public async Task<bool> AddOutsourcingUnit(OutsourcingUnit model)
        {
            return await _outsourcing.AddOutsourcingUnit(model);
        }

        /// <summary>
        /// 修改外协单位
        /// </summary>
        /// <param name="model">信息</param>
        /// <returns></returns>
        public async Task<bool> UpdOutsourcingUnit(OutsourcingUnit model)
        {
            return await _outsourcing.UpdOutsourcingUnit(model);
        }
    }
}

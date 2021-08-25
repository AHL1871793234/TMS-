using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Model.Entity.BasicInformation;

namespace TMS.Service.BasicInformation
{
    public interface IOutsourcingUnitService
    {
        /// <summary>
        /// 外协单位显示
        /// </summary>
        /// <param name="name">外协单位名称查询</param>
        /// <param name="phone">外协单位手机号查询</param>
        /// <returns></returns>
        Task<List<OutsourcingUnit>> GetOutsourcingUnits(string name, string phone);

        /// <summary>
        /// 反填外协单位
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        Task<OutsourcingUnit> EditOutsourcingUnit(int id);

        /// <summary>
        /// 删除外协单位
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        Task<bool> DelOutsourcingUnit(string id);

        /// <summary>
        /// 添加外协单位
        /// </summary>
        /// <param name="model">信息</param>
        /// <returns></returns>
        Task<bool> AddOutsourcingUnit(OutsourcingUnit model);

        /// <summary>
        /// 修改外协单位
        /// </summary>
        /// <param name="model">信息</param>
        /// <returns></returns>
        Task<bool> UpdOutsourcingUnit(OutsourcingUnit model);
    }
}

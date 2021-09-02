using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Model.Entity.Settlement;

namespace TMS.Service
{
    public interface IChargeService
    {
        /// <summary>
        /// 应收费用管理显示+查询
        /// </summary>
        /// <param name="ChargeOwnerOfCargoUnit"></param>
        /// <param name="PayType"></param>
        /// <param name="CheckType"></param>
        /// <param name="CircuitResponsibleName"></param>
        /// <param name="ProfessionalTime"></param>
        /// <returns></returns>
        Task<List<Charge>> GetCharges(string ChargeOwnerOfCargoUnit, string PayType, string CheckType, string CircuitResponsibleName, DateTime? ProfessionalTime);

        /// <summary>
        /// 应收费用管理—添加数据
        /// </summary>
        /// <param name="charge"></param>
        /// <returns></returns>
        Task<bool> AddCharges(Charge charge);

        /// <summary>
        /// 应收费用管理—删除数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DelCharges(string id);

        /// <summary>
        /// 应收费用管理—反填获取详情数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Charge> EditCharge(int id);

        /// <summary>
        /// 应收费用管理—修改数据
        /// </summary>
        /// <param name="charge"></param>
        /// <returns></returns>
        Task<bool> UpdCharge(Charge charge);
    }
}

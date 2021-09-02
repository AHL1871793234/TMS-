using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Model.Entity.Settlement;

namespace TMS.Service
{
    public interface IPayAdministrationService
    {
        /// <summary>
        /// 应付费用管理-显示+查询
        /// </summary>
        /// <param name="ChargeOwnerOfCargoUnit"></param>
        /// <param name="PayType"></param>
        /// <param name="CheckType"></param>
        /// <param name="CircuitResponsibleName"></param>
        /// <param name="ProfessionalTime"></param>
        /// <returns></returns>
        Task<List<PayAdministration>> GetPayAdministration(string ChargeOwnerOfCargoUnit, string PayType, string CheckType, string CircuitResponsibleName, DateTime? ProfessionalTime);

        /// <summary>
        /// 应付费用管理-添加数据
        /// </summary>
        /// <param name="payAdministration"></param>
        /// <returns></returns>
        Task<bool> AddPayAdministration(PayAdministration payAdministration);

        /// <summary>
        /// 应付费用管理-删除数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DelPayAdministration(string id);

        /// <summary>
        /// 应付费用管理-反填获取详细信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<PayAdministration> EditPayAdministration(int id);

        /// <summary>
        /// 应付费用管理-修改数据
        /// </summary>
        /// <param name="charge"></param>
        /// <returns></returns>
        Task<bool> UpdPayAdministration(PayAdministration payAdministration);
    }
}

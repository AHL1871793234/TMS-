using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.IRepository;
using TMS.Model.Entity.Settlement;

namespace TMS.Service
{
    public class PayAdministrationService: IPayAdministrationService
    {
        private readonly IPayAdministrationRepository payAdministrations;

        public PayAdministrationService(IPayAdministrationRepository _payAdministration)
        {
            payAdministrations = _payAdministration;
        }

        /// <summary>
        /// 应付费用管理-显示+查询
        /// </summary>
        /// <param name="ChargeOwnerOfCargoUnit"></param>
        /// <param name="PayType"></param>
        /// <param name="CheckType"></param>
        /// <param name="CircuitResponsibleName"></param>
        /// <param name="ProfessionalTime"></param>
        /// <returns></returns>
        public async Task<List<PayAdministration>> GetPayAdministration(string ChargeOwnerOfCargoUnit, string PayType, string CheckType, string CircuitResponsibleName, DateTime? ProfessionalTime)
        {
            return await payAdministrations.GetPayAdministration(ChargeOwnerOfCargoUnit, PayType, CheckType, CircuitResponsibleName, ProfessionalTime);
        }

        /// <summary>
        /// 应付费用管理-添加数据
        /// </summary>
        /// <param name="payAdministration"></param>
        /// <returns></returns>
        public async Task<bool> AddPayAdministration(PayAdministration payAdministration)
        {
            return await payAdministrations.AddPayAdministration(payAdministration);
        }

        /// <summary>
        /// 应付费用管理-删除数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DelPayAdministration(string id)
        {
            return await payAdministrations.DelPayAdministration(id);
        }

        /// <summary>
        /// 应付费用管理-反填获取相关数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<PayAdministration> EditPayAdministration(int id)
        {
            return await payAdministrations.EditPayAdministration(id);
        }

        /// <summary>
        /// 应付费用管理-修改数据
        /// </summary>
        /// <param name="payAdministration"></param>
        /// <returns></returns>
        public async Task<bool> UpdPayAdministration(PayAdministration payAdministration)
        {
            return await payAdministrations.UpdPayAdministration(payAdministration);
        }
    }
}

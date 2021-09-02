using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.IRepository;
using TMS.Model.Entity.Settlement;
using TMS.Service;

namespace TMS.Service
{
    public class ChargeService: IChargeService
    {
        private readonly IChargeRepository chargeRepository;

        public ChargeService(IChargeRepository _chargeRepository)
        {
            chargeRepository = _chargeRepository;
        }

        /// <summary>
        /// 应收费用管理显示+查询
        /// </summary>
        /// <param name="ChargeOwnerOfCargoUnit"></param>
        /// <param name="PayType"></param>
        /// <param name="CheckType"></param>
        /// <param name="CircuitResponsibleName"></param>
        /// <param name="ProfessionalTime"></param>
        /// <returns></returns>
        public async Task<List<Charge>> GetCharges(string ChargeOwnerOfCargoUnit, string PayType, string CheckType, string CircuitResponsibleName, DateTime? ProfessionalTime)
        {
            return await chargeRepository.GetCharges(ChargeOwnerOfCargoUnit, PayType, CheckType, CircuitResponsibleName, ProfessionalTime);
        }

        /// <summary>
        /// 应收费用管理—添加数据
        /// </summary>
        /// <param name="charge"></param>
        /// <returns></returns>
        public async Task<bool> AddCharges(Charge charge)
        {
            return await chargeRepository.AddCharges(charge);
        }

        /// <summary>
        /// 应收费用管理—数据删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DelCharges(string id)
        {
            return await chargeRepository.DelCharges(id);
        }

        /// <summary>
        /// 应收费用管理—反填数据获取详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Charge> EditCharge(int id)
        {
            return await chargeRepository.EditCharge(id);
        }

        /// <summary>
        /// 应收费用管理—修改数据
        /// </summary>
        /// <param name="charge"></param>
        /// <returns></returns>
        public async Task<bool> UpdCharge(Charge charge)
        {
            return await chargeRepository.UpdCharge(charge);
        }
    }
}

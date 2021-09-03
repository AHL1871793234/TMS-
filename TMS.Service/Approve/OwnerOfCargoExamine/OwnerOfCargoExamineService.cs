using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.IRepository;
using TMS.Model.ViewModel;

namespace TMS.Service
{
    public class OwnerOfCargoExamineService:IOwnerOfCargoExamineService
    {
        private readonly IOwnerOfCargoExamineRepository ownerOfCargoExamineRepository;

        public OwnerOfCargoExamineService(IOwnerOfCargoExamineRepository _ownerOfCargoExamineRepository)
        {
            ownerOfCargoExamineRepository = _ownerOfCargoExamineRepository;
        }

        /// <summary>
        /// 货主合同审批-显示+查询
        /// </summary>
        /// <param name="OwnerOfCargoContractTitle"></param>
        /// <param name="OwnerOfCargoContractUnit"></param>
        /// <param name="OwnerOfCargoContractName"></param>
        /// <param name="CircuitResponsibleName"></param>
        /// <param name="DateOfSigningTime"></param>
        /// <returns></returns>
        public async Task<List<OwnerOfCargoExamineViewModel>> GetOwnerOfCargoExamine(string OwnerOfCargoContractTitle, string OwnerOfCargoContractUnit, string OwnerOfCargoContractName, string CircuitResponsibleName, DateTime? DateOfSigningTime)
        {
            return await ownerOfCargoExamineRepository.GetOwnerOfCargoExamine(OwnerOfCargoContractTitle, OwnerOfCargoContractUnit, OwnerOfCargoContractName, CircuitResponsibleName, DateOfSigningTime);
        }

        /// <summary>
        /// 货主合同审批-查看合同审批详情信息
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<OwnerOfCargoExamineViewModel> EditOwnerOfCargoExamine(string name)
        {
            return await ownerOfCargoExamineRepository.EditOwnerOfCargoExamine(name);
        }

        /// <summary>
        /// 合同通过并转批
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public async Task<bool> EditPassAccommodation(string title)
        {
            return await ownerOfCargoExamineRepository.EditPassAccommodation(title);
        }

        /// <summary>
        /// 拒绝(审批未通过)
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public async Task<bool> EditNoPass(string title)
        {
            return await ownerOfCargoExamineRepository.EditNoPass(title);
        }

        /// <summary>
        /// 审批通过并终止审批
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public async Task<bool> EditPassEnd(string title)
        {
            return await ownerOfCargoExamineRepository.EditPassEnd(title);
        }
    }
}

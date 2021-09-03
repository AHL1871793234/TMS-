using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.IRepository;
using TMS.Model.ViewModel;

namespace TMS.Service
{
    public class OwOutsourcingUnitExamineService: IOwOutsourcingUnitExamineService
    {
        private readonly IOwOutsourcingUnitExamineRepositorycs owOutsourcingUnitExamine;

        public OwOutsourcingUnitExamineService(IOwOutsourcingUnitExamineRepositorycs _owOutsourcingUnitExamine)
        {
            owOutsourcingUnitExamine = _owOutsourcingUnitExamine;
        }

        /// <summary>
        /// 承运合同审批-显示+查询
        /// </summary>
        /// <param name="AcceptContractTitle"></param>
        /// <param name="AcceptContractUnit"></param>
        /// <param name="OwnerOfCargoContractName"></param>
        /// <param name="CircuitResponsibleName"></param>
        /// <param name="DateOfSigningTime"></param>
        /// <returns></returns>
        public async Task<List<OwOutsourcingUnitExamineViewModel>> GetOwOutsourcingUnitExamine(string AcceptContractTitle, string AcceptContractUnit, string OwnerOfCargoContractName, string CircuitResponsibleName, DateTime? DateOfSigningTime)
        {
            return await owOutsourcingUnitExamine.GetOwOutsourcingUnitExamine(AcceptContractTitle, AcceptContractUnit, OwnerOfCargoContractName, CircuitResponsibleName, DateOfSigningTime);
        }

        /// <summary>
        /// 货主合同审批-查看合同审批详情信息
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<OwOutsourcingUnitExamineViewModel> EditOwOutsourcingUnitExamine(string name)
        {
            return await owOutsourcingUnitExamine.EditOwOutsourcingUnitExamine(name);
        }

        /// <summary>
        /// 合同通过并转批
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public async Task<bool> EditPassAccommodation(string title)
        {
            return await owOutsourcingUnitExamine.EditPassAccommodation(title);
        }

        /// <summary>
        /// 拒绝(审批未通过)
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public async Task<bool> EditNoPass(string title)
        {
            return await owOutsourcingUnitExamine.EditNoPass(title);
        }

        /// <summary>
        /// 审批通过并终止审批
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public async Task<bool> EditPassEnd(string title)
        {
            return await owOutsourcingUnitExamine.EditPassEnd(title);
        }
    }
}

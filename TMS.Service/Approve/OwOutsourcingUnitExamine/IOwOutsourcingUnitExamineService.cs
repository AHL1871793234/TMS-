using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Model.ViewModel;

namespace TMS.Service
{
    public interface IOwOutsourcingUnitExamineService
    {
        /// <summary>
        /// 货主合同审批-显示+查询
        /// </summary>
        /// <param name="AcceptContractTitle"></param>
        /// <param name="AcceptContractUnit"></param>
        /// <param name="OwnerOfCargoContractName"></param>
        /// <param name="CircuitResponsibleName"></param>
        /// <param name="DateOfSigningTime"></param>
        /// <returns></returns>
        Task<List<OwOutsourcingUnitExamineViewModel>> GetOwOutsourcingUnitExamine(string AcceptContractTitle, string AcceptContractUnit, string OwnerOfCargoContractName, string CircuitResponsibleName, DateTime? DateOfSigningTime);

        /// <summary>
        /// 货主合同审批-查看合同审批详情信息
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<OwOutsourcingUnitExamineViewModel> EditOwOutsourcingUnitExamine(string name);

        /// <summary>
        /// 合同通过并转批
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        Task<bool> EditPassAccommodation(string title);

        /// <summary>
        /// 拒绝(审批未通过)
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        Task<bool> EditNoPass(string title);

        /// <summary>
        /// 审批通过并终止审批
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        Task<bool> EditPassEnd(string title);
    }
}

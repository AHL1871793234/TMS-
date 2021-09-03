﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Model.ViewModel;

namespace TMS.IRepository
{
    /// <summary>
    /// 货主合同审批
    /// </summary>
    public interface IOwnerOfCargoExamineRepository
    {
        /// <summary>
        /// 货主合同审批-显示+查询
        /// </summary>
        /// <param name="OwnerOfCargoContractTitle"></param>
        /// <param name="OwnerOfCargoContractUnit"></param>
        /// <param name="OwnerOfCargoContractName"></param>
        /// <param name="CircuitResponsibleName"></param>
        /// <param name="DateOfSigningTime"></param>
        /// <returns></returns>
        Task<List<OwnerOfCargoExamineViewModel>> GetOwnerOfCargoExamine(string OwnerOfCargoContractTitle, string OwnerOfCargoContractUnit, string OwnerOfCargoContractName, string CircuitResponsibleName, DateTime? DateOfSigningTime);

        /// <summary>
        /// 货主合同审批-查看合同审批详情信息
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<OwnerOfCargoExamineViewModel> EditOwnerOfCargoExamine(string name);

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

using System;
using System.Collections.Generic;

#nullable disable

namespace TMS.Model.Entity.Approve
{
    /// <summary>
    /// 承运外协合同审批ID
    /// </summary>
    public partial class OwOutsourcingUnitExamine
    {
        /// <summary>
        /// 承运外协合同审批ID
        /// </summary>
        public int OwOutsourcingUnitExamineId { get; set; }
        /// <summary>
        /// 承运外协合同外键ID
        /// </summary>
        public int? AcceptContractId { get; set; }
        /// <summary>
        /// 审批表外键ID
        /// </summary>
        public int? ExamineId { get; set; }
        /// <summary>
        /// 承运合同审批状态
        /// </summary>
        public int? OwOutsourcingUnitExamineStatus { get; set; }
    }
}

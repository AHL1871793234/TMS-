using System;
using System.Collections.Generic;

#nullable disable

namespace TMS.Model.Entity.Approve
{
    /// <summary>
    /// 通用合同审批
    /// </summary>
    public partial class CommonContractExamine
    {
        /// <summary>
        /// 通用合同审批ID
        /// </summary>
        public int CommonContractExamineId { get; set; }
        /// <summary>
        /// 通用合同外键ID
        /// </summary>
        public int? CommonContractId { get; set; }
        /// <summary>
        /// 审批表外键ID
        /// </summary>
        public int? ExamineId { get; set; }
        /// <summary>
        /// 通用合同审批状态
        /// </summary>
        public int? CommonContractExamineStatus { get; set; }
    }
}

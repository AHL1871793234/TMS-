using System;
using System.Collections.Generic;

#nullable disable

namespace TMS.Model.Entity.Approve
{
    /// <summary>
    /// 货主合同审批
    /// </summary>
    public partial class OwnerOfCargoExamine
    {
        /// <summary>
        /// 货主审批ID
        /// </summary>
        public int OwnerOfCargoExamineId { get; set; }
        /// <summary>
        /// 货主合同外键ID
        /// </summary>
        public int? OwnerOfCargoContractId { get; set; }
        /// <summary>
        /// 审批表外键ID
        /// </summary>
        public int? ExamineId { get; set; }
        /// <summary>
        /// 货主合同审批状态
        /// </summary>
        public int? OwnerOfCargoExamineStatus { get; set; }
    }
}

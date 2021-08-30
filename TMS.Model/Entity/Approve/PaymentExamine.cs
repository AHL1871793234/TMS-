using System;
using System.Collections.Generic;

#nullable disable

namespace TMS.Model.Entity.Approve
{
    /// <summary>
    /// 付款审批
    /// </summary>
    public partial class PaymentExamine
    {
        /// <summary>
        /// 付款审批ID
        /// </summary>
        public int PaymentExamineId { get; set; }
        /// <summary>
        /// 付款管理外键ID
        /// </summary>
        public int? PaymentId { get; set; }
        /// <summary>
        /// 审批表外键ID
        /// </summary>
        public int? ExamineId { get; set; }
        /// <summary>
        /// 付款审批状态
        /// </summary>
        public int? PaymentExamineStatus { get; set; }
    }
}

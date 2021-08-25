using System;
using System.Collections.Generic;

#nullable disable

namespace TMS.Model.Entity.Approve
{
    /// <summary>
    /// 物资领用审批
    /// </summary>
    public partial class AidRecipientsExamine
    {
        /// <summary>
        /// 物资领用审批ID
        /// </summary>
        public int AidRecipientsExamineId { get; set; }
        /// <summary>
        /// 物资采购外键ID
        /// </summary>
        public int? AidRecipientsId { get; set; }
        /// <summary>
        /// 审批表外键ID
        /// </summary>
        public int? ExamineId { get; set; }
        /// <summary>
        /// 物资领用审批状态
        /// </summary>
        public int? AidRecipientsExamineStatus { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Model.Entity.Personnel
{
    /// <summary>
    /// 审批表
    /// </summary>
    public class ExamineModel
    {
        /// <summary>
        /// 审批ID
        /// </summary>
        public int ExamineID	{ get; set; }
        /// <summary>
        /// 审批人
        /// </summary>
        public int ExamineName { get; set; }
        /// <summary>
        /// 审批状态
        /// </summary>
        public int ExamineStatus { get; set; }
    }
}

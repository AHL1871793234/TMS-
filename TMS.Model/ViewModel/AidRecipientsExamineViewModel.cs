using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Model.ViewModel
{
    /// <summary>
    /// 物资领用审批
    /// </summary>
    public class AidRecipientsExamineViewModel
    {
        public int AidRecipientsTitle { get; set; }
        public int AidRecipientsContent { get; set; }
        public int Proposer { get; set; }
        public int ProposerTime { get; set; }
        public int Remark { get; set; }
        public int CreateTime { get; set; }
        public int ExamineStatus { get; set; }
        public int ExamineName { get; set; }
    }
}

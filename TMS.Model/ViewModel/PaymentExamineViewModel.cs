using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Model.ViewModel
{
    /// <summary>
    /// 付款审批联查
    /// </summary>
    public class PaymentExamineViewModel
    {
        public string PaymentTitle { get; set; }
        public string PaymentContent { get; set; }
        public DateTime PayTime { get; set; }
        public string PayType { get; set; }
        public string PayName { get; set; }
        public string OpeningBank { get; set; }
        public string BankCard { get; set; }
        public string Proposer { get; set; }
        public string Remark { get; set; }
        public DateTime CreateTime { get; set; }
        public int ExamineStatus { get; set; }
        public string ExamineName { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Model.ViewModel
{
    /// <summary>
    /// 通用合同审批
    /// </summary>
    public class CommonContractExamineViewModel
    {
        public string CommonContractNo { get; set; }
        public string CommonContractTitle { get; set; }
        public string CommonContractUnit { get; set; }
        public string OwnerOfCargoContractName { get; set; }
        public string CommonContractCircuit { get; set; }
        public int TonRunPrice { get; set; }
        public int CharteredBusConditionTonNum { get; set; }
        public int CharteredBusPrice { get; set; }
        public DateTime DateOfSigningTime { get; set; }
        public string CircuitResponsibleName { get; set; }
        public DateTime CreateTime { get; set; }
        public int ExamineStatus { get; set; }
        public string ExamineName { get; set; }
    }
}

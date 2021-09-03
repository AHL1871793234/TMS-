using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Model.ViewModel
{
    /// <summary>
    /// 承运合同审批
    /// </summary>
    public class OwOutsourcingUnitExamineViewModel
    {
        public string AcceptContractNo { get; set; }
        public string AcceptContractTitle { get; set; }
        public string AcceptContractUnit { get; set; }
        public string OwnerOfCargoContractName { get; set; }
        public string AcceptContractCircuit { get; set; }
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

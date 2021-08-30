using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Model.Entity.Contract
{
    /// <summary>
    /// 承运合同管理
    /// </summary>
    public class AcceptContract
    {
        /// <summary>
        /// 合同ID
        /// </summary>
        public int AcceptContractID { get; set; }
        /// <summary>
        /// 合同编号
        /// </summary>
        public string AcceptContractNo { get; set; }
        /// <summary>
        /// 合同标题
        /// </summary>
        public string AcceptContractTitle { get; set; }
        /// <summary>
        /// 承运单位
        /// </summary>
        public string AcceptContractUnit { get; set; }
        /// <summary>
        /// 承运负责人
        /// </summary>
        public string OwnerOfCargoContractName { get; set; }
        /// <summary>
        /// 路线
        /// </summary>
        public string AcceptContractCircuit { get; set; }
        /// <summary>
        /// 吨运价
        /// </summary>
        public decimal TonRunPrice { get; set; }
        /// <summary>
        /// 包车条件吨位
        /// </summary>
        public int CharteredBusConditionTonNum { get; set; }
        /// <summary>
        /// 包车金额
        /// </summary>
        public int CharteredBusPrice { get; set; }
        /// <summary>
        /// 签订日期
        /// </summary>
        public DateTime DateOfSigningTime { get; set; }
        /// <summary>
        /// 合同标的或项目说明
        /// </summary>
        public string OwnerOfCargoContractRemark { get; set; }
        /// <summary>
        /// 合同主要条款/变更条款
        /// </summary>
        public string OwnerOfCargoContractPrice { get; set; }
        /// <summary>
        /// 合同文本（附件）
        /// </summary>
        public string OwnerOfCargoContractFile { get; set; }
        /// <summary>
        /// 经办人
        /// </summary>
        public string CircuitResponsibleName { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 审核状态
        /// </summary>
        public int AcceptContractStatus { get; set; }
        /// <summary>
        /// 审核人
        /// </summary>
        public string CommonContractName { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int OwnerOfCargoContractStatus { get; set; }
    }
}

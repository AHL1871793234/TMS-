using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Model.Entity.Settlement
{
    /// <summary>
    /// 应收费用管理表
    /// </summary>
    public class Charge
    {
        /// <summary>
        /// 应收费用管理ID
        /// </summary>
        public int ChargeID { get; set; }
        /// <summary>
        /// 业务单号
        /// </summary>
        public string ProfessionalNo { get; set; }
        /// <summary>
        /// 货主单位
        /// </summary>
        public string ChargeOwnerOfCargoUnit { get; set; }
        /// <summary>
        /// 支付方式(1:微信支付2：支付宝支付3：银联支付4：企业转账5：线下支付6：其他)
        /// </summary>
        public string PayType { get; set; }
        /// <summary>
        /// 吨位(立方米)
        /// </summary>
        public int Tonnage { get; set; }
        /// <summary>
        /// 单价(元/立方米)
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// 业务日期
        /// </summary>
        public DateTime ProfessionalTime { get; set; }
        /// <summary>
        /// 经办人
        /// </summary>
        public string CircuitResponsibleName { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 核对状态
        /// </summary>
        public string CheckType { get; set; }
        /// <summary>
        /// 核对人
        /// </summary>
        public string CheckName { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int ChargeStatus { get; set; }
    }
}

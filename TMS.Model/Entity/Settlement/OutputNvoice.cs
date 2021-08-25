using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Model.Entity.Settlement
{
    /// <summary>
    /// 销项发票管理
    /// </summary>
    public class OutputNvoice
    {
        /// <summary>
        /// 销项发票管理ID
        /// </summary>
        public int OutputNvoiceeID { get; set; }
        /// <summary>
        /// 发票号
        /// </summary>
        public string OutputNvoiceNo { get; set; }
        /// <summary>
        /// 客户名称
        /// </summary>
        public string OutputNvoiceName { get; set; }
        /// <summary>
        /// 发票类型
        /// </summary>
        public string ReceiptsNvoiceType { get; set; }
        /// <summary>
        /// 发票金额
        /// </summary>
        public int InvoicePrice { get; set; }
        /// <summary>
        /// 税率
        /// </summary>
        public decimal TaxRate { get; set; }
        /// <summary>
        /// 开票日期
        /// </summary>
        public DateTime InvoiceTime { get; set; }

        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 制单人
        /// </summary>
        public string PreparedBy { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int ReceiptsNvoiceStatus { get; set; }
    }
}

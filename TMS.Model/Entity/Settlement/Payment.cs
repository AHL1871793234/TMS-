using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Model.Entity.Settlement
{
    /// <summary>
    /// 付款管理
    /// </summary>
    public class Payment
    {
        /// <summary>
        /// 付款管理ID
        /// </summary>
        public int PaymentID { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string PaymentTitle { get; set; }
        /// <summary>
        /// 用途描述
        /// </summary>
        public string PaymentContent { get; set; }
        /// <summary>
        /// 付款金额
        /// </summary>
        public int PayPrice { get; set; }
        /// <summary>
        /// 付款方式
        /// </summary>
        public string PayType { get; set; }
        /// <summary>
        /// 支付对象
        /// </summary>
        public string PayName { get; set; }
        /// <summary>
        /// 开户行
        /// </summary>
        public string OpeningBank { get; set; }
        /// <summary>
        /// 银行账号
        /// </summary>
        public string BankCard { get; set; }
        /// <summary>
        /// 申请人
        /// </summary>
        public string Proposer { get; set; }
        /// <summary>
        /// 付款日期
        /// </summary>
        public DateTime PayTime { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 审核状态
        /// </summary>
        public int CommonContractStatus { get; set; }
        /// <summary>
        /// 审核人
        /// </summary>
        public string CommonContractName { get; set; }
        /// <summary>
        /// 付款状态
        /// </summary>
        public int PaymentStatus { get; set; }
    }
}

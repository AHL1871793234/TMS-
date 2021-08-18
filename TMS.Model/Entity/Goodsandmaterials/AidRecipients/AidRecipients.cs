using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Model.Entity.Goodsandmaterials.AidRecipients
{
    /// <summary>
    /// 物资领用管理
    /// </summary>
    public class AidRecipients
    {
        /// <summary>
        /// 物资领用id
        /// </summary>
        public int AidRecipientsID { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string AidRecipientsTitle { get; set; }
        /// <summary>
        /// 用途描述
        /// </summary>
        public string AidRecipientsContent { get; set; }
        /// <summary>
        /// 领用人
        /// </summary>
        public string Proposer { get; set; }
        /// <summary>
        /// 领用日期
        /// </summary>
        public DateTime ProposerTime { get; set; }
        /// <summary>
        /// 领用数量
        /// </summary>
        public int ProposerNum { get; set; }
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
        /// 物资领用状态
        /// </summary>
        public int AidRecipientsStatus { get; set; }
    }
}

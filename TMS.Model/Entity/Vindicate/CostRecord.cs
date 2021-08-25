using System;
using System.Collections.Generic;

#nullable disable

namespace TMS.Model.Vindicate
{
    /// <summary>
    /// 费用记录
    /// </summary>
    public partial class CostRecord
    {
        /// <summary>
        /// 费用ID
        /// </summary>
        public int CostId { get; set; }
        /// <summary>
        /// 费用标题
        /// </summary>
        public string CostTitle { get; set; }
        /// <summary>
        /// 费用类型
        /// </summary>
        public string CostType { get; set; }
        /// <summary>
        /// 车牌号
        /// </summary>
        public string LicensePlateNumber { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        public decimal? CostPrice { get; set; }
        /// <summary>
        /// 负责人
        /// </summary>
        public string CostName { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string CostContent { get; set; }
        /// <summary>
        /// 使用时间
        /// </summary>
        public DateTime? UseTime { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime { get; set; }
        /// <summary>
        /// 使用状态
        /// </summary>
        public int? AccidentStatus { get; set; }
    }
}

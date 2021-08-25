using System;
using System.Collections.Generic;

#nullable disable

namespace TMS.Model.Entity.Vindicate
{
    /// <summary>
    /// 事故记录表
    /// </summary>
    public partial class AccidentRecord
    {
        /// <summary>
        /// 事故ID
        /// </summary>
        public int AccidentId { get; set; }
        /// <summary>
        /// 事故标题
        /// </summary>
        public string AccidentTitle { get; set; }
        /// <summary>
        /// 车牌号
        /// </summary>
        public string LicensePlateNumber { get; set; }
        /// <summary>
        /// 事故描述
        /// </summary>
        public string AccidentContent { get; set; }
        /// <summary>
        /// 直接经济损失
        /// </summary>
        public string AccidentInancialLoss { get; set; }
        /// <summary>
        /// 保险公司赔偿
        /// </summary>
        public decimal? InsuranceCompanyIndemnity { get; set; }
        /// <summary>
        /// 公司净损失
        /// </summary>
        public int? CompanyNetLoss { get; set; }
        /// <summary>
        /// 事发人
        /// </summary>
        public string AccidentName { get; set; }
        /// <summary>
        /// 事故日期
        /// </summary>
        public DateTime? AccidentTime { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime { get; set; }
        /// <summary>
        /// 事故状态
        /// </summary>
        public int? AccidentStatus { get; set; }
    }
}

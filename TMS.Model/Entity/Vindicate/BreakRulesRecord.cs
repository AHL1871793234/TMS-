using System;
using System.Collections.Generic;

#nullable disable

namespace TMS.Model.Entity.Entity.Vindicate
{
    /// <summary>
    /// 违章记录管理表
    /// </summary>
    public partial class BreakRulesRecord
    {
        /// <summary>
        /// 违章记录Id
        /// </summary>
        public int BreakRulesId { get; set; }
        /// <summary>
        /// 违章标题
        /// </summary>
        public string BreakRulesTitle { get; set; }
        /// <summary>
        /// 车牌号
        /// </summary>
        public string LicensePlateNumber { get; set; }
        /// <summary>
        /// 违章内容
        /// </summary>
        public string BreakRulesContent { get; set; }
        /// <summary>
        /// 处罚结果
        /// </summary>
        public string BreakRulesResult { get; set; }
        /// <summary>
        /// 违章人
        /// </summary>
        public string BreakRulesName { get; set; }
        /// <summary>
        /// 违章日期
        /// </summary>
        public DateTime? BreakRulesTime { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime { get; set; }
        /// <summary>
        /// 违章状态
        /// </summary>
        public int? BreakRulesStatus { get; set; }
    }
}

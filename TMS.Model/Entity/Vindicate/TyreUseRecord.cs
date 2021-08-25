using System;
using System.Collections.Generic;

#nullable disable

namespace TMS.Model.Entity.Vindicate
{
    /// <summary>
    /// 轮胎使用记录
    /// </summary>
    public partial class TyreUseRecord
    {
        /// <summary>
        /// 使用ID
        /// </summary>
        public int TyreUseRecordId { get; set; }
        /// <summary>
        /// 车牌号
        /// </summary>
        public string LicensePlateNumber { get; set; }
        /// <summary>
        /// 轮胎品牌
        /// </summary>
        public string TyreType { get; set; }
        /// <summary>
        /// 规格
        /// </summary>
        public string TyreSpecification { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public int? Number { get; set; }
        /// <summary>
        /// 使用人
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 使用日期
        /// </summary>
        public DateTime? UserTime { get; set; }
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
        public int? TyreUseStatus { get; set; }
    }
}

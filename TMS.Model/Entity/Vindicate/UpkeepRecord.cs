using System;
using System.Collections.Generic;

#nullable disable

namespace TMS.Model.Entity.Vindicate
{
    /// <summary>
    /// 保养记录表
    /// </summary>
    public partial class UpkeepRecord
    {
        /// <summary>
        /// 保养ID
        /// </summary>
        public int UpkeepRecordId { get; set; }
        /// <summary>
        /// 保养标题
        /// </summary>
        public string UpkeepRecordTitle { get; set; }
        /// <summary>
        /// 车牌号
        /// </summary>
        public string LicensePlateNumber { get; set; }
        /// <summary>
        /// 保养金额
        /// </summary>
        public decimal? UpkeepRecordPrice { get; set; }
        /// <summary>
        /// 保养负责人
        /// </summary>
        public string UpkeepRecordName { get; set; }
        /// <summary>
        /// 当前里程数
        /// </summary>
        public int? NowMileage { get; set; }
        /// <summary>
        /// 上次里程数
        /// </summary>
        public int? LastMileage { get; set; }
        /// <summary>
        /// 保养项目
        /// </summary>
        public string UpkeepRecordContent { get; set; }
        /// <summary>
        /// 保养日期
        /// </summary>
        public DateTime? UpkeepRecordNowTime { get; set; }
        /// <summary>
        /// 上次保养日期
        /// </summary>
        public DateTime? UpkeepRecordLastTime { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime { get; set; }
        /// <summary>
        /// 保养状态
        /// </summary>
        public int? UpkeepRecordStatus { get; set; }
    }
}

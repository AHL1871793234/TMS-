using System;
using System.Collections.Generic;

#nullable disable

namespace TMS.Model.Entity.Vindicate
{
    /// <summary>
    /// 维修记录
    /// </summary>
    public partial class MaintainRecord
    {
        /// <summary>
        /// 维修ID
        /// </summary>
        public int MaintainRecordId { get; set; }
        /// <summary>
        /// 维修标题
        /// </summary>
        public string MaintainRecordTitle { get; set; }
        /// <summary>
        /// 维修类型
        /// </summary>
        public string MaintainRecordType { get; set; }
        /// <summary>
        /// 车牌号
        /// </summary>
        public string LicensePlateNumber { get; set; }
        /// <summary>
        /// 维修金额
        /// </summary>
        public decimal? MaintainRecordPrice { get; set; }
        /// <summary>
        /// 维修负责人
        /// </summary>
        public string MaintainRecordName { get; set; }
        /// <summary>
        /// 维修描述
        /// </summary>
        public string MaintainRecordContent { get; set; }
        /// <summary>
        /// 维修日期
        /// </summary>
        public DateTime? MaintainRecordTime { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime { get; set; }
        /// <summary>
        /// 维修状态
        /// </summary>
        public int? MaintainRecordStatus { get; set; }
    }
}

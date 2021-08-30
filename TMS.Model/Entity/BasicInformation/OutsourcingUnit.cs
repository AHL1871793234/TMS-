using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Model.Entity.BasicInformation
{
    /// <summary>
    /// 外协单位表
    /// </summary>
    public class OutsourcingUnit
    {
        /// <summary>
        /// 外协ID
        /// </summary>
        public int OutsourcingUnitID { get; set; }
        /// <summary>
        /// 外协单位名称
        /// </summary>
        public string OutsourcingUnitName { get; set; }
        /// <summary>
        /// 外协单位邮箱
        /// </summary>
        public string OutsourcingUnitEmail { get; set; }
        /// <summary>
        /// 外协单位固定电话
        /// </summary>
        public string OutsourcingUnitTelephone { get; set; }
        /// <summary>
        /// 外协单位手机号
        /// </summary>
        public string OutsourcingUnitPhone { get; set; }
        /// <summary>
        /// 外协单位地址
        /// </summary>
        public string OutsourcingUnitPlace { get; set; }
        /// <summary>
        /// 负责人
        /// </summary>
        public string OutsourcingUnitResponsibleName { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime OutsourcingUnitCreateTime { get; set; }
    }
}

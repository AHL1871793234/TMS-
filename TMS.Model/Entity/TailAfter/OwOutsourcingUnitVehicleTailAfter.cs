using System;
using System.Collections.Generic;

#nullable disable

namespace TMS.Model.Entity.TailAfter
{
    /// <summary>
    /// 承运合同跟踪表
    /// </summary>
    public partial class OwOutsourcingUnitVehicleTailAfter
    {
        /// <summary>
        /// 跟踪管理ID
        /// </summary>
        public int VehicleTailAfterId { get; set; }
        /// <summary>
        /// 外协合同外键ID
        /// </summary>
        public int? AcceptContractId { get; set; }
        /// <summary>
        /// 线路管理外键ID
        /// </summary>
        public int? CircuitAdministrationId { get; set; }
        /// <summary>
        /// 异常警报
        /// </summary>
        public int? AbnormalAlarm { get; set; }
        /// <summary>
        /// 运输状态（运输中、未起运、已完成）
        /// </summary>
        public int? OwnerOfCargoRunStatus { get; set; }
        /// <summary>
        /// 跟踪状态
        /// </summary>
        public int? VehicleTailAfterStatus { get; set; }
    }
}

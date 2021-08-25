using System;
using System.Collections.Generic;

#nullable disable

namespace TMS.Model.Entity.Setting
{
    /// <summary>
    /// 职位表
    /// </summary>
    public partial class PositionModel
    {
        public int PositionId { get; set; }
        public string PositionName { get; set; }
        public int? PositionStatus { get; set; }
    }
}

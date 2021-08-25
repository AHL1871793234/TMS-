using System;
using System.Collections.Generic;

#nullable disable

namespace TMS.Model.Entity.Setting
{
    /// <summary>
    /// 职位管理
    /// </summary>
    public partial class Position
    {
        /// <summary>
        /// 职位管理ID
        /// </summary>
        public int PositionId { get; set; }
        /// <summary>
        /// 职位名称
        /// </summary>
        public string PositionName { get; set; }
        /// <summary>
        /// 别名
        /// </summary>
        public string AnotherName { get; set; }
        /// <summary>
        /// 所属部门
        /// </summary>
        public string SuoDepartment { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Model.Entity.BasicInformation
{
    /// <summary>
    /// 线路管理表
    /// </summary>
    public class CircuitAdministration
    {
        /// <summary>
        /// 线路Id
        /// </summary>
        public int CircuitAdministrationID { get; set; }
        /// <summary>
        /// 线路名称
        /// </summary>
        public string CircuitName { get; set; }
        /// <summary>
        /// 起点
        /// </summary>
        public string CircuitStartPlace { get; set; }
        /// <summary>
        /// 终点
        /// </summary>
        public string CircuitEndPlace { get; set; }
        /// <summary>
        /// 是否外协
        /// </summary>
        public string IsOutsource { get; set; }
        /// <summary>
        /// 货主姓名
        /// </summary>
        public string OwnerName { get; set; }
        /// <summary>
        /// 货主手机号
        /// </summary>
        public string OwnerPHone { get; set; }
        /// <summary>
        /// 货主单位
        /// </summary>
        public string OwnerUnit { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 线路状态
        /// </summary>
        public int CircuitStatus { get; set; }

    }
}

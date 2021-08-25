using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Model.Entity.Personnel.Employeeregistration
{
    /// <summary>
    /// 职位表
    /// </summary>
    public class PositionModel
    {
        /// <summary>
        /// 职位主键自增不为空
        /// </summary>
        public int PositionID { get; set; }
        /// <summary>
        /// 职位名称
        /// </summary>
        public string PositionName { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int PositionStatus { get; set; }

    }
}

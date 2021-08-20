using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Model.Entity.BasicInformation
{
    /// <summary>
    /// 油费管理表
    /// </summary>
    public class PostageAdministration
    {
        /// <summary>
        /// 油费Id
        /// </summary>
        public int PostageAdministrationID { get; set; }
        /// <summary>
        /// 车牌号
        /// </summary>
        public string CarNumber { get; set; }
        /// <summary>
        /// 加油费用/元
        /// </summary>
        public int ComeOnCost { get; set; }
        /// <summary>
        /// 加油量/L
        /// </summary>
        public int FuelCharge { get; set; }
        /// <summary>
        /// 起始公里数
        /// </summary>
        public int StartKilometre { get; set; }
        /// <summary>
        /// 支付方式（1:微信支付2：支付宝支付3：银联支付4：企业转账5：线下支付6：其他)
        /// </summary>
        public string PayType { get; set; }
        /// <summary>
        /// 经办人
        /// </summary>
        public string ResponsiblePerson { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}

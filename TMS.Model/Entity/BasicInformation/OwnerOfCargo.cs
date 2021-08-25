using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Model.Entity.BasicInformation
{
    /// <summary>
    /// 基础信息-货主管理 
    /// </summary>
    public class OwnerOfCargo
    {
        /// <summary>
        /// 货主管理ID
        /// </summary>
        public int OwnerOfCargoID { get; set; }
        /// <summary>
        /// 货主名称
        /// </summary>
        public string OwnerOfCargoName { get; set; }
        /// <summary>
        /// 货主手机号
        /// </summary>
        public string OwnerOfCargoPhone { get; set; }
        /// <summary>
        /// 单位名称
        /// </summary>
        public string CompanyName { get; set; }
        /// <summary>
        /// 联系地址
        /// </summary>
        public string ContactAddress { get; set; }
        /// <summary>
        /// 驾驶证有效日期
        /// </summary>
        public DateTime DrivingLicenceTime { get; set; }
        /// <summary>
        /// 驾驶证照片
        /// </summary>
        public string DrivingLicenceImg { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }



        public string CreateDate { get { return CreateTime.ToString("yyyy-MM-dd HH:mm"); } }
        public string DrivingLicenceDate { get { return DrivingLicenceTime.ToString("yyyy-MM-dd"); } }
    }
}









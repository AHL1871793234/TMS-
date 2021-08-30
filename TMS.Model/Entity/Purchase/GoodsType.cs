using System;
using System.Collections.Generic;

#nullable disable

namespace TMS.Model.Entity.Purchase
{
    /// <summary>
    /// 物资类别表
    /// </summary>
    public partial class GoodsType
    {
        /// <summary>
        /// 类别ID
        /// </summary>
        public int GoodsAndMaterialsTypeId { get; set; }
        /// <summary>
        /// 类别名称
        /// </summary>
        public string GoodsAndMaterialsTypeName { get; set; }
    }
}

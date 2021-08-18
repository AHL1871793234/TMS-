using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Model.Entity.Goodsandmaterials.SuppliesPurchasing
{
    /// <summary>
    /// 物资类别表
    /// </summary>
    public class GoodsType
    {
        /// <summary>
        /// 类别ID
        /// </summary>
        public int GoodsAndMaterialsTypeID { get; set; }
        /// <summary>
        /// 类别名称
        /// </summary>
        public string GoodsAndMaterialsTypeName { get; set; }
    }
}

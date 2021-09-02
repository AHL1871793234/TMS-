using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Model.ViewModel
{
    /// <summary>
    /// 物资统计视图
    /// </summary>
    public class MaterialStatisticsViewModel
    {
        /// <summary>
        /// 货物名称
        /// </summary>
        public string GoodsAndMaterialsName { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public string GoodsAndMaterialsTypeName { get; set; }
        /// <summary>
        /// 材质
        /// </summary>
        public string TextureName { get; set; }
        /// <summary>
        /// 规格
        /// </summary>
        public string Specification { get; set; }
        /// <summary>
        /// 产地
        /// </summary>
        public string PlaceOfOrigin { get; set; }
        /// <summary>
        /// 期间采购数量
        /// </summary>
        public int GoodsNumber { get; set; }
        /// <summary>
        /// 期间领用数量
        /// </summary>
        public int ProposerNum { get; set; }
    }
}

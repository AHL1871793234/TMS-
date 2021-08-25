using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Model.Entity.Purchase
{
    /// <summary>
    /// 物资采购
    /// </summary>
    public partial class GoodsAndMaterials
    {
        /// <summary>
        /// 物资采购ID
        /// </summary>
        public int GoodsAndMaterialsID { get; set; }
        /// <summary>
        /// 货物名称
        /// </summary>
        public string GoodsAndMaterialsName { get; set; }
        /// <summary>
        /// 类别外键
        /// </summary>
        public int TypeID { get; set; }
        /// <summary>
        /// 材质外键
        /// </summary>
        public int TextureID { get; set; }
        /// <summary>
        /// 规格
        /// </summary>
        public string Specification { get; set; }
        /// <summary>
        /// 产地
        /// </summary>
        public string PlaceOfOrigin { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public int GoodsNumber { get; set; }
        /// <summary>
        /// 用途描述
        /// </summary>
        public string GoodsContent { get; set; }
        /// <summary>
        /// 申请人
        /// </summary>
        public string Proposer { get; set; }
        /// <summary>
        /// 期望交付日期
        /// </summary>
        public DateTime WashPayTime { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 审核状态
        /// </summary>
        public int CommonContractStatus { get; set; }
        /// <summary>
        /// 审核人
        /// </summary>
        public string CommonContractName { get; set; }
        /// <summary>
        /// 物资状态
        /// </summary>
        public int GoodsStatus { get; set; }           
    }
}



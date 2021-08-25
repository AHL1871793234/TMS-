using System;
using System.Collections.Generic;

#nullable disable

namespace TMS.Model.Entity.Approve
{
    /// <summary>
    /// 物资采购审批
    /// </summary>
    public partial class GoodsAndMaterialsExamine
    {
        /// <summary>
        /// 物资采购审批ID
        /// </summary>
        public int GoodsAndMaterialsExamineId { get; set; }
        /// <summary>
        /// 物资采购外键ID
        /// </summary>
        public int? GoodsAndMaterialsId { get; set; }
        /// <summary>
        /// 物资类别外键ID
        /// </summary>
        public int? TypeId { get; set; }
        /// <summary>
        /// 物资材质外键ID
        /// </summary>
        public int? TextureId { get; set; }
        /// <summary>
        /// 审批表外键ID
        /// </summary>
        public int? ExamineId { get; set; }
        /// <summary>
        /// 物资合同审批状态
        /// </summary>
        public int? GoodsAndMaterialsExamineStatus { get; set; }
    }
}

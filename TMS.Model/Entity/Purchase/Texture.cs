using System;
using System.Collections.Generic;

#nullable disable

namespace TMS.Model.Entity.Purchase
{
    /// <summary>
    /// 物资材质表
    /// </summary>
    public partial class Texture
    {
        /// <summary>
        /// 材质ID
        /// </summary>
        public int TextureId { get; set; }
        /// <summary>
        /// 材质名称
        /// </summary>
        public string TextureName { get; set; }
    }
}

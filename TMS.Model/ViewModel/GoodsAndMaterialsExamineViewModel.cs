using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Model.ViewModel
{
    /// <summary>
    /// 物资采购审批
    /// </summary>
    public class GoodsAndMaterialsExamineViewModel
    {
        public string GoodsAndMaterialsName { get; set; }
        public string GoodsAndMaterialsTypeName { get; set; }
        public string TextureName { get; set; }
        public string Specification { get; set; }
        public string PlaceOfOrigin { get; set; }
        public int GoodsNumber { get; set; }
        public string GoodsContent { get; set; }
        public string Proposer { get; set; }
        public DateTime WashPayTime { get; set; }
        public string Remark { get; set; }
        public DateTime CreateTime { get; set; }
        public int ExamineStatus { get; set; }
        public string ExamineName { get; set; }
    }
}

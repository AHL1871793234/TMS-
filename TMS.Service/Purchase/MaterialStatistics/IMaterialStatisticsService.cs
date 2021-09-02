using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Model.ViewModel;

namespace TMS.Service.Purchase.MaterialStatistics
{
    public interface IMaterialStatisticsService
    {
        /// <summary>
        /// 物资统计
        /// </summary>
        /// <param name="GoodsAndMaterialsName"></param>
        /// <param name="GoodsAndMaterialsTypeName"></param>
        /// <param name="TextureName"></param>
        /// <param name="PlaceOfOrigin"></param>
        /// <returns></returns>
        List<MaterialStatisticsViewModel> GetMaterialStatistics(string GoodsAndMaterialsName, string GoodsAndMaterialsTypeName, string TextureName, string PlaceOfOrigin);
    }
}

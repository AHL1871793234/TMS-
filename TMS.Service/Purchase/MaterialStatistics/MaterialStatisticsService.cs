using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.IRepository;
using TMS.Model.ViewModel;

namespace TMS.Service.Purchase.MaterialStatistics
{
    public class MaterialStatisticsService: IMaterialStatisticsService
    {
        public readonly IMaterialStatisticsRepository materialStatisticsRepository;

        public MaterialStatisticsService(IMaterialStatisticsRepository _materialStatisticsRepository)
        {
            materialStatisticsRepository = _materialStatisticsRepository;
        }
        /// <summary>
        /// 物资统计
        /// </summary>
        /// <param name="GoodsAndMaterialsName"></param>
        /// <param name="GoodsAndMaterialsTypeName"></param>
        /// <param name="TextureName"></param>
        /// <param name="PlaceOfOrigin"></param>
        /// <returns></returns>
        public List<MaterialStatisticsViewModel> GetMaterialStatistics(string GoodsAndMaterialsName, string GoodsAndMaterialsTypeName, string TextureName, string PlaceOfOrigin)
        {
            return materialStatisticsRepository.GetMaterialStatistics(GoodsAndMaterialsName, GoodsAndMaterialsTypeName, TextureName, PlaceOfOrigin);
        }
    }
}

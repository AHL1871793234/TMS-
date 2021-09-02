using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Common.DB;
using TMS.IRepository;
using TMS.Model.ViewModel;

namespace TMS.Repository
{
    /// <summary>
    /// 物资统计
    /// </summary>
    public class MaterialStatisticsRepository: IMaterialStatisticsRepository
    {
        //调用DapperClientHelper 数据库连接
        private readonly DapperClientHelper _SqlDB;

        //对的每个调用 CreateClient(String) 都保证返回一个新的 HttpClient 实例。 调用方可以无限期缓存返回的 HttpClient 实例，也可以在 块中使用它来释放它。
        //默认IHttpClientFactory 实现可能会缓存基础 HttpMessageHandler 实例以提高性能。
        //调用方还可以根据需要自由地改变返回的 HttpClient 实例的公共属性。
        //小型工厂模式
        public MaterialStatisticsRepository(IDapperFactory dapperFactory)
        {
            _SqlDB = dapperFactory.CreateClient("SqlDb");
        }

        /// <summary>
        /// 物资统计显示+查询
        /// </summary>
        /// <param name="GoodsAndMaterialsName"></param>
        /// <param name="GoodsAndMaterialsTypeName"></param>
        /// <param name="TextureName"></param>
        /// <param name="PlaceOfOrigin"></param>
        /// <returns></returns>
        public List<MaterialStatisticsViewModel> GetMaterialStatistics(string GoodsAndMaterialsName, string GoodsAndMaterialsTypeName, string TextureName, string PlaceOfOrigin)
        {
            string sql = "select a.GoodsAndMaterialsName,b.GoodsAndMaterialsTypeName,c.TextureName,a.Specification,a.PlaceOfOrigin,a.GoodsNumber,d.ProposerNum from GoodsAndMaterials a join GoodsType b on a.GoodsAndMaterialsID = b.GoodsAndMaterialsTypeID join Texture c on a.GoodsAndMaterialsID = c.TextureID join AidRecipients d on a.GoodsAndMaterialsID = d.AidRecipientsID";
            List<MaterialStatisticsViewModel> data = _SqlDB.Query<MaterialStatisticsViewModel>(sql);
            //查询
            if (!string.IsNullOrEmpty(GoodsAndMaterialsName))
            {
                data = data.Where(m => m.GoodsAndMaterialsName.Contains(GoodsAndMaterialsName)).ToList();
            }
            if (!string.IsNullOrEmpty(GoodsAndMaterialsTypeName))
            {
                data = data.Where(m => m.GoodsAndMaterialsTypeName.Contains(GoodsAndMaterialsTypeName)).ToList();
            }
            if (!string.IsNullOrEmpty(TextureName))
            {
                data = data.Where(m => m.TextureName.Contains(TextureName)).ToList();
            }
            if (!string.IsNullOrEmpty(PlaceOfOrigin))
            {
                data = data.Where(m => m.PlaceOfOrigin.Contains(PlaceOfOrigin)).ToList();
            }
            return data;
        }


    }
}

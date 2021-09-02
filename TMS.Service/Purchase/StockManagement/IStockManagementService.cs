using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Model.Entity.Purchase;

namespace TMS.Service.Purchase.StockManagement
{
    public interface IStockManagementService
    {
        /// <summary>
        /// 物资管理—物资入库显示
        /// </summary>
        /// <param name="cargoName"></param>
        /// <param name="productionPlace"></param>
        /// <param name="proposerName"></param>
        /// <returns></returns>
        List<StorageAdministration> GetStorageAdministrations(string storageName, int TextureId, string placeOfOrigin, string payType, string proposer);

        /// <summary>
        /// 物资管理—添加物资信息
        /// </summary>
        /// <param name="goodsAndMaterials"></param>
        /// <returns></returns>
        //bool AddGoodsAndMaterials(StorageAdministration goodsAndMaterials);

        /// <summary>
        /// 物资管理—删除采购信息（假删）接口
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool DelStorageAdministrations(string id);

        /// <summary>
        /// 物资管理—查看详情(反填)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        StorageAdministration EditStorageAdministration(int id);

        /// <summary>
        /// 物资管理—修改采购信息
        /// </summary>
        /// <param name="goodsAndMaterials"></param>
        /// <returns></returns>
        //bool UpdGoodsAndMaterials(StorageAdministration goodsAndMaterials);
    }
}

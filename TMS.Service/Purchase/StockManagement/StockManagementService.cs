using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.IRepository;
using TMS.Model.Entity.Purchase;
using TMS.Service.Purchase.StockManagement;

namespace TMS.Service
{
    public class StockManagementService: IStockManagementService
    {
        public readonly IStockManagementRepository stockManagementRepository;

        public StockManagementService(IStockManagementRepository _stockManagementRepository)
        {
            stockManagementRepository = _stockManagementRepository;
        }
        /// <summary>
        /// 物资管理—物资入库显示接口
        /// </summary>
        /// <param name="storageName"></param>
        /// <param name="TextureId"></param>
        /// <param name="placeOfOrigin"></param>
        /// <param name="payType"></param>
        /// <param name="proposer"></param>
        /// <returns></returns>
        public List<StorageAdministration> GetStorageAdministrations(string storageName, int TextureId, string placeOfOrigin, string payType, string proposer)
        {
            return stockManagementRepository.GetStorageAdministrations(storageName, TextureId, placeOfOrigin, payType, proposer);
        }

        /// <summary>
        /// 物资管理—添加入库信息
        /// </summary>
        /// <param name="storageAdministration"></param>
        /// <returns></returns>
        //public bool AddStorageAdministration(StorageAdministration storageAdministration)
        //{
        //    return stockManagementRepository.AddStorageAdministration(storageAdministration);
        //}

        /// <summary>
        /// 物资管理—删除入库信息（假删）
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DelStorageAdministrations(string id)
        {
            return stockManagementRepository.DelStorageAdministrations(id);
        }

        /// <summary>
        /// 物资管理—查看入库详情(反填)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public StorageAdministration EditStorageAdministration(int id)
        {
            return stockManagementRepository.EditStorageAdministration(id);
        }

        /// <summary>
        /// 物资管理—修改采购信息
        /// </summary>
        /// <param name="storageAdministratio"></param>
        /// <returns></returns>
        //public bool UpdGoodsAndMaterials(StorageAdministration storageAdministratio)
        //{
        //    return stockManagementRepository.UpdGoodsAndMaterials(storageAdministratio);
        //}
    }
}

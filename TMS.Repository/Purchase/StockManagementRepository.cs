using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Common.DB;
using TMS.IRepository;
using TMS.Model.Entity.Purchase;

namespace TMS.Repository
{
    /// <summary>
    /// 物资管理—入库管理
    /// </summary>
    public class StockManagementRepository:IStockManagementRepository
    {
        //调用DapperClientHelper 数据库连接
        private readonly DapperClientHelper _SqlDB;

        //对的每个调用 CreateClient(String) 都保证返回一个新的 HttpClient 实例。 调用方可以无限期缓存返回的 HttpClient 实例，也可以在 块中使用它来释放它。
        //默认IHttpClientFactory 实现可能会缓存基础 HttpMessageHandler 实例以提高性能。
        //调用方还可以根据需要自由地改变返回的 HttpClient 实例的公共属性。
        //小型工厂模式
        public StockManagementRepository(IDapperFactory dapperFactory)
        {
            _SqlDB = dapperFactory.CreateClient("SqlDb");
        }

        /// <summary>
        /// 物资管理—物资入库管理显示
        /// </summary>
        /// <param name="storageName">货物名称</param>
        /// <param name="TextureId">材质</param>
        /// <param name="placeOfOrigin">产地</param>
        /// <param name="payType">支付方式</param>
        /// <param name="proposer">登记人</param>
        /// <returns></returns>
        public List<StorageAdministration> GetStorageAdministrations(string storageName,int TextureId,string placeOfOrigin,string payType,string proposer)
        {
            string sql = "select * from StorageAdministration";
            List<StorageAdministration> data = _SqlDB.Query<StorageAdministration>(sql);
            //查询
            if (!string.IsNullOrEmpty(storageName))
            {
                data = data.Where(m => m.StorageName.Contains(storageName)).ToList();
            }
            if (!string.IsNullOrEmpty(placeOfOrigin))
            {
                data = data.Where(m => m.PlaceOfOrigin.Contains(placeOfOrigin)).ToList();
            }
            if (!string.IsNullOrEmpty(payType))
            {
                data = data.Where(m => m.PayType.Contains(payType)).ToList();
            }
            if (!string.IsNullOrEmpty(proposer))
            {
                data = data.Where(m => m.Proposer.Contains(proposer)).ToList();
            }
            return data;
        }

        /// <summary>
        /// 物资管理—添加入库信息
        /// </summary>
        /// <param name="storageAdministration"></param>
        /// <returns></returns>
        //public bool AddStorageAdministration(StorageAdministration storageAdministration)
        //{
        //    string sql = "insert  into StorageAdministration values('轮胎',1,1,'1200R20','中国-上海',10,900,'支付宝支付',9000,'李小红','-','2020-10-07 13:00',1)";
        //    int code = _SqlDB.Execute(sql, new
        //    {
        //        @StorageName = storageAdministration.StorageName,
        //        @TypeID= storageAdministration.TypeID,
        //        @PayType = storageAdministration.PayType,
        //        @PurchasePrice = storageAdministration.PurchasePrice,
        //        @Proposer = storageAdministration.Proposer,
        //        @Remark = storageAdministration.Remark,
        //        @CreateTime = storageAdministration.CreateTime,
        //        @GoodsStatus = storageAdministration.GoodsStatus
        //    });
        //    return code == 0 ? true : false;
        //}

        /// <summary>
        /// 物资管理—删除入库信息（假删）
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DelStorageAdministrations(string id)
        {
            string sql = "update StorageAdministration set GoodsStatus = 0 where StorageID in (@StorageID)";
            int code = _SqlDB.Execute(sql, new { @StorageID = id });
            return code == 0 ? true : false;
        }

        /// <summary>
        /// 物资管理—查看入库信息详情(反填)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public StorageAdministration EditStorageAdministration(int id)
        {
            string sql = "select * from StorageAdministration where StorageID=@StorageID";
            return _SqlDB.QueryFirst<StorageAdministration>(sql, new { @StorageID = id });
        }

        /// <summary>
        /// 物资管理—修改采购入库信息
        /// </summary>
        /// <param name="goodsAndMaterials"></param>
        /// <returns></returns>
        //public bool UpdGoodsAndMaterials(GoodsAndMaterials goodsAndMaterials)
        //{
        //    string sql = "update GoodsAndMaterials set GoodsAndMaterialsName=@GoodsAndMaterialsName,TypeID=@TypeID,TextureID=@TextureID,Specification=@Specification,PlaceOfOrigin=@PlaceOfOrigin,GoodsNumber=@GoodsNumber,GoodsContent=@GoodsContent,Proposer=@Proposer,WashPayTime=@WashPayTime,Remark=@Remark,CreateTime=@CreateTime,CommonContractStatus=@CommonContractStatus,CommonContractName=@CommonContractName,GoodsStatus=@GoodsStatus where GoodsAndMaterialsID=@GoodsAndMaterialsID";
        //    int code = _SqlDB.Execute(sql, new
        //    {
        //        @GoodsAndMaterialsID = goodsAndMaterials.GoodsAndMaterialsID,
        //        @GoodsAndMaterialsName = goodsAndMaterials.GoodsAndMaterialsName,
        //        @TypeID = goodsAndMaterials.TypeID,
        //        @TextureID = goodsAndMaterials.TextureID,
        //        @Specification = goodsAndMaterials.Specification,
        //        @PlaceOfOrigin = goodsAndMaterials.PlaceOfOrigin,
        //        @GoodsNumber = goodsAndMaterials.GoodsNumber,
        //        @GoodsContent = goodsAndMaterials.GoodsContent,
        //        @Proposer = goodsAndMaterials.Proposer,
        //        @WashPayTime = goodsAndMaterials.WashPayTime,
        //        @Remark = goodsAndMaterials.Remark,
        //        @CreateTime = goodsAndMaterials.CreateTime,
        //        @CommonContractStatus = goodsAndMaterials.CommonContractStatus,
        //        @CommonContractName = goodsAndMaterials.CommonContractName,
        //        @GoodsStatus = goodsAndMaterials.GoodsStatus
        //    });
        //    return code == 0 ? true : false;
        //}

    }
}

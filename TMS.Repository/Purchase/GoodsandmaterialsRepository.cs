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
    public class GoodsandmaterialsRepository:IGoodsandmaterialsRepository
    {
        //调用DapperClientHelper 数据库连接
        private readonly DapperClientHelper _SqlDB;

        //对的每个调用 CreateClient(String) 都保证返回一个新的 HttpClient 实例。 调用方可以无限期缓存返回的 HttpClient 实例，也可以在 块中使用它来释放它。
        //默认IHttpClientFactory 实现可能会缓存基础 HttpMessageHandler 实例以提高性能。
        //调用方还可以根据需要自由地改变返回的 HttpClient 实例的公共属性。
        //小型工厂模式
        public GoodsandmaterialsRepository(IDapperFactory dapperFactory)
        {
            _SqlDB = dapperFactory.CreateClient("SqlDb");
        }

        /// <summary>
        /// 物资管理—物资采购显示
        /// </summary>
        /// <param name="cargoName">货物名称</param>
        /// <param name="productionPlace">产地</param>
        /// <param name="proposerName">申请人</param>
        /// <returns></returns>
        public List<GoodsAndMaterials> GetGoodsAndMaterials(string cargoName,string productionPlace,string proposerName)
        {
            string sql = "select * from GoodsAndMaterials";
            List<GoodsAndMaterials> data = _SqlDB.Query<GoodsAndMaterials>(sql);
            //查询
            if (!string.IsNullOrEmpty(cargoName))
            {
                data = data.Where(m => m.GoodsAndMaterialsName.Contains(cargoName)).ToList();
            }
            if (!string.IsNullOrEmpty(productionPlace))
            {
                data = data.Where(m => m.PlaceOfOrigin.Contains(productionPlace)).ToList();
            }
            if (!string.IsNullOrEmpty(proposerName))
            {
                data = data.Where(m => m.Proposer.Contains(proposerName)).ToList();
            }
            return data;
        }

        /// <summary>
        /// 物资管理—添加采购信息
        /// </summary>
        /// <param name="goodsAndMaterials"></param>
        /// <returns></returns>
        public bool AddGoodsAndMaterials(GoodsAndMaterials goodsAndMaterials)
        {
            string sql = "insert into GoodsAndMaterials values(@GoodsAndMaterialsName,@TypeID,@TextureID,@Specification,@PlaceOfOrigin,@GoodsNumber,@GoodsContent,@Proposer,@WashPayTime,@Remark,@CreateTime,@CommonContractStatus,@CommonContractName,@GoodsStatus)";
            int code = _SqlDB.Execute(sql, new
            {
                @GoodsAndMaterialsName= goodsAndMaterials.GoodsAndMaterialsName,
                @TypeID = goodsAndMaterials.TypeID,
                @TextureID = goodsAndMaterials.TextureID,
                @Specification = goodsAndMaterials.Specification,
                @PlaceOfOrigin = goodsAndMaterials.PlaceOfOrigin,
                @GoodsNumber = goodsAndMaterials.GoodsNumber,
                @GoodsContent = goodsAndMaterials.GoodsContent,
                @Proposer = goodsAndMaterials.Proposer,
                @WashPayTime = goodsAndMaterials.WashPayTime,
                @Remark = goodsAndMaterials.Remark,
                @CreateTime = goodsAndMaterials.CreateTime,
                @CommonContractStatus = goodsAndMaterials.CommonContractStatus,
                @CommonContractName = goodsAndMaterials.CommonContractName,
                @GoodsStatus = goodsAndMaterials.GoodsStatus
            });
            return code == 0 ? true : false;
        }

        /// <summary>
        /// 物资管理—删除采购信息（假删）
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DelGoodsAndMaterials(string id)
        {
            string sql = "update GoodsAndMaterials set GoodsStatus=0 where GoodsAndMaterialsID in (@GoodsAndMaterialsID)";
            int code = _SqlDB.Execute(sql, new { @GoodsAndMaterialsID = id });
            return code == 0 ? true : false;
        }

        /// <summary>
        /// 物资管理—查看详情(反填)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public GoodsAndMaterials EditGoodsAndMaterials(int id)
        {
            string sql = "select * from GoodsAndMaterials where GoodsAndMaterialsID=@GoodsAndMaterialsID";
            return _SqlDB.QueryFirst<GoodsAndMaterials>(sql,new { @GoodsAndMaterialsID =id});
        }

        /// <summary>
        /// 物资管理—修改采购信息
        /// </summary>
        /// <param name="goodsAndMaterials"></param>
        /// <returns></returns>
        public bool UpdGoodsAndMaterials(GoodsAndMaterials goodsAndMaterials)
        {
            string sql = "update GoodsAndMaterials set GoodsAndMaterialsName=@GoodsAndMaterialsName,TypeID=@TypeID,TextureID=@TextureID,Specification=@Specification,PlaceOfOrigin=@PlaceOfOrigin,GoodsNumber=@GoodsNumber,GoodsContent=@GoodsContent,Proposer=@Proposer,WashPayTime=@WashPayTime,Remark=@Remark,CreateTime=@CreateTime,CommonContractStatus=@CommonContractStatus,CommonContractName=@CommonContractName,GoodsStatus=@GoodsStatus where GoodsAndMaterialsID=@GoodsAndMaterialsID";
            int code = _SqlDB.Execute(sql, new
            {
                @GoodsAndMaterialsID= goodsAndMaterials.GoodsAndMaterialsID,
                @GoodsAndMaterialsName = goodsAndMaterials.GoodsAndMaterialsName,
                @TypeID = goodsAndMaterials.TypeID,
                @TextureID = goodsAndMaterials.TextureID,
                @Specification = goodsAndMaterials.Specification,
                @PlaceOfOrigin = goodsAndMaterials.PlaceOfOrigin,
                @GoodsNumber = goodsAndMaterials.GoodsNumber,
                @GoodsContent = goodsAndMaterials.GoodsContent,
                @Proposer = goodsAndMaterials.Proposer,
                @WashPayTime = goodsAndMaterials.WashPayTime,
                @Remark = goodsAndMaterials.Remark,
                @CreateTime = goodsAndMaterials.CreateTime,
                @CommonContractStatus = goodsAndMaterials.CommonContractStatus,
                @CommonContractName = goodsAndMaterials.CommonContractName,
                @GoodsStatus = goodsAndMaterials.GoodsStatus
            }) ;
            return code == 0 ? true : false;
        }

        /// <summary>
        /// 物资管理—提交审批
        /// </summary>
        /// <param name="commonContractStatus"></param>
        /// <returns></returns>
        public bool UpdContractStatus(int commonContractStatus)
        {
            string sql = "update GoodsAndMaterials set CommonContractStatus=@CommonContractStatus where CommonContractStatus in(@CommonContractStatus)";
            int code = _SqlDB.Execute(sql, new { @CommonContractStatus = commonContractStatus });
            return code == 0 ? true : false;
        }
    }
}

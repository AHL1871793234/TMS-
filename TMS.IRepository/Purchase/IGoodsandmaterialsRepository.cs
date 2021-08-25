using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Model.Entity.Purchase;

namespace TMS.IRepository
{
    public interface IGoodsandmaterialsRepository
    {
        /// <summary>
        /// 物资管理—物资采购显示接口
        /// </summary>
        /// <param name="cargoName"></param>
        /// <param name="productionPlace"></param>
        /// <param name="proposerName"></param>
        /// <returns></returns>
        List<GoodsAndMaterials> GetGoodsAndMaterials(string cargoName, string productionPlace, string proposerName);

        /// <summary>
        /// 物资管理—物资采购添加接口
        /// </summary>
        /// <param name="goodsAndMaterials"></param>
        /// <returns></returns>
        bool AddGoodsAndMaterials(GoodsAndMaterials goodsAndMaterials);

        /// <summary>
        /// 物资管理—删除采购信息（假删）接口
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool DelGoodsAndMaterials(string id);

        /// <summary>
        /// 物资管理—查看详情(反填)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        GoodsAndMaterials EditGoodsAndMaterials(int id);

        /// <summary>
        /// 物资管理—修改采购信息
        /// </summary>
        /// <param name="goodsAndMaterials"></param>
        /// <returns></returns>
        bool UpdGoodsAndMaterials(GoodsAndMaterials goodsAndMaterials);

        /// <summary>
        /// 物资管理—提交审批
        /// </summary>
        /// <param name="commonContractStatus"></param>
        /// <returns></returns>
        bool UpdContractStatus(int commonContractStatus);

    }
}

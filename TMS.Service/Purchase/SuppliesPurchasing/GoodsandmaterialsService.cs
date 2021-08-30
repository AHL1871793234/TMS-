using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.IRepository;
using TMS.Model.Entity.Purchase;

namespace TMS.Service
{
    public class GoodsandmaterialsService : IGoodsandmaterialsService
    {
        public readonly IGoodsandmaterialsRepository goodsandmaterials;

        public GoodsandmaterialsService(IGoodsandmaterialsRepository _goodsandmaterials)
        {
            goodsandmaterials = _goodsandmaterials;
        }
        /// <summary>
        /// 物资管理—物资采购显示
        /// </summary>
        /// <param name="cargoName"></param>
        /// <param name="productionPlace"></param>
        /// <param name="proposerName"></param>
        /// <returns></returns>
        public List<GoodsAndMaterials> GetGoodsAndMaterials(string cargoName, string productionPlace, string proposerName)
        {
            return goodsandmaterials.GetGoodsAndMaterials(cargoName, productionPlace, proposerName);
        }

        /// <summary>
        /// 物资管理—添加采购信息
        /// </summary>
        /// <param name="goodsAndMaterials"></param>
        /// <returns></returns>
        public bool AddGoodsAndMaterials(GoodsAndMaterials goodsAndMaterials)
        {
            return goodsandmaterials.AddGoodsAndMaterials(goodsAndMaterials);
        }

        /// <summary>
        /// 物资管理—删除采购信息（假删）
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DelGoodsAndMaterials(string id)
        {
            return goodsandmaterials.DelGoodsAndMaterials(id);
        }

        /// <summary>
        /// 物资管理—查看详情(反填)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public GoodsAndMaterials EditGoodsAndMaterials(int id)
        {
            return goodsandmaterials.EditGoodsAndMaterials(id);
        }

        /// <summary>
        /// 物资管理—修改采购信息
        /// </summary>
        /// <param name="goodsAndMaterials"></param>
        /// <returns></returns>
        public bool UpdGoodsAndMaterials(GoodsAndMaterials goodsAndMaterials)
        {
            return goodsandmaterials.UpdGoodsAndMaterials(goodsAndMaterials);
        }

        /// <summary>
        /// 物资管理—提交审批
        /// </summary>
        /// <param name="commonContractStatus"></param>
        /// <returns></returns>
        public bool UpdContractStatus(int commonContractStatus)
        {
            return goodsandmaterials.UpdContractStatus(commonContractStatus);
        }


    }
}

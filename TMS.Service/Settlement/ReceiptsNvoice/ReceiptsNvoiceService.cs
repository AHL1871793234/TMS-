using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.IRepository;
using TMS.Model.Entity.Settlement;

namespace TMS.Service
{
    public class ReceiptsNvoiceService: IReceiptsNvoiceService
    {
        private readonly IReceiptsNvoiceRepository receiptsNvoiceRepository;

        public ReceiptsNvoiceService(IReceiptsNvoiceRepository _receiptsNvoiceRepository)
        {
            receiptsNvoiceRepository = _receiptsNvoiceRepository;
        }

        /// <summary>
        /// 进项发票管理-显示+查询
        /// </summary>
        /// <param name="ChargeOwnerOfCargoUnit"></param>
        /// <param name="ReceiptsNvoiceType"></param>
        /// <param name="CheckType"></param>
        /// <param name="InvoiceTime"></param>
        /// <returns></returns>
        public async Task<List<ReceiptsNvoice>> GetReceiptsNvoice(string ChargeOwnerOfCargoUnit, string ReceiptsNvoiceType, string CheckType, DateTime? InvoiceTime)
        {
            return await receiptsNvoiceRepository.GetReceiptsNvoice(ChargeOwnerOfCargoUnit, CheckType, CheckType, InvoiceTime);
        }

        /// <summary>
        /// 进项发票管理-添加数据
        /// </summary>
        /// <param name="receiptsNvoice"></param>
        /// <returns></returns>
        public async Task<bool> AddReceiptsNvoice(ReceiptsNvoice receiptsNvoice)
        {
            return await receiptsNvoiceRepository.AddReceiptsNvoice(receiptsNvoice);
        }

        /// <summary>
        /// 进项发票管理-删除数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DelReceiptsNvoice(string id)
        {
            return await receiptsNvoiceRepository.DelReceiptsNvoice(id);
        }

        /// <summary>
        /// 进项发票管理-反填获取详情信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ReceiptsNvoice> EditReceiptsNvoice(int id)
        {
            return await receiptsNvoiceRepository.EditReceiptsNvoice(id);
        }

        /// <summary>
        /// 进项发票管理-修改数据
        /// </summary>
        /// <param name="receiptsNvoice"></param>
        /// <returns></returns>
        public async Task<bool> UpdReceiptsNvoice(ReceiptsNvoice receiptsNvoice)
        {
            return await receiptsNvoiceRepository.UpdReceiptsNvoice(receiptsNvoice);
        }
    }
}

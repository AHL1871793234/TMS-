using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.IRepository;
using TMS.Model.Entity.Settlement;

namespace TMS.Service
{
    public class OutputNvoiceService: IOutputNvoiceService
    {
        private readonly IOutputNvoiceRepository outputNvoices;

        public OutputNvoiceService(IOutputNvoiceRepository _outputNvoice)
        {
            outputNvoices = _outputNvoice;
        }

        /// <summary>
        /// 销项发票管理-显示+查询
        /// </summary>
        /// <param name="OutputNvoiceName"></param>
        /// <param name="ReceiptsNvoiceType"></param>
        /// <param name="InvoiceTime"></param>
        /// <returns></returns>
        public async Task<List<OutputNvoice>> GetOutputNvoice(string OutputNvoiceName, string ReceiptsNvoiceType, DateTime? InvoiceTime)
        {
            return await outputNvoices.GetOutputNvoice(OutputNvoiceName, ReceiptsNvoiceType, InvoiceTime);
        }

        /// <summary>
        /// 销项发票管理-添加数据
        /// </summary>
        /// <param name="outputNvoice"></param>
        /// <returns></returns>
        public async Task<bool> AddOutputNvoice(OutputNvoice outputNvoice)
        {
            return await outputNvoices.AddOutputNvoice(outputNvoice);
        }

        /// <summary>
        /// 销项发票管理-删除数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DelOutputNvoice(string id)
        {
            return await outputNvoices.DelOutputNvoice(id);
        }

        /// <summary>
        /// 销项发票管理-反填获取详情数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<OutputNvoice> EditOutputNvoice(int id)
        {
            return await outputNvoices.EditOutputNvoice(id);
        }

        /// <summary>
        /// 销项发票管理-修改数据
        /// </summary>
        /// <param name="outputNvoice"></param>
        /// <returns></returns>
        public async Task<bool> UpdOutputNvoice(OutputNvoice outputNvoice)
        {
            return await outputNvoices.UpdOutputNvoice(outputNvoice);
        }
    }
}

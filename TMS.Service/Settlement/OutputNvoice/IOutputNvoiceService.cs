using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Model.Entity.Settlement;

namespace TMS.Service
{
    public interface IOutputNvoiceService
    {
        /// <summary>
        /// 销项发票管理-显示+查询
        /// </summary>
        /// <param name="OutputNvoiceName"></param>
        /// <param name="ReceiptsNvoiceType"></param>
        /// <param name="InvoiceTime"></param>
        /// <returns></returns>
        Task<List<OutputNvoice>> GetOutputNvoice(string OutputNvoiceName, string ReceiptsNvoiceType, DateTime? InvoiceTime);

        /// <summary>
        /// 销项发票管理-添加数据
        /// </summary>
        /// <param name="outputNvoice"></param>
        /// <returns></returns>
        Task<bool> AddOutputNvoice(OutputNvoice outputNvoice);

        /// <summary>
        /// 销项发票管理-删除数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DelOutputNvoice(string id);

        /// <summary>
        /// 销项发票管理-反填获取详情数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<OutputNvoice> EditOutputNvoice(int id);

        /// <summary>
        /// 销项发票管理-修改数据
        /// </summary>
        /// <param name="outputNvoice"></param>
        /// <returns></returns>
        Task<bool> UpdOutputNvoice(OutputNvoice outputNvoice);
    }
}

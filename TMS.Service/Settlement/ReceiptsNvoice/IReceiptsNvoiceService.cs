using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Model.Entity.Settlement;

namespace TMS.Service
{
    public interface IReceiptsNvoiceService
    {
        /// <summary>
        /// 进项发票管理-显示+查询
        /// </summary>
        /// <param name="ChargeOwnerOfCargoUnit"></param>
        /// <param name="ReceiptsNvoiceType"></param>
        /// <param name="CheckType"></param>
        /// <param name="InvoiceTime"></param>
        /// <returns></returns>
        Task<List<ReceiptsNvoice>> GetReceiptsNvoice(string ChargeOwnerOfCargoUnit, string ReceiptsNvoiceType, string CheckType, DateTime? InvoiceTime);

        /// <summary>
        /// 进项发票管理-添加数据
        /// </summary>
        /// <param name="receiptsNvoice"></param>
        /// <returns></returns>
        Task<bool> AddReceiptsNvoice(ReceiptsNvoice receiptsNvoice);

        /// <summary>
        /// 进项发票管理-删除数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DelReceiptsNvoice(string id);

        /// <summary>
        /// 进项发票管理-反填获取详情数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ReceiptsNvoice> EditReceiptsNvoice(int id);

        /// <summary>
        /// 进项发票管理-修改数据
        /// </summary>
        /// <param name="receiptsNvoice"></param>
        /// <returns></returns>
        Task<bool> UpdReceiptsNvoice(ReceiptsNvoice receiptsNvoice);
    }
}

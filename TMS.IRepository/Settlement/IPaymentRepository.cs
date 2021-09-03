using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Model.Entity.Settlement;

namespace TMS.IRepository
{
    public interface IPaymentRepository
    {
        /// <summary>
        /// 销项发票管理-付款管理-显示+查询
        /// </summary>
        /// <param name="PaymentTitle"></param>
        /// <param name="PayTime"></param>
        /// <param name="ReceiptsNvoiceType"></param>
        /// <param name="CommonContractStatus"></param>
        /// <param name="CommonContractName"></param>
        /// <returns></returns>
        Task<List<Payment>> GetPayment(string PaymentTitle, DateTime? PayTime, string ReceiptsNvoiceType, int CommonContractStatus, string CommonContractName);

        /// <summary>
        /// 销项发票管理-付款管理-添加数据
        /// </summary>
        /// <param name="payment"></param>
        /// <returns></returns>
        Task<bool> AddPayment(Payment payment);

        /// <summary>
        /// 销项发票管理-付款管理-删除数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DelPayment(string id);

        /// <summary>
        /// 销项发票管理-付款管理-反填获取详情信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Payment> EditPayment(int id);

        /// <summary>
        /// 销项发票管理-付款管理-修改数据
        /// </summary>
        /// <param name="payment"></param>
        /// <returns></returns>
        Task<bool> UpdPayment(Payment payment);
    }
}

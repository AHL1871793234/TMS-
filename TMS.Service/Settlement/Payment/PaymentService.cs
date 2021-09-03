using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.IRepository;
using TMS.Model.Entity.Settlement;

namespace TMS.Service
{
    public class PaymentService: IPaymentService
    {
        private readonly IPaymentRepository payments;

        public PaymentService(IPaymentRepository _payment)
        {
            payments = _payment;
        }

        /// <summary>
        /// 销项发票管理-付款管理-显示+查询
        /// </summary>
        /// <param name="PaymentTitle"></param>
        /// <param name="PayTime"></param>
        /// <param name="ReceiptsNvoiceType"></param>
        /// <param name="CommonContractStatus"></param>
        /// <param name="CommonContractName"></param>
        /// <returns></returns>
        public async Task<List<Payment>> GetPayment(string PaymentTitle, DateTime? PayTime, string ReceiptsNvoiceType, int CommonContractStatus, string CommonContractName)
        {
            return await payments.GetPayment(PaymentTitle, PayTime, ReceiptsNvoiceType, CommonContractStatus, CommonContractName);
        }

        /// <summary>
        /// 销项发票管理-付款管理-添加数据
        /// </summary>
        /// <param name="payment"></param>
        /// <returns></returns>
        public async Task<bool> AddPayment(Payment payment)
        {
            return await payments.AddPayment(payment);
        }

        /// <summary>
        /// 销项发票管理-付款管理-删除数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DelPayment(string id)
        {
            return await payments.DelPayment(id);
        }

        /// <summary>
        /// 销项发票管理-付款管理-反填获取详情数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Payment> EditPayment(int id)
        {
            return await payments.EditPayment(id);
        }

        /// <summary>
        /// 销项发票管理-付款管理-修改数据
        /// </summary>
        /// <param name="payment"></param>
        /// <returns></returns>
        public async Task<bool> UpdPayment(Payment payment)
        {
            return await payments.UpdPayment(payment);
        }
    }
}

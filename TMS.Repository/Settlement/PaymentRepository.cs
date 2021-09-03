using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Common.DB;
using TMS.IRepository;
using TMS.Model.Entity.Settlement;

namespace TMS.Repository
{
    public class PaymentRepository: IPaymentRepository
    {
        //调用DapperClientHelper 数据库连接
        private readonly DapperClientHelper _SqlDB;

        //对的每个调用 CreateClient(String) 都保证返回一个新的 HttpClient 实例。 调用方可以无限期缓存返回的 HttpClient 实例，也可以在 块中使用它来释放它。
        //默认IHttpClientFactory 实现可能会缓存基础 HttpMessageHandler 实例以提高性能。
        //调用方还可以根据需要自由地改变返回的 HttpClient 实例的公共属性。
        //小型工厂模式
        public PaymentRepository(IDapperFactory dapperFactory)
        {
            _SqlDB = dapperFactory.CreateClient("SqlDb");
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
        public async Task<List<Payment>> GetPayment(string PaymentTitle,  DateTime? PayTime,string ReceiptsNvoiceType,int CommonContractStatus,string CommonContractName)
        {
            string sql = "select * from Payment";
            List<Payment> data = await _SqlDB.QueryAsync<Payment>(sql);
            //查询
            if (!string.IsNullOrEmpty(PaymentTitle))
            {
                data = data.Where(m => m.PaymentTitle.Contains(PaymentTitle)).ToList();
            }
            if (PayTime is not null)
            {
                data = data.Where(m => m.PayTime.Equals(PayTime)).ToList();
            }
            if (CommonContractStatus is not 0)
            {
                data = data.Where(m => m.CommonContractStatus.Equals(CommonContractStatus)).ToList();
            }
            if (!string.IsNullOrEmpty(CommonContractName))
            {
                data = data.Where(m => m.CommonContractName.Contains(CommonContractName)).ToList();
            }
            return data;
        }

        /// <summary>
        /// 销项发票管理-付款管理-添加数据
        /// </summary>
        /// <param name="payment"></param>
        /// <returns></returns>
        public async Task<bool> AddPayment(Payment payment)
        {
            string sql = "insert into Payment values(@PaymentTitle,@PaymentContent,@PayPrice,@PayType,@PayName,@OpeningBank,@BankCard,@Proposer,@PayTime,@Remark,@CreateTime,@CommonContractStatus,@CommonContractName,@PaymentStatus)";
            int code = await _SqlDB.ExecuteAsync(sql, new
            {
                @PaymentTitle = payment.PaymentTitle,
                @PaymentContent = payment.PaymentContent,
                @PayPrice = payment.PayPrice,
                @PayType = payment.PayType,
                @PayName = payment.PayName,
                @OpeningBank = payment.OpeningBank,
                @BankCard = payment.BankCard,
                @Proposer = payment.Proposer,
                @PayTime = payment.PayTime,
                @Remark = payment.Remark,
                @CreateTime = DateTime.Now,
                @CommonContractStatus = payment.CommonContractStatus,
                @CommonContractName = payment.CommonContractName,
                @PaymentStatus = payment.PaymentStatus
            });
            return code == 0 ? true : false;
        }

        /// <summary>
        /// 销项发票管理-付款管理-删除数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DelPayment(string id)
        {
            int code = -1;
            string[] str = id.Split(',');
            string sql = "delete from Payment where PaymentID in (@PaymentID)";
            foreach (var item in str)
            {
                code = await _SqlDB.ExecuteAsync(sql, new { @PaymentID = item });
            }
            return code == 0 ? true : false;
        }

        /// <summary>
        /// 销项发票管理-付款管理-反填获取详情信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Payment> EditPayment(int id)
        {
            string sql = "select * from Payment where PaymentID = @PaymentID";
            return await _SqlDB.QueryFirstAsync<Payment>(sql, new { @PaymentID = id });
        }

        /// <summary>
        /// 销项发票管理-付款管理-修改数据
        /// </summary>
        /// <param name="payment"></param>
        /// <returns></returns>
        public async Task<bool> UpdPayment(Payment payment)
        {
            string sql = "update Payment set PaymentTitle=@PaymentTitle,PaymentContent=@PaymentContent,PayPrice=@PayPrice,PayType=@PayType,PayName=@PayName,OpeningBank=@OpeningBank,BankCard=@BankCard,Proposer=@Proposer,PayTime=@PayTime,Remark=@Remark,CreateTime=@CreateTime,CommonContractStatus=@CommonContractStatus,CommonContractName=@CommonContractName,PaymentStatus=@PaymentStatus where PaymentID=@PaymentID";
            int code = await _SqlDB.ExecuteAsync(sql, new
            {
                @PaymentTitle = payment.PaymentTitle,
                @PaymentContent = payment.PaymentContent,
                @PayPrice = payment.PayPrice,
                @PayType = payment.PayType,
                @PayName = payment.PayName,
                @OpeningBank = payment.OpeningBank,
                @BankCard = payment.BankCard,
                @Proposer = payment.Proposer,
                @PayTime = payment.PayTime,
                @Remark = payment.Remark,
                @CreateTime = DateTime.Now,
                @CommonContractStatus = payment.CommonContractStatus,
                @CommonContractName = payment.CommonContractName,
                @PaymentStatus = payment.PaymentStatus
            });
            return code == 0 ? true : false;
        }
    }
}

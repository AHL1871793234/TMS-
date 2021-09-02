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
    /// <summary>
    /// 物资领用
    /// </summary>
    public class AidRecipientRepository: IAidRecipientRepository
    {
        //调用DapperClientHelper 数据库连接
        private readonly DapperClientHelper _SqlDB;

        //对的每个调用 CreateClient(String) 都保证返回一个新的 HttpClient 实例。 调用方可以无限期缓存返回的 HttpClient 实例，也可以在 块中使用它来释放它。
        //默认IHttpClientFactory 实现可能会缓存基础 HttpMessageHandler 实例以提高性能。
        //调用方还可以根据需要自由地改变返回的 HttpClient 实例的公共属性。
        //小型工厂模式
        public AidRecipientRepository(IDapperFactory dapperFactory)
        {
            _SqlDB = dapperFactory.CreateClient("SqlDb");
        }
        /// <summary>
        /// 物资领用显示
        /// </summary>
        /// <param name="Proposer"></param>
        /// <param name="ProposerTime"></param>
        /// <param name="CommonContractStatus"></param>
        /// <param name="CommonContractName"></param>
        /// <param name="AidRecipientsStatus"></param>
        /// <returns></returns>
        public List<AidRecipient> GetAidRecipient(string Proposer,DateTime? ProposerTime, int CommonContractStatus, string CommonContractName, int AidRecipientsStatus)
        {
            string sql = "select * from AidRecipients";
            List<AidRecipient> data = _SqlDB.Query<AidRecipient>(sql);
            //查询
            if (!string.IsNullOrEmpty(Proposer))
            {
                data = data.Where(m => m.Proposer.Contains(Proposer)).ToList();
            }
            if (ProposerTime is not null)
            {
                data = data.Where(m => m.ProposerTime.Equals(ProposerTime)).ToList();
            }
            if (CommonContractStatus is not 0)
            {
                data = data.Where(m => m.CommonContractStatus.Equals(CommonContractStatus)).ToList();
            }
            if (!string.IsNullOrEmpty(CommonContractName))
            {
                data = data.Where(m => m.CommonContractName.Contains(CommonContractName)).ToList();
            }
            if (AidRecipientsStatus is not 0)
            {
                data = data.Where(m => m.AidRecipientsStatus.Equals(AidRecipientsStatus)).ToList();
            }
            return data;
        }

        /// <summary>
        /// 物资领用删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DelAidRecipient(string id)
        {
            string sql = "update AidRecipients set AidRecipientsStatus = 0 where AidRecipientsID in (@AidRecipientsID)";
            int code = _SqlDB.Execute(sql, new { @AidRecipientsID = id });
            return code == 0 ? true : false;
        }

        /// <summary>
        /// 物资领用反填信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public AidRecipient EditAidRecipient(int id)
        {
            string sql = "select * from AidRecipients where AidRecipientsID=@AidRecipientsID";
            return _SqlDB.QueryFirst<AidRecipient>(sql, new { @AidRecipientsID = id });
        }

       
    }
}

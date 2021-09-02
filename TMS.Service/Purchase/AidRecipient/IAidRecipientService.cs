using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Model.Entity.Purchase;

namespace TMS.Service
{
    public interface IAidRecipientService
    {
        /// <summary>
        /// 物资领用显示
        /// </summary>
        /// <param name="Proposer"></param>
        /// <param name="ProposerTime"></param>
        /// <param name="CommonContractStatus"></param>
        /// <param name="CommonContractName"></param>
        /// <param name="AidRecipientsStatus"></param>
        /// <returns></returns>
        List<AidRecipient> GetAidRecipient(string Proposer, DateTime? ProposerTime, int CommonContractStatus, string CommonContractName, int AidRecipientsStatus);

        /// <summary>
        /// 物资领用删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool DelAidRecipient(string id);

        /// <summary>
        /// 物资领用反填详情信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        AidRecipient EditAidRecipient(int id);

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.IRepository;
using TMS.Model.Entity.Purchase;
using TMS.Service;

namespace TMS.Service
{
    public class AidRecipientService: IAidRecipientService
    {
        public readonly IAidRecipientRepository aidRecipientRepository;

        public AidRecipientService(IAidRecipientRepository _aidRecipientRepository)
        {
            aidRecipientRepository = _aidRecipientRepository;
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
        public List<AidRecipient> GetAidRecipient(string Proposer, DateTime? ProposerTime, int CommonContractStatus, string CommonContractName, int AidRecipientsStatus)
        {
            return aidRecipientRepository.GetAidRecipient(Proposer, ProposerTime, CommonContractStatus, CommonContractName, AidRecipientsStatus);
        }

        /// <summary>
        /// 物资领用删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DelAidRecipient(string id)
        {
            return aidRecipientRepository.DelAidRecipient(id);
        }

        /// <summary>
        /// 物资领用反填详情信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public AidRecipient EditAidRecipient(int id)
        {
            return aidRecipientRepository.EditAidRecipient(id);
        }
    }
}

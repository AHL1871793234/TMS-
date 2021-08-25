using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.IRepository;
using TMS.Model.ViewModel;
using TMS.IRepository.Personnel;
using TMS.Model.Entity;
using TMS.Repository.Personnel;

namespace TMS.Service.Personnel
{
    public class HiredToHandlerService : IHiredToHandlerService
    {
        public readonly IHiredToHandlerRepository _hiredToHandlerRepository;

        public HiredToHandlerService(IHiredToHandlerRepository hiredToHandlerRepository)
        {
            _hiredToHandlerRepository= hiredToHandlerRepository ;
        }

        /// <summary>
        /// 人事模块—入职办理—显示
        /// </summary>
        /// <param name="EmpName"></param>
        /// <param name="EmpDeparName"></param>
        /// <param name="PosterName"></param>
        /// <param name="EntryTime"></param>
        /// <param name="CreateTime"></param>
        /// <param name="ExamineStatus"></param>
        /// <returns></returns>
        public async Task<List<HiredToHandlerViewModel>> GetHiredToHandlerViewModels(string EmpName, string EmpDeparName, string PosterName, DateTime? EntryTime, DateTime? CreateTime, int ExamineStatus)
        {
            return await _hiredToHandlerRepository.GetHiredToHandlerViewModels(EmpName, EmpDeparName, PosterName, EntryTime, CreateTime, ExamineStatus);
        }
    }
}

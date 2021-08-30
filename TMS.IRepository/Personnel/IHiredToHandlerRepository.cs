using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Model.ViewModel;

namespace TMS.Repository.Personnel
{
    /// <summary>
    /// 入职办理
    /// </summary>
    public interface IHiredToHandlerRepository
    {
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
        Task<List<HiredToHandlerViewModel>> GetHiredToHandlerViewModels(string EmpName, string EmpDeparName, string PosterName, DateTime? EntryTime, DateTime? CreateTime, int ExamineStatus);
    }
}

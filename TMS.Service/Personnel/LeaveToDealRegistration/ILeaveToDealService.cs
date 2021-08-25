using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Model.Entity;
using TMS.Model.ViewModel;

namespace TMS.Service.Personnel
{
    /// <summary>
    /// 离职办理—显示
    /// </summary>
    public interface ILeaveToDealService
    {
        Task<List<LeaveToDealViewModel>> GetLeaveToDealViewModel(string EmpName, string EmpDeparName, string PosterName, DateTime? EntryTime, DateTime? LeaveTime, int ExamineStatus);
    }
}

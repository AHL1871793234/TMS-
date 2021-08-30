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
    /// 转正办理—显示
    /// </summary>
    public interface IPositiveToDealService
    {
        Task<List<PositiveToDealViewModel>> GetPositiveToDealViewModels(string EmpName, string EmpDeparName, string PosterName, DateTime? EntryTime, DateTime? ProposerTime, int ExamineStatus);
    }
}

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
    public class LeaveToDealService : ILeaveToDealService
    {
        public readonly ILeaveToDealRepository _leaveToDealRepository;

        public LeaveToDealService(ILeaveToDealRepository leaveToDealRepository)
        {
            _leaveToDealRepository = leaveToDealRepository;
        }

        /// <summary>
        /// 人事模块—离职办理—显示
        /// </summary>
        /// <param name="EmpName">员工姓名</param>
        /// <param name="EmpDeparName">部门名称</param>
        /// <param name="PosterName">职位名称</param>
        /// <param name="EntryTime">入职日期</param>
        /// <param name="LeaveTime">离职日期</param>
        /// <param name="ExamineStatus">审批状态</param>
        /// <returns></returns>
        /// <returns></returns>
        public async Task<List<LeaveToDealViewModel>> GetLeaveToDealViewModel(string EmpName, string EmpDeparName, string PosterName, DateTime? EntryTime, DateTime? LeaveTime, int ExamineStatus)
        {
            return await _leaveToDealRepository.GetLeaveToDealViewModel(EmpName, EmpDeparName, PosterName, EntryTime, LeaveTime, ExamineStatus);
        }
    }
}

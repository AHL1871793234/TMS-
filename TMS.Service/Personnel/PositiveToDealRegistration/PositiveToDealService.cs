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
    public class PositiveToDealService:IPositiveToDealService
    {
        public readonly IPositiveToDealRepository _positiveToDealRepository;

        public PositiveToDealService(IPositiveToDealRepository positiveToDealRepository)
        {
            _positiveToDealRepository = positiveToDealRepository;
        }

        /// <summary>
        /// 人事模块—离职办理—显示
        /// </summary>
        /// <param name="EmpName">员工姓名</param>
        /// <param name="EmpDeparName">部门名称</param>
        /// <param name="PosterName">职位名称</param>
        /// <param name="EntryTime">入职日期</param>
        /// <param name="ProposerTime">申请日期</param>
        /// <param name="ExamineStatus">审批状态</param>
        /// <returns></returns>
        /// <returns></returns>
        public async Task<List<PositiveToDealViewModel>> GetPositiveToDealViewModels(string EmpName, string EmpDeparName, string PosterName, DateTime? EntryTime, DateTime? ProposerTime, int ExamineStatus)
        {
            return await _positiveToDealRepository.GetPositiveToDealViewModels(EmpName, EmpDeparName, PosterName, EntryTime, ProposerTime, ExamineStatus);
        }
    }
}

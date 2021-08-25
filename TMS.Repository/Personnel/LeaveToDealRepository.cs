using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Common.DB;
using TMS.Model.ViewModel;

namespace TMS.Repository.Personnel
{
    /// <summary>
    /// 离职办理
    /// </summary>
    public class LeaveToDealRepository : ILeaveToDealRepository
    {
        //调用DapperClientHelper 数据库连接
        private readonly DapperClientHelper _SqlDB;

        //对的每个调用 CreateClient(String) 都保证返回一个新的 HttpClient 实例。 调用方可以无限期缓存返回的 HttpClient 实例，也可以在 块中使用它来释放它。
        //默认IHttpClientFactory 实现可能会缓存基础 HttpMessageHandler 实例以提高性能。
        //调用方还可以根据需要自由地改变返回的 HttpClient 实例的公共属性。
        //小型工厂模式
        public LeaveToDealRepository(IDapperFactory dapperFactory)
        {
            _SqlDB = dapperFactory.CreateClient("SqlDb");
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
        public async Task<List<LeaveToDealViewModel>> GetLeaveToDealViewModel(string EmpName, string EmpDeparName, string PosterName, DateTime? EntryTime, DateTime? LeaveTime, int ExamineStatus)
        {
            string sql = "select a.EmployeeName,b.DepartmentName,c.PositionName,a.EmployeeParentName,a.EmployeeEntryTime,a.EmployeeEndWorkTime,a.EmployeeLeaveSession,b.DepartmentCreateTime,d.ExamineStatus,d.ExamineName from EmployeeModel a join DepartmentModel b on a.EmployeeID = b.DepartmentID join PositionModel c on a.EmployeeID = c.PositionID join ExamineModel d on a.EmployeeID = d.ExamineID join UserModel e on a.EmployeeID = e.UserID";
            List<LeaveToDealViewModel> data = await _SqlDB.QueryAsync<LeaveToDealViewModel>(sql);
            //查询
            if (!string.IsNullOrEmpty(EmpName))
            {
                data = data.Where(m => m.EmployeeName.Contains(EmpName)).ToList();
            }
            if (!string.IsNullOrEmpty(EmpDeparName))
            {
                data = data.Where(m => m.DepartmentName.Contains(EmpDeparName)).ToList();
            }
            if (!string.IsNullOrEmpty(PosterName))
            {
                data = data.Where(m => m.PositionName.Contains(PosterName)).ToList();
            }
            if (EntryTime is not null)
            {
                data = data.Where(m => m.EmployeeEntryTime.Equals(EntryTime)).ToList();
            }
            if (LeaveTime is not null)
            {
                data = data.Where(m => m.EmployeeEndWorkTime.Equals(LeaveTime)).ToList();
            }
            if (ExamineStatus != 0)
            {
                data = data.Where(m => m.ExamineStatus.Equals(ExamineStatus)).ToList();
            }
            return data;
        }
    }
}

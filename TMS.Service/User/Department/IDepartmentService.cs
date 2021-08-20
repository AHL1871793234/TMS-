using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Model.ViewModel;

namespace TMS.Service.User
{
    public interface IDepartmentService
    {
        /// <summary>
        /// 部门信息显示
        /// </summary>
        /// <param name="depName">部门名程</param>
        /// <returns></returns>
        Task<List<DepartmentViewModel>> GetDepartmentsAsync(string depName);
    }
}

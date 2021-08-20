using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.IRepository.User;
using TMS.Model.ViewModel;

namespace TMS.Service.User
{
    public class DepartmentService:IDepartmentService
    {
        private readonly IDepartmentRepository _department;

        public DepartmentService(IDepartmentRepository department)
        {
            _department = department;
        }


        /// <summary>
        /// 部门信息显示
        /// </summary>
        /// <param name="depName">部门名程</param>
        /// <returns></returns>
        public async Task<List<DepartmentViewModel>> GetDepartmentsAsync(string depName)
        {
            return await _department.GetDepartmentsAsync(depName);
        }
    }
}

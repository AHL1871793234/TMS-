using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Common.DB;
using TMS.IRepository.User;
using TMS.Model.ViewModel;

namespace TMS.Repository.Setting
{
    public class DepartmentRepository: IDepartmentRepository
    {
        private readonly DapperClientHelper _SqlDB; //连接数据库

        public DepartmentRepository(IDapperFactory dapperFactory)
        {
            _SqlDB = dapperFactory.CreateClient("SqlDb");
        }

        /// <summary>
        /// 部门信息显示
        /// </summary>
        /// <param name="depName">部门名称</param>
        /// <returns></returns>
        public async Task<List<DepartmentViewModel>> GetDepartmentsAsync(string depName)
        {
            string sql = "select DepartmentID,DepartmentName,(select DepartmentName from DepartmentModel as a where a.DepartmentID=b.DepartmentParentID) as UpName,DepartmentCreateTime,DepartmentStatus from DepartmentModel as b";
            List<DepartmentViewModel> data = await _SqlDB.QueryAsync<DepartmentViewModel>(sql);
            foreach (var item in data)
            {
                if (item.UpName == null || item.UpName == "")
                {
                    item.UpName = "-";
                }
            }
            if (!string.IsNullOrEmpty(depName))
            {
                data = data.Where(x => x.DepartmentName.Contains(depName)).ToList();
            }
            return data;
        }
    }
}

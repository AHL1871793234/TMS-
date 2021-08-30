using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Model.ViewModel;
using TMS.Common.DB;
using TMS.IRepository.Personnel;
using MySql.Data.MySqlClient;
using TMS.Model.Entity;

namespace TMS.Repository.Personnel
{
    public class EmployeeregistrationRepository:IEmployeeregistrationRepository
    {
        //调用DapperClientHelper 数据库连接
        private readonly DapperClientHelper _SqlDB;

        //对的每个调用 CreateClient(String) 都保证返回一个新的 HttpClient 实例。 调用方可以无限期缓存返回的 HttpClient 实例，也可以在 块中使用它来释放它。
        //默认IHttpClientFactory 实现可能会缓存基础 HttpMessageHandler 实例以提高性能。
        //调用方还可以根据需要自由地改变返回的 HttpClient 实例的公共属性。
        //小型工厂模式
        public EmployeeregistrationRepository(IDapperFactory dapperFactory)
        {
            _SqlDB = dapperFactory.CreateClient("SqlDb");
        }
        /// <summary>
        /// 人事模块—员工登记—显示
        /// </summary>
        /// <param name="EmpName"></param>
        /// <param name="EmpDeparName"></param>
        /// <param name="PosterName"></param>
        /// <param name="EmpPhone"></param>
        /// <param name="EmpType"></param>
        /// <returns></returns>
        public List<EmployeeRegistration> GetEmployeeRegistrations(string EmpName, int EmpDeparName, int PosterName,string EmpPhone,int EmpType)
        {
            string sql = "select a.EmployeeId,a.EmployeeName,a.EmployeeSex,b.DepartmentName,c.PositionName,a.EmployeePhone,d.UserSchool,d.UseMajor,d.UserHomePlace,a.EmployeeEntryTime,a.EmployeeType,b.DepartmentStatus,a.CreateTime from EmployeeModel a join DepartmentModel b on a.EmployeeID = b.DepartmentID join PositionModel c on a.EmployeeID = c.PositionID join UserModel d on a.EmployeeID = d.UserID";
            List<EmployeeRegistration> data = _SqlDB.Query<EmployeeRegistration>(sql);
            //查询
            if (!string.IsNullOrEmpty(EmpName))
            {
                data = data.Where(m => m.EmployeeName.Contains(EmpName)).ToList();
            }
            if (EmpDeparName!=0)
            {
                data = data.Where(m => m.DepartmentName.Contains((char)EmpDeparName)).ToList();
            } 
            if (PosterName!=0)
            {
                data = data.Where(m => m.PositionName.Contains((char)PosterName)).ToList();
            }
            if (!string.IsNullOrEmpty(EmpPhone))
            {
                data = data.Where(m => m.EmployeePhone.Contains(EmpPhone)).ToList();
            }
            return data;
        }

        /// <summary>
        /// 人事模块—员工登记—添加
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        public bool AddEmployeeRegistrations(UserModel userModel)
        {
            string sql = "insert into UserModel values(@UserName,@UserPwd,@UserSex,@UserPhone,@UserEmail,@UserIdentityCard,@UserHomePlace,@UserBrithday,@UserSchool,@UseMajor,@UserEducation,@UserNation,@UserNativePlace,@UserPoliticsStatus,@UseMarriage,@UserStatus)";
            int code = _SqlDB.Execute(sql, new
            {
                @UserName = userModel.UserName,
                @UserPwd = userModel.UserPwd,
                @UserSex = userModel.UserSex,
                @UserPhone = userModel.UserPhone,
                @UserEmail = userModel.UserEmail,
                @UserIdentityCard = userModel.UserIdentityCard,
                @UserHomePlace = userModel.UserHomePlace,
                @UserBrithday=userModel.UserBrithday,
                @UserSchool = userModel.UserSchool,
                @UseMajor = userModel.UseMajor,
                @UserEducation = userModel.UserEducation,
                @UserNation = userModel.UserNation,
                @UserNativePlace = userModel.UserNativePlace,
                @UserPoliticsStatus = userModel.UserPoliticsStatus,
                @UseMarriage= userModel.UseMarriage,
                @UserStatus=userModel.UserStatus
            });
            return code == 0 ? true : false;
        }

        /// <summary>
        /// 人事模块—员工登记—删除（假删）
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DelEmployeeRegistrations(string id)
        {
            string sql = "";
            int code = _SqlDB.Execute(sql, new { @GoodsAndMaterialsID = id });
            return code == 0 ? true : false;
        }

        /// <summary>
        /// 人事模块—员工登记—反填
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public EmployeeRegistration EditEmployeeRegistrations(int id)
        {
            string sql = "";
            return _SqlDB.QueryFirst<EmployeeRegistration>(sql, new {   });
        }

        /// <summary>
        /// 人事模块—员工登记—修改
        /// </summary>
        /// <param name="employeeRegistration"></param>
        /// <returns></returns>
        public bool UpdEmployeeRegistrations(EmployeeRegistration employeeRegistration)
        {
            string sql = "";
            int code = _SqlDB.Execute(sql, new
            {
                
            });
            return code == 0 ? true : false;
        }
    }
}

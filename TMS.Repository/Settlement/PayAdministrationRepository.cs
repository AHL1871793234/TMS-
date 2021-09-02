using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Common.DB;
using TMS.IRepository;
using TMS.Model.Entity.Settlement;

namespace TMS.Repository
{
    public class PayAdministrationRepository: IPayAdministrationRepository
    {
        //调用DapperClientHelper 数据库连接
        private readonly DapperClientHelper _SqlDB;

        //对的每个调用 CreateClient(String) 都保证返回一个新的 HttpClient 实例。 调用方可以无限期缓存返回的 HttpClient 实例，也可以在 块中使用它来释放它。
        //默认IHttpClientFactory 实现可能会缓存基础 HttpMessageHandler 实例以提高性能。
        //调用方还可以根据需要自由地改变返回的 HttpClient 实例的公共属性。
        //小型工厂模式
        public PayAdministrationRepository(IDapperFactory dapperFactory)
        {
            _SqlDB = dapperFactory.CreateClient("SqlDb");
        }

        /// <summary>
        /// 应付费用管理—显示+查询
        /// </summary>
        /// <param name="ChargeOwnerOfCargoUnit"></param>
        /// <param name="PayType"></param>
        /// <param name="CheckType"></param>
        /// <param name="CircuitResponsibleName"></param>
        /// <param name="ProfessionalTime"></param>
        /// <returns></returns>
        public async Task<List<PayAdministration>> GetPayAdministration(string ChargeOwnerOfCargoUnit, string PayType, string CheckType, string CircuitResponsibleName, DateTime? ProfessionalTime)
        {
            string sql = "select * from PayAdministration";
            List<PayAdministration> data = await _SqlDB.QueryAsync<PayAdministration>(sql);
            //查询
            if (!string.IsNullOrEmpty(ChargeOwnerOfCargoUnit))
            {
                data = data.Where(m => m.ChargeOwnerOfCargoUnit.Contains(ChargeOwnerOfCargoUnit)).ToList();
            }
            if (!string.IsNullOrEmpty(PayType))
            {
                data = data.Where(m => m.PayType.Equals(PayType)).ToList();
            }
            if (!string.IsNullOrEmpty(CheckType))
            {
                data = data.Where(m => m.CheckType.Contains(CheckType)).ToList();
            }
            if (!string.IsNullOrEmpty(CircuitResponsibleName))
            {
                data = data.Where(m => m.CircuitResponsibleName.Contains(CircuitResponsibleName)).ToList();
            }
            if (ProfessionalTime is not null)
            {
                data = data.Where(m => m.ProfessionalTime.Equals(ProfessionalTime)).ToList();
            }
            return data;
        }

        /// <summary>
        /// 应付费用管理-添加数据
        /// </summary>
        /// <param name="payAdministration"></param>
        /// <returns></returns>
        public async Task<bool> AddPayAdministration(PayAdministration payAdministration)
        {
            string sql = "insert into Charge values(@ProfessionalNo,@ChargeOwnerOfCargoUnit,@PayType,@Tonnage,@Price,@ProfessionalTime,@CircuitResponsibleName,@CreateTime,@Remark,@CheckType,@CheckName,@PayAdministrationStatus)";
            int code = await _SqlDB.ExecuteAsync(sql, new
            {
                @ProfessionalNo = payAdministration.ProfessionalNo,
                @ChargeOwnerOfCargoUnit = payAdministration.ChargeOwnerOfCargoUnit,
                @PayType = payAdministration.PayType,
                @Tonnage = payAdministration.Tonnage,
                @Price = payAdministration.Price,
                @ProfessionalTime = payAdministration.ProfessionalTime,
                @CircuitResponsibleName = payAdministration.Remark,
                @CreateTime = DateTime.Now,
                @Remark = payAdministration.Remark,
                @CheckType = payAdministration.CheckType,
                @CheckName = payAdministration.CheckName,
                @PayAdministrationStatus = payAdministration.PayAdministrationStatus
            });
            return code == 0 ? true : false;
        }

        /// <summary>
        /// 应付费用管理-删除数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DelPayAdministration(string id)
        {
            int code = -1;
            string[] str = id.Split(',');
            string sql = "delete from PayAdministration where PayAdministrationID in (@PayAdministrationID)";
            foreach (var item in str)
            {
                code = await _SqlDB.ExecuteAsync(sql, new { @PayAdministrationID = item });
            }
            return code == 0 ? true : false;
        }

        /// <summary>
        /// 应付费用管理-获取数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<PayAdministration> EditPayAdministration(int id)
        {
            string sql = "select * from PayAdministration where PayAdministrationID = @PayAdministrationID";
            return await _SqlDB.QueryFirstAsync<PayAdministration>(sql, new { @PayAdministrationID = id });
        }

        /// <summary>
        /// 应付费用管理-修改数据
        /// </summary>
        /// <param name="payAdministration"></param>
        /// <returns></returns>
        public async Task<bool> UpdPayAdministration(PayAdministration payAdministration)
        {
            string sql = "update PayAdministration set ProfessionalNo=@ProfessionalNo,ChargeOwnerOfCargoUnit=@ChargeOwnerOfCargoUnit,PayType=@PayType,Tonnage=@Tonnage,Price=@Price,ProfessionalTime=@ProfessionalTime,CircuitResponsibleName=@CircuitResponsibleName,CreateTime=@CreateTime,Remark=@Remark,CheckType=@CheckType,CheckName=@CheckName,PayAdministrationStatus=@PayAdministrationStatus where PayAdministrationID=@PayAdministrationID";
            int code = await _SqlDB.ExecuteAsync(sql, new
            {
                @ProfessionalNo = payAdministration.ProfessionalNo,
                @ChargeOwnerOfCargoUnit = payAdministration.ChargeOwnerOfCargoUnit,
                @PayType = payAdministration.PayType,
                @Tonnage = payAdministration.Tonnage,
                @Price = payAdministration.Price,
                @ProfessionalTime = payAdministration.ProfessionalTime,
                @CircuitResponsibleName = payAdministration.Remark,
                @CreateTime = DateTime.Now,
                @Remark = payAdministration.Remark,
                @CheckType = payAdministration.CheckType,
                @CheckName = payAdministration.CheckName,
                @PayAdministrationStatus = payAdministration.PayAdministrationStatus
            });
            return code == 0 ? true : false;
        }
    }
}

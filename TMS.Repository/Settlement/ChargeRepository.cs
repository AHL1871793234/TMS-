using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Common.DB;
using TMS.IRepository;
using TMS.Model.Entity;
using TMS.Model.Entity.Settlement;

namespace TMS.Repository
{
    /// <summary>
    /// 结算管理—应收费用管理
    /// </summary>
    public class ChargeRepository: IChargeRepository
    {
        //调用DapperClientHelper 数据库连接
        private readonly DapperClientHelper _SqlDB;

        //对的每个调用 CreateClient(String) 都保证返回一个新的 HttpClient 实例。 调用方可以无限期缓存返回的 HttpClient 实例，也可以在 块中使用它来释放它。
        //默认IHttpClientFactory 实现可能会缓存基础 HttpMessageHandler 实例以提高性能。
        //调用方还可以根据需要自由地改变返回的 HttpClient 实例的公共属性。
        //小型工厂模式
        public ChargeRepository(IDapperFactory dapperFactory)
        {
            _SqlDB = dapperFactory.CreateClient("SqlDb");
        }

        /// <summary>
        /// 应收费用管理显示+查询
        /// </summary>
        /// <param name="ChargeOwnerOfCargoUnit"></param>
        /// <param name="PayType"></param>
        /// <param name="CheckType"></param>
        /// <param name="CircuitResponsibleName"></param>
        /// <param name="ProfessionalTime"></param>
        /// <returns></returns>
        public async Task<List<Charge>> GetCharges(string ChargeOwnerOfCargoUnit, string PayType, string CheckType, string CircuitResponsibleName, DateTime? ProfessionalTime)
        {
            string sql = "select * from Charge";
            List<Charge> data = await _SqlDB.QueryAsync<Charge>(sql);
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
        /// 应收费用管理添加数据
        /// </summary>
        /// <param name="charge">费用信息</param>
        /// <returns></returns>
        public async Task<bool> AddCharges(Charge charge)
        {
            string sql = "insert into Charge values(@ProfessionalNo,@ChargeOwnerOfCargoUnit,@PayType,@Tonnage,@Price,@ProfessionalTime,@CircuitResponsibleName,@CreateTime,@Remark,@CheckType,@CheckName,@ChargeStatus)";
            int code = await _SqlDB.ExecuteAsync(sql, new
            {
                @ProfessionalNo = charge.ProfessionalNo,
                @ChargeOwnerOfCargoUnit = charge.ChargeOwnerOfCargoUnit,
                @PayType = charge.PayType,
                @Tonnage = charge.Tonnage,
                @Price = charge.Price,
                @ProfessionalTime = charge.ProfessionalTime,
                @CircuitResponsibleName = charge.Remark,
                @CreateTime = DateTime.Now,
                @Remark= charge.Remark,
                @CheckType=charge.CheckType,
                @CheckName=charge.CheckName,
                @ChargeStatus=charge.ChargeStatus
            });
            return code == 0 ? true : false;
        }

        /// <summary>
        /// 应收费用管理—删除信息(支持批删)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DelCharges(string id)
        {
            int code = -1;
            string[] str = id.Split(',');
            string sql = "delete from Charge where ChargeID in (@ChargeID)";
            foreach (var item in str)
            {
                code = await _SqlDB.ExecuteAsync(sql, new { @ChargeID = item });
            }
            return code == 0 ? true : false;
        }

        /// <summary>
        /// 应用收费管理—反填收费管理信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Charge> EditCharge(int id)
        {
            string sql = "select * from Charge where ChargeID = @ChargeID";
            return await _SqlDB.QueryFirstAsync<Charge>(sql, new { @ChargeID = id });
        }

        /// <summary>
        /// 应用收费管理—修改收费管理信息
        /// </summary>
        /// <param name="charge"></param>
        /// <returns></returns>
        public async Task<bool> UpdCharge(Charge charge)
        {
            string sql = "update OwnerOfCargo set ProfessionalNo=@ProfessionalNo,ChargeOwnerOfCargoUnit=@ChargeOwnerOfCargoUnit,PayType=@PayType,Tonnage=@Tonnage,Price=@Price,ProfessionalTime=@ProfessionalTime,CircuitResponsibleName=@CircuitResponsibleName,CreateTime=@CreateTime,Remark=@Remark,CheckType=@CheckType,CheckName=@CheckName,ChargeStatus=@ChargeStatus where ChargeID=@ChargeID";
            int code = await _SqlDB.ExecuteAsync(sql, new
            {
                @ProfessionalNo = charge.ProfessionalNo,
                @ChargeOwnerOfCargoUnit = charge.ChargeOwnerOfCargoUnit,
                @PayType = charge.PayType,
                @Tonnage = charge.Tonnage,
                @Price = charge.Price,
                @ProfessionalTime = charge.ProfessionalTime,
                @CircuitResponsibleName = charge.Remark,
                @CreateTime = DateTime.Now,
                @Remark = charge.Remark,
                @CheckType = charge.CheckType,
                @CheckName = charge.CheckName,
                @ChargeStatus = charge.ChargeStatus
            });
            return code == 0 ? true : false;
        }
    }
}

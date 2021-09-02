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
    public class ReceiptsNvoiceRepository: IReceiptsNvoiceRepository
    {
        //调用DapperClientHelper 数据库连接
        private readonly DapperClientHelper _SqlDB;

        //对的每个调用 CreateClient(String) 都保证返回一个新的 HttpClient 实例。 调用方可以无限期缓存返回的 HttpClient 实例，也可以在 块中使用它来释放它。
        //默认IHttpClientFactory 实现可能会缓存基础 HttpMessageHandler 实例以提高性能。
        //调用方还可以根据需要自由地改变返回的 HttpClient 实例的公共属性。
        //小型工厂模式
        public ReceiptsNvoiceRepository(IDapperFactory dapperFactory)
        {
            _SqlDB = dapperFactory.CreateClient("SqlDb");
        }

        /// <summary>
        /// 进项发票管理-显示+查询
        /// </summary>
        /// <param name="ChargeOwnerOfCargoUnit"></param>
        /// <param name="ReceiptsNvoiceType"></param>
        /// <param name="CheckType"></param>
        /// <param name="InvoiceTime"></param>
        /// <returns></returns>
        public async Task<List<ReceiptsNvoice>> GetReceiptsNvoice(string ChargeOwnerOfCargoUnit, string ReceiptsNvoiceType, string CheckType, DateTime? InvoiceTime)
        {
            string sql = "select * from ReceiptsNvoice";
            List<ReceiptsNvoice> data = await _SqlDB.QueryAsync<ReceiptsNvoice>(sql);
            //查询
            if (!string.IsNullOrEmpty(ChargeOwnerOfCargoUnit))
            {
                data = data.Where(m => m.ChargeOwnerOfCargoUnit.Contains(ChargeOwnerOfCargoUnit)).ToList();
            }
            if (!string.IsNullOrEmpty(ReceiptsNvoiceType))
            {
                data = data.Where(m => m.ReceiptsNvoiceType.Contains(ReceiptsNvoiceType)).ToList();
            }
            if (InvoiceTime is not null)
            {
                data = data.Where(m => m.InvoiceTime.Equals(InvoiceTime)).ToList();
            }
            return data;
        }

        /// <summary>
        /// 进项发票管理-添加数据
        /// </summary>
        /// <param name="receiptsNvoice"></param>
        /// <returns></returns>
        /// 
        public async Task<bool> AddReceiptsNvoice(ReceiptsNvoice receiptsNvoice)
        {
            string sql = "insert into ReceiptsNvoice values(@ReceiptsNvoiceNo,@ChargeOwnerOfCargoUnit,@ReceiptsNvoiceType,@InvoicePrice,@TaxRate,@InvoiceTime,@Remark,@PreparedBy,@CreateTime,@ReceiptsNvoiceStatus)";
            int code = await _SqlDB.ExecuteAsync(sql, new
            {
                @ReceiptsNvoiceNo = receiptsNvoice.ReceiptsNvoiceNo,
                @ChargeOwnerOfCargoUnit = receiptsNvoice.ChargeOwnerOfCargoUnit,
                @ReceiptsNvoiceType = receiptsNvoice.ReceiptsNvoiceType,
                @InvoicePrice = receiptsNvoice.InvoicePrice,
                @TaxRate = receiptsNvoice.TaxRate,
                @InvoiceTime = receiptsNvoice.InvoiceTime,
                @Remark = receiptsNvoice.Remark,
                @PreparedBy = receiptsNvoice.PreparedBy,
                @CreateTime = DateTime.Now,
                @ReceiptsNvoiceStatus = receiptsNvoice.ReceiptsNvoiceStatus
            });
            return code == 0 ? true : false;
        }

        /// <summary>
        /// 进项发票管理-删除数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DelReceiptsNvoice(string id)
        {
            int code = -1;
            string[] str = id.Split(',');
            string sql = "delete from ReceiptsNvoice where ReceiptsNvoiceID in (@ReceiptsNvoiceID)";
            foreach (var item in str)
            {
                code = await _SqlDB.ExecuteAsync(sql, new { @ReceiptsNvoiceID = item });
            }
            return code == 0 ? true : false;
        }

        /// <summary>
        /// 进项发票管理-反填获取发票详细信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ReceiptsNvoice> EditReceiptsNvoice(int id)
        {
            string sql = "select * from ReceiptsNvoice where ReceiptsNvoiceID = @ReceiptsNvoiceID";
            return await _SqlDB.QueryFirstAsync<ReceiptsNvoice>(sql, new { @ReceiptsNvoiceID = id });
        }

        /// <summary>
        /// 进项发票管理-修改数据
        /// </summary>
        /// <param name="receiptsNvoice"></param>
        /// <returns></returns>
        public async Task<bool> UpdReceiptsNvoice(ReceiptsNvoice receiptsNvoice)
        {
            string sql = "update ReceiptsNvoice set ReceiptsNvoiceNo=@ReceiptsNvoiceNo,ChargeOwnerOfCargoUnit=@ChargeOwnerOfCargoUnit,ReceiptsNvoiceType=@ReceiptsNvoiceType,InvoicePrice=@InvoicePrice,TaxRate=@TaxRate,InvoiceTime=@InvoiceTime,Remark=@Remark,PreparedBy=@PreparedBy,CreateTime=@CreateTime,ReceiptsNvoiceStatus=@ReceiptsNvoiceStatus where ReceiptsNvoiceID=@ReceiptsNvoiceID";
            int code = await _SqlDB.ExecuteAsync(sql, new
            {
                @ReceiptsNvoiceNo = receiptsNvoice.ReceiptsNvoiceNo,
                @ChargeOwnerOfCargoUnit = receiptsNvoice.ChargeOwnerOfCargoUnit,
                @ReceiptsNvoiceType = receiptsNvoice.ReceiptsNvoiceType,
                @InvoicePrice = receiptsNvoice.InvoicePrice,
                @TaxRate = receiptsNvoice.TaxRate,
                @InvoiceTime = receiptsNvoice.InvoiceTime,
                @Remark = receiptsNvoice.Remark,
                @PreparedBy = receiptsNvoice.PreparedBy,
                @CreateTime = DateTime.Now,
                @ReceiptsNvoiceStatus = receiptsNvoice.ReceiptsNvoiceStatus
            });
            return code == 0 ? true : false;
        }
    }
}

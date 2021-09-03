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
    public class OutputNvoiceRepository: IOutputNvoiceRepository
    {
        //调用DapperClientHelper 数据库连接
        private readonly DapperClientHelper _SqlDB;

        //对的每个调用 CreateClient(String) 都保证返回一个新的 HttpClient 实例。 调用方可以无限期缓存返回的 HttpClient 实例，也可以在 块中使用它来释放它。
        //默认IHttpClientFactory 实现可能会缓存基础 HttpMessageHandler 实例以提高性能。
        //调用方还可以根据需要自由地改变返回的 HttpClient 实例的公共属性。
        //小型工厂模式
        public OutputNvoiceRepository(IDapperFactory dapperFactory)
        {
            _SqlDB = dapperFactory.CreateClient("SqlDb");
        }

        /// <summary>
        /// 销项发票管理-显示+查询
        /// </summary>
        /// <param name="OutputNvoiceName"></param>
        /// <param name="ReceiptsNvoiceType"></param>
        /// <param name="InvoiceTime"></param>
        /// <returns></returns>
        public async Task<List<OutputNvoice>> GetOutputNvoice(string OutputNvoiceName, string ReceiptsNvoiceType, DateTime? InvoiceTime)
        {
            string sql = "select * from OutputNvoice";
            List<OutputNvoice> data = await _SqlDB.QueryAsync<OutputNvoice>(sql);
            //查询
            if (!string.IsNullOrEmpty(OutputNvoiceName))
            {
                data = data.Where(m => m.OutputNvoiceName.Contains(OutputNvoiceName)).ToList();
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
        /// 销项发票管理-添加数据
        /// </summary>
        /// <param name="outputNvoice"></param>
        /// <returns></returns>
        public async Task<bool> AddOutputNvoice(OutputNvoice outputNvoice)
        {
            string sql = "insert into ReceiptsNvoice values(@OutputNvoiceNo,@OutputNvoiceName,@ReceiptsNvoiceType,@InvoicePrice,@TaxRate,@InvoiceTime,@Remark,@PreparedBy,@CreateTime,@ReceiptsNvoiceStatus)";
            int code = await _SqlDB.ExecuteAsync(sql, new
            {
                @OutputNvoiceNo = outputNvoice.OutputNvoiceNo,
                @OutputNvoiceName = outputNvoice.OutputNvoiceName,
                @ReceiptsNvoiceType = outputNvoice.ReceiptsNvoiceType,
                @InvoicePrice = outputNvoice.InvoicePrice,
                @TaxRate = outputNvoice.TaxRate,
                @InvoiceTime = outputNvoice.InvoiceTime,
                @Remark = outputNvoice.Remark,
                @PreparedBy = outputNvoice.PreparedBy,
                @CreateTime = DateTime.Now,
                @ReceiptsNvoiceStatus = outputNvoice.ReceiptsNvoiceStatus
            });
            return code == 0 ? true : false;
        }

        /// <summary>
        /// 销项发票管理-删除数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DelOutputNvoice(string id)
        {
            int code = -1;
            string[] str = id.Split(',');
            string sql = "delete from OutputNvoice where OutputNvoiceeID in (@OutputNvoiceeID)";
            foreach (var item in str)
            {
                code = await _SqlDB.ExecuteAsync(sql, new { @OutputNvoiceeID = item });
            }
            return code == 0 ? true : false;
        }

        /// <summary>
        /// 销项发票管理-反填获取详情数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<OutputNvoice> EditOutputNvoice(int id)
        {
            string sql = "select * from OutputNvoice where OutputNvoiceeID = @OutputNvoiceeID";
            return await _SqlDB.QueryFirstAsync<OutputNvoice>(sql, new { @OutputNvoiceeID = id });
        }

        /// <summary>
        /// 销项发票管理-修改数据
        /// </summary>
        /// <param name="outputNvoice"></param>
        /// <returns></returns>
        public async Task<bool> UpdOutputNvoice(OutputNvoice outputNvoice)
        {
            string sql = "update OutputNvoice set OutputNvoiceNo=@OutputNvoiceNo,OutputNvoiceName=@OutputNvoiceName,ReceiptsNvoiceType=@ReceiptsNvoiceType,InvoicePrice=@InvoicePrice,TaxRate=@TaxRate,InvoiceTime=@InvoiceTime,Remark=@Remark,PreparedBy=@PreparedBy,CreateTime=@CreateTime,ReceiptsNvoiceStatus=@ReceiptsNvoiceStatus where OutputNvoiceeID=@OutputNvoiceeID";
            int code = await _SqlDB.ExecuteAsync(sql, new
            {
                @OutputNvoiceNo = outputNvoice.OutputNvoiceNo,
                @OutputNvoiceName = outputNvoice.OutputNvoiceName,
                @ReceiptsNvoiceType = outputNvoice.ReceiptsNvoiceType,
                @InvoicePrice = outputNvoice.InvoicePrice,
                @TaxRate = outputNvoice.TaxRate,
                @InvoiceTime = outputNvoice.InvoiceTime,
                @Remark = outputNvoice.Remark,
                @PreparedBy = outputNvoice.PreparedBy,
                @CreateTime = DateTime.Now,
                @ReceiptsNvoiceStatus = outputNvoice.ReceiptsNvoiceStatus
            });
            return code == 0 ? true : false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Common.DB;
using TMS.IRepository;
using TMS.Model.ViewModel;

namespace TMS.Repository
{
    public class OwOutsourcingUnitExamineRepository : IOwOutsourcingUnitExamineRepositorycs
    {
        /// <summary>
        /// 审批管理-承运合同审批
        /// </summary>

        //调用DapperClientHelper 数据库连接
        private readonly DapperClientHelper _SqlDB;

        //对的每个调用 CreateClient(String) 都保证返回一个新的 HttpClient 实例。 调用方可以无限期缓存返回的 HttpClient 实例，也可以在 块中使用它来释放它。
        //默认IHttpClientFactory 实现可能会缓存基础 HttpMessageHandler 实例以提高性能。
        //调用方还可以根据需要自由地改变返回的 HttpClient 实例的公共属性。
        //小型工厂模式
        public OwOutsourcingUnitExamineRepository(IDapperFactory dapperFactory)
        {
            _SqlDB = dapperFactory.CreateClient("SqlDb");
        }

        /// <summary>
        /// 货主合同审批-显示+查询
        /// </summary>
        /// <param name="AcceptContractTitle">合同标题</param>
        /// <param name="AcceptContractUnit">外协单位</param>
        /// <param name="OwnerOfCargoContractName">货主负责人</param>
        /// <param name="CircuitResponsibleName">经办人</param>
        /// <param name="DateOfSigningTime">签订时间</param>
        /// <returns></returns>
        public async Task<List<OwOutsourcingUnitExamineViewModel>> GetOwOutsourcingUnitExamine(string AcceptContractTitle, string AcceptContractUnit, string OwnerOfCargoContractName, string CircuitResponsibleName, DateTime? DateOfSigningTime)
        {
            string sql = "select b.AcceptContractNo,b.AcceptContractTitle,b.AcceptContractUnit,b.OwnerOfCargoContractName,b.AcceptContractCircuit,b.TonRunPrice,b.CharteredBusConditionTonNum,b.CharteredBusPrice,b.DateOfSigningTime,b.CircuitResponsibleName,b.CreateTime,c.ExamineStatus,c.ExamineName from OwOutsourcingUnitExamine a join AcceptContract b on a.AcceptContractID = b.AcceptContractID join ExamineModel c on a.ExamineID = c.ExamineID";
            List<OwOutsourcingUnitExamineViewModel> data = await _SqlDB.QueryAsync<OwOutsourcingUnitExamineViewModel>(sql);
            //查询
            if (!string.IsNullOrEmpty(AcceptContractTitle))
            {
                data = data.Where(m => m.AcceptContractTitle.Contains(AcceptContractTitle)).ToList();
            }
            if (!string.IsNullOrEmpty(AcceptContractUnit))
            {
                data = data.Where(m => m.AcceptContractUnit.Contains(AcceptContractUnit)).ToList();
            }
            if (!string.IsNullOrEmpty(OwnerOfCargoContractName))
            {
                data = data.Where(m => m.OwnerOfCargoContractName.Contains(OwnerOfCargoContractName)).ToList();
            }
            if (!string.IsNullOrEmpty(CircuitResponsibleName))
            {
                data = data.Where(m => m.CircuitResponsibleName.Contains(CircuitResponsibleName)).ToList();
            }
            if (DateOfSigningTime is not null)
            {
                data = data.Where(m => m.DateOfSigningTime.Equals(DateOfSigningTime)).ToList();
            }
            return data;
        }

        /// <summary>
        /// 货主合同审批-查看合同审批详情信息
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<OwOutsourcingUnitExamineViewModel> EditOwOutsourcingUnitExamine(string name)
        {
            string sql = "select b.AcceptContractNo,b.AcceptContractTitle,b.AcceptContractUnit,b.OwnerOfCargoContractName,b.AcceptContractCircuit,b.TonRunPrice,b.CharteredBusConditionTonNum,b.CharteredBusPrice,b.DateOfSigningTime,b.CircuitResponsibleName,b.CreateTime,c.ExamineStatus,c.ExamineName from OwOutsourcingUnitExamine a join AcceptContract b on a.AcceptContractID = b.AcceptContractID join ExamineModel c on a.ExamineID = c.ExamineID where b.AcceptContractTitle=@AcceptContractTitle";
            return await _SqlDB.QueryFirstAsync<OwOutsourcingUnitExamineViewModel>(sql, new { @AcceptContractTitle = name });
        }

        /// <summary>
        /// 合同通过并转批
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public async Task<bool> EditPassAccommodation(string title)
        {
            string sql = "update OwOutsourcingUnitExamineViewModel set ExamineStatus=1 where AcceptContractTitle=@AcceptContractTitle";
            int code = await _SqlDB.ExecuteAsync(sql, new
            {
                @OwnerOfCargoContractTitle = title
            });
            return code == 0 ? true : false;
        }

        /// <summary>
        /// 拒绝(审批未通过)
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public async Task<bool> EditNoPass(string title)
        {
            string sql = "update OwOutsourcingUnitExamineViewModel set ExamineStatus=0 where AcceptContractTitle=@AcceptContractTitle";
            int code = await _SqlDB.ExecuteAsync(sql, new
            {
                @OwnerOfCargoContractTitle = title
            });
            return code == 0 ? true : false;
        }

        /// <summary>
        /// 审批通过并终止审批
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public async Task<bool> EditPassEnd(string title)
        {
            string sql = "update OwOutsourcingUnitExamineViewModel set ExamineStatus=1 where AcceptContractTitle=@AcceptContractTitle";
            int code = await _SqlDB.ExecuteAsync(sql, new
            {
                @OwnerOfCargoContractTitle = title
            });
            return code == 0 ? true : false;
        }
    }
}

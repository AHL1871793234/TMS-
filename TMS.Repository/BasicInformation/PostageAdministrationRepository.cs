using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Common.DB;
using TMS.IRepository.BasicInformation;
using TMS.Model.Entity.BasicInformation;

namespace TMS.Repository.BasicInformation
{
    public class PostageAdministrationRepository: IPostageAdministrationRepository
    {
        private readonly DapperClientHelper _SqlDB; //数据库连接

        public PostageAdministrationRepository(IDapperFactory dapperFactory)
        {
            _SqlDB = dapperFactory.CreateClient("SqlDb");
        }

        /// <summary>
        /// 显示油费信息
        /// </summary>
        /// <param name="carNum">车牌号</param>
        /// <param name="operatorName">经办人</param>
        /// <returns></returns>
        public async Task<List<PostageAdministration>> GetPostages(string carNum, string operatorName)
        {
            string sql = "select PostageAdministrationID,CarNumber,ComeOnCost,FuelCharge,StartKilometre,ResponsiblePerson,PayType,Remark,CreateTime from PostageAdministration";
            List<PostageAdministration> data = await _SqlDB.QueryAsync<PostageAdministration>(sql);
            if (!string.IsNullOrEmpty(carNum))
            {
                data = data.Where(x => x.CarNumber.Contains(carNum)).ToList();
            }
            if (!string.IsNullOrEmpty(operatorName))
            {
                data = data.Where(x => x.ResponsiblePerson.Contains(operatorName)).ToList();
            }
            return data;
        }

        /// <summary>
        /// 反填油费信息
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public async Task<PostageAdministration> EditPostage(int id)
        {
            string sql = "select PostageAdministrationID,CarNumber,ComeOnCost,FuelCharge,StartKilometre,ResponsiblePerson,PayType,Remark,CreateTime from PostageAdministration where PostageAdministrationID=@ID";
            return await _SqlDB.QueryFirstAsync<PostageAdministration>(sql, new { @ID = id });
        }

        /// <summary>
        /// 删除油费信息
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public async Task<bool> DelPostage(string id)
        {
            int code = -1;
            string[] str = id.Split(',');
            string sql = "delete from PostageAdministration where PostageAdministrationID in (@ID)";
            foreach (var item in str)
            {
                code = await _SqlDB.ExecuteAsync(sql, new { @ID = item });
            }
            return code == 0 ? true : false;
        }

        /// <summary>
        /// 添加油费信息
        /// </summary>
        /// <param name="model">信息</param>
        /// <returns></returns>
        public async Task<bool> AddPostage(PostageAdministration model)
        {
            string sql = "insert into PostageAdministration values(@CarNumber,@ComeOnCost,@FuelCharge,@StartKilometre,@ResponsiblePerson,@PayType,@Remark,@CreateTime)";
            int code = await _SqlDB.ExecuteAsync(sql, new
            {
                @CarNumber = model.CarNumber,
                @ComeOnCost = model.ComeOnCost,
                @FuelCharge = model.FuelCharge,
                @StartKilometre = model.StartKilometre,
                @PayType = model.PayType,
                @ResponsiblePerson = model.ResponsiblePerson,
                @Remark = model.Remark,
                @CreateTime = DateTime.Now
            });
            return code == 0 ? true : false;
        }

        /// <summary>
        /// 修改油费信息
        /// </summary>
        /// <param name="model">信息</param>
        /// <returns></returns>
        public async Task<bool> UpdPostage(PostageAdministration model)
        {
            string sql = "update PostageAdministration set CarNumber=@CarNumber,ComeOnCost=@ComeOnCost,FuelCharge=@FuelCharge,StartKilometre=@StartKilometre,PayType=@PayType,ResponsiblePerson=@ResponsiblePerson,Remark=@Remark,CreateTime=@CreateTime where PostageAdministrationID=@PostageAdministrationID";
            int code = await _SqlDB.ExecuteAsync(sql, new
            {
                @PostageAdministrationID = model.PostageAdministrationID,
                @CarNumber = model.CarNumber,
                @ComeOnCost = model.ComeOnCost,
                @FuelCharge = model.FuelCharge,
                @StartKilometre = model.StartKilometre,
                @PayType = model.PayType,
                @ResponsiblePerson = model.ResponsiblePerson,
                @Remark = model.Remark,
                @CreateTime = DateTime.Now
            });
            return code == 0 ? true : false;
        }
    }
}

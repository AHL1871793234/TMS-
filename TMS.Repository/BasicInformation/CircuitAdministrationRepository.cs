using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Common.DB;
using TMS.IRepository.BasicInformation;
using TMS.Model.Entity;

namespace TMS.Repository.BasicInformation
{
    public class CircuitAdministrationRepository: ICircuitAdministrationRepository
    {
        private readonly DapperClientHelper _SqlDB; //数据库连接

        public CircuitAdministrationRepository(IDapperFactory dapperFactory)
        {
            _SqlDB = dapperFactory.CreateClient("SqlDb");
        }

        /// <summary>
        /// 显示线路信息
        /// </summary>
        /// <param name="circuitName">线路名称</param>
        /// <param name="startAddress">起点</param>
        /// <param name="endAddress">终点</param>
        /// <param name="whether">是否是外协</param>
        /// <param name="phone">货主手机号</param>
        /// <param name="units">货主单位</param>
        /// <returns></returns>
        public async Task<List<CircuitAdministration>> GetCircuits(string circuitName, string startAddress, string endAddress, string whether, string phone, string units)
        {
            string sql = "select CircuitAdministrationID,CircuitName,CircuitStartPlace,CircuitEndPlace,IsOutsource,OwnerName,OwnerPHone,OwnerUnit,Remark,CreateTime,CircuitStatus from CircuitAdministration";
            List<CircuitAdministration> data = await _SqlDB.QueryAsync<CircuitAdministration>(sql);
            if (!string.IsNullOrEmpty(circuitName))
            {
                data = data.Where(x => x.CircuitName.Contains(circuitName)).ToList();
            }
            if (!string.IsNullOrEmpty(startAddress))
            {
                data = data.Where(x => x.CircuitStartPlace.Contains(startAddress)).ToList();
            }
            if (!string.IsNullOrEmpty(endAddress))
            {
                data = data.Where(x => x.CircuitEndPlace.Contains(endAddress)).ToList();
            }
            if (!string.IsNullOrEmpty(whether))
            {
                data = data.Where(x => x.IsOutsource.Equals(whether)).ToList();
            }
            if (!string.IsNullOrEmpty(phone))
            {
                data = data.Where(x => x.OwnerPHone.Contains(phone)).ToList();
            }
            if (!string.IsNullOrEmpty(units))
            {
                data = data.Where(x => x.OwnerUnit.Contains(units)).ToList();
            }
            return data;
        }

        /// <summary>
        /// 反填线路信息
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public async Task<CircuitAdministration> EditCircuit(int id)
        {
            string sql = "select CircuitAdministrationID,CircuitName,CircuitStartPlace,CircuitEndPlace,IsOutsource,OwnerName,OwnerPHone,OwnerUnit,Remark,CreateTime,CircuitStatus from CircuitAdministration where CircuitAdministrationID=@ID";
            return await _SqlDB.QueryFirstAsync<CircuitAdministration>(sql, new { @ID = id });
        }

        /// <summary>
        /// 删除线路信息
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public async Task<bool> DelCircuit(string id)
        {
            int code = -1;
            string[] str = id.Split(',');
            string sql = "delete from CircuitAdministration where CircuitAdministrationID in (@ID)";
            foreach (var item in str)
            {
                code = await _SqlDB.ExecuteAsync(sql, new { @ID = item });
            }
            return code == 0 ? true : false;
        }

        /// <summary>
        /// 添加线路信息
        /// </summary>
        /// <param name="model">信息</param>
        /// <returns></returns>
        public async Task<bool> AddCircuit(CircuitAdministration model)
        {
            string sql = "insert into CircuitAdministration values(@CircuitNam,@CircuitStartPlace,@CircuitEndPlace,@IsOutsource,@OwnerName,@OwnerPHone,@OwnerUnit,@Remark,@CreateTime,@CircuitStatus)";
            int code = await _SqlDB.ExecuteAsync(sql, new
            {
                @CircuitNam = model.CircuitName,
                @CircuitStartPlace = model.CircuitEndPlace,
                @CircuitEndPlace = model.CircuitEndPlace,
                @IsOutsource = model.CircuitEndPlace,
                @OwnerName = model.OwnerName,
                @OwnerPHone = model.OwnerPHone,
                @OwnerUnit = model.OwnerUnit,
                @Remark = model.Remark,
                @CreateTime = DateTime.Now,
                @CircuitStatus = 1
            });
            return code == 0 ? true : false;
        }

        /// <summary>
        /// 修改线路信息
        /// </summary>
        /// <param name="model">信息</param>
        /// <returns></returns>
        public async Task<bool> UpdCircuit(CircuitAdministration model)
        {
            string sql = "update CircuitAdministration set CircuitName=@CircuitNam,CircuitStartPlace=@CircuitStartPlace,CircuitEndPlace=@CircuitEndPlace,IsOutsource=@IsOutsource,OwnerName=@OwnerName,OwnerPHone=@OwnerPHone,OwnerUnit=@OwnerUnit,Remark=@Remark,CreateTime=@CreateTime,CircuitStatus=@CircuitStatus where CircuitAdministrationID=@CircuitAdministrationID";
            int code = await _SqlDB.ExecuteAsync(sql, new
            {
                @CircuitAdministrationID = model.CircuitAdministrationID,
                @CircuitNam = model.CircuitName,
                @CircuitStartPlace = model.CircuitEndPlace,
                @CircuitEndPlace = model.CircuitEndPlace,
                @IsOutsource = model.CircuitEndPlace,
                @OwnerName = model.OwnerName,
                @OwnerPHone = model.OwnerPHone,
                @OwnerUnit = model.OwnerUnit,
                @Remark = model.Remark,
                @CreateTime = DateTime.Now,
                @CircuitStatus = 1
            });
            return code == 0 ? true : false;
        }

        /// <summary>
        /// 小修改
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="status">状态</param>
        /// <returns></returns>
        public async Task<bool> SmallUpd(int id, int status)
        {
            string sql = "update CircuitAdministration set CircuitStatus=@status where CircuitAdministrationID=@id";
            int code = await _SqlDB.ExecuteAsync(sql, new
            {
                @id = id,
                @status = status
            });
            return code == 0 ? true : false;
        }
    }
}

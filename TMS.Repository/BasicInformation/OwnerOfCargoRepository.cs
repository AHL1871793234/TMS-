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
    public class OwnerOfCargoRepository: IOwnerOfCargoRepository
    {
        private readonly DapperClientHelper _SqlDB; //数据库连接

        public OwnerOfCargoRepository (IDapperFactory dapperFactory)
        {
            _SqlDB = dapperFactory.CreateClient("SqlDb");
        }

        /// <summary>
        /// 显示货主管理
        /// </summary>
        /// <param name="ownerName">货主名称</param>
        /// <param name="ownerPhone">货主电话</param>
        /// <param name="dateTime">驾驶证有效日期</param>
        /// <returns></returns>
        public async Task<List<OwnerOfCargo>> GetOwnerOfCargosAsync(string ownerName, string ownerPhone, DateTime? dateTime)
        {
            string sql = "select OwnerOfCargoID,OwnerOfCargoName,OwnerOfCargoPhone,CompanyName,ContactAddress,DrivingLicenceTime,DrivingLicenceImg,Remark,CreateTime from OwnerOfCargo";

            List<OwnerOfCargo> data = await _SqlDB.QueryAsync<OwnerOfCargo>(sql);

            if (!string.IsNullOrEmpty(ownerName))//货主名称
            {
                data = data.Where(x => x.OwnerOfCargoName.Contains(ownerName)).ToList();
            }
            if (!string.IsNullOrEmpty(ownerPhone))//手机号
            {
                data = data.Where(x => x.OwnerOfCargoPhone.Contains(ownerPhone)).ToList();
            }
            if (dateTime is not null)
            {
                data = data.Where(x => x.DrivingLicenceTime.Equals(dateTime)).ToList();
            }
            return data;
        }

        /// <summary>
        /// 添加货主管理
        /// </summary>
        /// <param name="model">货主信息</param>
        /// <returns></returns>
        public async Task<bool> AddOwnerAsync(OwnerOfCargo model)
        {
            string sql = "insert into OwnerOfCargo values(@OwnerOfCargoName,@OwnerOfCargoPhone,@CompanyName,@ContactAddress,@DrivingLicenceTime,@DrivingLicenceImg,@Remark,@CreateTime)";
            int code = await _SqlDB.ExecuteAsync(sql, new
            {
                @OwnerOfCargoName = model.OwnerOfCargoName,
                @OwnerOfCargoPhone = model.OwnerOfCargoPhone,
                @CompanyName = model.CompanyName,
                @ContactAddress = model.ContactAddress,
                @DrivingLicenceTime = model.DrivingLicenceTime,
                @DrivingLicenceImg = model.DrivingLicenceImg,
                @Remark = model.Remark,
                @CreateTime = DateTime.Now
            });
            return code == 0 ? true : false;
        }


        /// <summary>
        /// 删除货主管理
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public async Task<bool> DelOwnerAsync(string id)
        {
            int code = -1;
            string[] str = id.Split(',');
            string sql = "delete from OwnerOfCargo where OwnerOfCargoID in (@ID)";
            foreach (var item in str)
            {
                code = await _SqlDB.ExecuteAsync(sql, new { @ID = item });
            }
            return code == 0 ? true : false;
        }

        /// <summary>
        /// 反填货主信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<OwnerOfCargo> EditOwnerAsync(int id)
        {
            string sql = "select OwnerOfCargoID,OwnerOfCargoName,OwnerOfCargoPhone,CompanyName,ContactAddress,DrivingLicenceTime,DrivingLicenceImg,Remark,CreateTime from OwnerOfCargo  where OwnerOfCargoID = @ID";
            return await _SqlDB.QueryFirstAsync<OwnerOfCargo>(sql, new { @ID = id });
        }

        /// <summary>
        /// 修改货主信息
        /// </summary>
        /// <param name="model">货主信息</param>
        /// <returns></returns>
        public async Task<bool> UpdOwnerAsync(OwnerOfCargo model)
        {
            string sql = "update OwnerOfCargo set OwnerOfCargoName=@OwnerOfCargoName,OwnerOfCargoPhone=@OwnerOfCargoPhone,CompanyName=@CompanyName,ContactAddress=@ContactAddress,DrivingLicenceTime=@DrivingLicenceTime,DrivingLicenceImg=@DrivingLicenceImg,Remark=@Remark,CreateTime=@CreateTime where OwnerOfCargoID=@OwnerOfCargoID";
            int code = await _SqlDB.ExecuteAsync(sql, new
            {
                @OwnerOfCargoID = model.OwnerOfCargoID,
                @OwnerOfCargoName = model.OwnerOfCargoName,
                @OwnerOfCargoPhone = model.OwnerOfCargoPhone,
                @CompanyName = model.CompanyName,
                @ContactAddress = model.ContactAddress,
                @DrivingLicenceTime = model.DrivingLicenceTime,
                @DrivingLicenceImg = model.DrivingLicenceImg,
                @Remark = model.Remark,
                @CreateTime = DateTime.Now
            });
            return code == 0 ? true : false;
        }
    }
}

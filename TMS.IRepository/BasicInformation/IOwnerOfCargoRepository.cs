using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Model.Entity;

namespace TMS.IRepository.BasicInformation
{
    public interface IOwnerOfCargoRepository
    {
        /// <summary>
        /// 显示货主管理
        /// </summary>
        /// <param name="ownerName">货主名称</param>
        /// <param name="ownerPhone">货主电话</param>
        /// <param name="dateTime">驾驶证有效日期</param>
        /// <returns></returns>
        Task<List<OwnerOfCargo>> GetOwnerOfCargosAsync(string ownerName, string ownerPhone, DateTime? dateTime);

        /// <summary>
        /// 添加货主管理
        /// </summary>
        /// <param name="model">货主信息</param>
        /// <returns></returns>
        Task<bool> AddOwnerAsync(OwnerOfCargo model);


        /// <summary>
        /// 删除货主管理
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        Task<bool> DelOwnerAsync(string id);

        /// <summary>
        /// 反填货主信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<OwnerOfCargo> EditOwnerAsync(int id);

        /// <summary>
        /// 修改货主信息
        /// </summary>
        /// <param name="model">货主信息</param>
        /// <returns></returns>
        Task<bool> UpdOwnerAsync(OwnerOfCargo model);
    }
}

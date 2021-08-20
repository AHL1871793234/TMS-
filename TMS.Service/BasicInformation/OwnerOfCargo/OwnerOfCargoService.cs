using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.IRepository.BasicInformation;
using TMS.Model.Entity;
using TMS.Service.BasicInformation;

namespace TMS.Service.BasicInformation
{
    public class OwnerOfCargoService:IOwnerOfCargoService
    {
        private readonly IOwnerOfCargoRepository owner;

        public OwnerOfCargoService(IOwnerOfCargoRepository _owner)
        {
            owner = _owner;
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
            return await owner.GetOwnerOfCargosAsync(ownerName, ownerPhone, dateTime);
        }

        /// <summary>
        /// 添加货主管理
        /// </summary>
        /// <param name="model">货主信息</param>
        /// <returns></returns>
        public async Task<bool> AddOwnerAsync(OwnerOfCargo model)
        {
            return await owner.AddOwnerAsync(model);
        }

        /// <summary>
        /// 删除货主管理
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public async Task<bool> DelOwnerAsync(string id)
        {
            return await owner.DelOwnerAsync(id);
        }

        /// <summary>
        /// 反填货主信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<OwnerOfCargo> EditOwnerAsync(int id)
        {
            return await owner.EditOwnerAsync(id);
        }

        /// <summary>
        /// 修改货主信息
        /// </summary>
        /// <param name="model">货主信息</param>
        /// <returns></returns>
        public async Task<bool> UpdOwnerAsync(OwnerOfCargo model)
        {
            return await owner.UpdOwnerAsync(model);
        }
    }
}

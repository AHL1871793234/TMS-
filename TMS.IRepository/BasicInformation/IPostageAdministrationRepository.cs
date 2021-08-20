using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Model.Entity.BasicInformation;

namespace TMS.IRepository.BasicInformation
{
    public interface IPostageAdministrationRepository
    {
        /// <summary>
        /// 显示油费信息
        /// </summary>
        /// <param name="carNum">车牌号</param>
        /// <param name="operatorName">经办人</param>
        /// <returns></returns>
        Task<List<PostageAdministration>> GetPostages(string carNum, string operatorName);

        /// <summary>
        /// 反填油费信息
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        Task<PostageAdministration> EditPostage(int id);

        /// <summary>
        /// 删除油费信息
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        Task<bool> DelPostage(string id);

        /// <summary>
        /// 添加油费信息
        /// </summary>
        /// <param name="model">信息</param>
        /// <returns></returns>
        Task<bool> AddPostage(PostageAdministration model);

        /// <summary>
        /// 修改油费信息
        /// </summary>
        /// <param name="model">信息</param>
        /// <returns></returns>
        Task<bool> UpdPostage(PostageAdministration model);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.IRepository.BasicInformation;
using TMS.Model.Entity.BasicInformation;

namespace TMS.Service.BasicInformation.ThePostageManagement
{
    public class PostageAdministrationService: IPostageAdministrationService
    {
        private readonly IPostageAdministrationRepository _postage;

        public PostageAdministrationService(IPostageAdministrationRepository postage)
        {
            _postage = postage;
        }

        /// <summary>
        /// 显示油费信息
        /// </summary>
        /// <param name="carNum">车牌号</param>
        /// <param name="operatorName">经办人</param>
        /// <returns></returns>
        public async Task<List<PostageAdministration>> GetPostages(string carNum, string operatorName)
        {
            return await _postage.GetPostages(carNum, operatorName);
        }

        /// <summary>
        /// 反填油费信息
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public async Task<PostageAdministration> EditPostage(int id)
        {
            return await _postage.EditPostage(id);
        }

        /// <summary>
        /// 删除油费信息
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public async Task<bool> DelPostage(string id)
        {
            return await _postage.DelPostage(id);
        }

        /// <summary>
        /// 添加油费信息
        /// </summary>
        /// <param name="model">信息</param>
        /// <returns></returns>
        public async Task<bool> AddPostage(PostageAdministration model)
        {
            return await _postage.AddPostage(model);
        }

        /// <summary>
        /// 修改油费信息
        /// </summary>
        /// <param name="model">信息</param>
        /// <returns></returns>
        public async Task<bool> UpdPostage(PostageAdministration model)
        {
            return await _postage.UpdPostage(model);
        }
    }
}

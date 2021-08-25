using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Common.DB;
using TMS.IRepository.User;
using TMS.Model.Entity.User;
using TMS.Model.ViewModel;

namespace TMS.Repository.User
{
    public class MenuRepository: IMenuRepository
    {
        private readonly DapperClientHelper _SqlDB;//数据库连接

        public MenuRepository(IDapperFactory dapperFactory)
        {
            _SqlDB = dapperFactory.CreateClient("SqlDb");
        }


        /// <summary>
        /// 根据用户ID显示菜单
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<List<MenuModel>> GetMenusAsync()
        {
            string sql = "select e.MenuID,e.MenuName,e.MenuParentID,e.MenuLink,e.MenuIcon,e.MenuStatus from UserRoleModel a join UserModel b on a.UserId=b.UserId join RoleModel c on c.RoleId = a.RoleId join RoleMenuModel d on c.RoleId = d.RoleId join MenuModel e on e.MenuId = d.MenuId where b.UserId = @userId ";
            List<MenuModel> data = await _SqlDB.QueryAsync<MenuModel>(sql, new { @userId = UserRoleMenuViewModel.UserId });
            return data;
        }

        //显示所有菜单
        public async Task<List<MenuModel>> GetMenus()
        {
            string sql = "select MenuID,MenuName,MenuParentID,MenuLink,MenuIcon,MenuStatus from menumodel";
            List<MenuModel> data = await _SqlDB.QueryAsync<MenuModel>(sql);
            return data;
        }

        #region  递归拼接菜单
        /// <summary>
        /// 菜单
        /// </summary>
        /// <returns></returns>
        public async Task<List<Dictionary<string, object>>> Tree(/*int roleID*/)
        {
            List<MenuModel> menus = await GetMenus();//获取全部菜单
            List<MenuModel> father = menus.Where(x => x.MenuParentID == 0).ToList();//获取上级ID为0的菜单
            //定义字典集合保存拼接信息
            List<Dictionary<string, object>> json = new List<Dictionary<string, object>>();
            //执行拼接
            foreach (var item in father)
            {
                Dictionary<string, object> data = new Dictionary<string, object>();
                data.Add("id", item.MenuID);
                data.Add("label", item.MenuName);
                TreeChild(menus, data, item.MenuID);//调用递归实现拼接
                json.Add(data);
            }

            return json;
        }
        public void TreeChild(List<MenuModel> menus, Dictionary<string, object> json, int parentId)
        {
            //根据上级ID获取菜单
            List<MenuModel> children = menus.Where(x => x.MenuParentID == parentId).ToList();
            //定义字典集合保存拼接信息
            List<Dictionary<string, object>> data = new List<Dictionary<string, object>>();
            if (children.Count == 0)
            {
                json.Add("children", null);
                return;
            }
            //执行拼接
            foreach (var item in children)
            {
                Dictionary<string, object> data1 = new Dictionary<string, object>();
                data1.Add("id", item.MenuID);
                data1.Add("label", item.MenuName);
                TreeChild(menus, data1, item.MenuID);//调用递归实现拼接
                data.Add(data1);
            }
            json.Add("children", data);
        }
        #endregion

        /// <summary>
        /// 根据角色ID获取菜单Id
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public async Task<List<int>> Menu_ID(int roleId)
        {
            string sql = "select MenuModel.MenuID from RoleMenuModel join RoleModel on RoleModel.RoleId = RoleMenuModel.RoleId join MenuModel on MenuModel.MenuId = RoleMenuModel.MenuId where RoleModel.RoleId = @roleId and MenuModel.MenuParentID != 0";
            return await _SqlDB.QueryAsync<int>(sql, new { @roleId = roleId });
        }


        /// <summary>
        /// 分配权限
        /// </summary>
        /// <param name="roleId">要分配的角色Id</param>
        /// <param name="intList">权限菜单Id集合</param>
        /// <returns></returns>
        public async Task<bool> AddRoleMenu(int roleId, string intList)
        {
            string[] strArray = intList.Split(',');

            string delsql = "delete from RoleMenuModel where RoleID=@roleId";

            int codedel = await _SqlDB.ExecuteAsync(delsql, new { @roleId = roleId });

            string sql = "insert into RoleMenuModel values(@roleId,@menuId)";

            int code = -1;

            foreach (var item in strArray)
            {
                code = await _SqlDB.ExecuteAsync(sql, new { @roleId = roleId, @menuId = item });
            }

            return code == 0 ? true : false;
        }
    }
}

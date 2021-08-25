using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Model.Entity.Setting
{
    /// <summary>
    /// 菜单表
    /// </summary>
    public class MenuModel
    {
        /// <summary>
        /// 菜单Id
        /// </summary>
        public int MenuID { get; set; }
        /// <summary>
        /// 菜单名称
        /// </summary>
        public string MenuName { get; set; }
        /// <summary>
        /// 菜单上级Id
        /// </summary>
        public int MenuParentID { get; set; }
        /// <summary>
        /// 菜单路径
        /// </summary>
        public string MenuLink { get; set; }
        /// <summary>
        /// 菜单图标
        /// </summary>
        public string MenuIcon { get; set; }
        /// <summary>
        /// 菜单状态
        /// </summary>
        public int MenuStatus { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entity.MDM
{
    /// <summary>
    /// 工艺维护菜单项
    /// </summary>
    public class MethodMMenu
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int Ordinal { get; set; }
        /// <summary>
        /// 菜单项标识
        /// </summary>
        public int MenuItemID { get; set; }
        /// <summary>
        /// 菜单名称
        /// </summary>
        public string MenuName { get; set; }
        /// <summary>
        /// 菜单属性
        /// </summary>
        public string MenuAttr { get; set; }
        /// <summary>
        /// 是否可见：0-不可见；1-可见
        /// </summary>
        public bool IsVisible { get; set; }
        /// <summary>
        /// 是否可用：0-不可用；1-可用
        /// </summary>
        public bool IsEnabled { get; set; }

        public override string ToString()
        {
            return MenuName;
        }

        public MethodMMenu Clone()
        {
            return MemberwiseClone() as MethodMMenu;
        }
    }
}
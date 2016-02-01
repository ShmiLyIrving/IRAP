using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

using IRAP.Global;
using IRAPShared;

namespace IRAP.Entity.SSO
{
    public class SystemMenuInfoMenuStyle : MenuInfo
    {
        private byte[] menuIconImage;
        private Image imageMenuIcon = null;

        /// <summary>
        /// 父菜单标识
        /// </summary>
        public int Parent { get; set; }
        /// <summary>
        /// 图标文件
        /// </summary>
        public string MenuIconFile { get; set; }
        /// <summary>
        /// 图标图像
        /// </summary>
        public byte[] MenuIconImage
        {
            get { return menuIconImage; }
            set 
            { 
                menuIconImage = value;
                imageMenuIcon = Tools.BytesToImage(value);
            }
        }
        [IRAPORMMap(ORMMap = false)]
        public Image ImageMenuIcon
        {
            get { return imageMenuIcon; }
        }
        /// <summary>
        /// 加速键
        /// </summary>
        public string AccelerateKey { get; set; }
        /// <summary>
        /// 菜单结点深度
        /// </summary>
        public int NodeDepth { get; set; }
        /// <summary>
        /// 是否新菜单分组
        /// </summary>
        public bool NewMenuGroup { get; set; }

        public new SystemMenuInfoMenuStyle Clone()
        {
            return this.MemberwiseClone() as SystemMenuInfoMenuStyle;
        }
    }
}

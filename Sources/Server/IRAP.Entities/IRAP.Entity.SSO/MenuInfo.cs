using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

using IRAP.Global;
using IRAPShared;

namespace IRAP.Entity.SSO
{
    public class MenuInfo
    {
        private byte[] toolBarIconImage;
        private Image imageToolBarIcon = null;

        /// <summary>
        /// 菜单项标识
        /// </summary>
        public int ItemID { get; set; }
        /// <summary>
        /// 菜单项
        /// </summary>
        public string ItemText { get; set; }
        /// <summary>
        /// 热键
        /// </summary>
        public string HotKey { get; set; }
        /// <summary>
        /// 菜单项序号
        /// </summary>
        public double Ordinal { get; set; }
        /// <summary>
        /// 微帮助
        /// </summary>
        public string MicroHelp { get; set; }
        /// <summary>
        /// 工具条项目提示
        /// </summary>
        public string ToolBarItemHint { get; set; }
        /// <summary>
        /// 工具条图标文件
        /// </summary>
        public string ToolBarIconFile { get; set; }
        /// <summary>
        /// 工具条图标图像
        /// </summary>
        public byte[] ToolBarIconImage
        {
            get { return toolBarIconImage; }
            set
            {
                toolBarIconImage = value;
                imageToolBarIcon = Tools.BytesToImage(value);
            }
        }
        [IRAPORMMap(ORMMap = false)]
        public Image ImageToolBarIcon
        {
            get { return imageToolBarIcon; }
        }
        /// <summary>
        /// 工具条新分组
        /// </summary>
        public bool ToolBarNewSpace { get; set; }
        /// <summary>
        /// 表单名
        /// </summary>
        public string FormName { get; set; }
        /// <summary>
        /// 表单类型
        /// </summary>
        public int FormType { get; set; }
        /// <summary>
        /// 程序集文件
        /// </summary>
        public string FileBuiltin { get; set; }
        /// <summary>
        /// 外联Win16位应用程序
        /// </summary>
        public string Win16ExeName { get; set; }
        /// <summary>
        /// 外联Win32位应用程序
        /// </summary>
        public string Win32ExeName { get; set; }
        /// <summary>
        /// 业务操作结点
        /// </summary>
        public string OpNode { get; set; }
        /// <summary>
        /// 树视图控制参数
        /// </summary>
        public string TVCtrlParameters { get; set; }
        /// <summary>
        /// 菜单参数
        /// </summary>
        public string Parameters { get; set; }
        /// <summary>
        /// 外联Unix脚本
        /// </summary>
        public string UnixAppName { get; set; }
        /// <summary>
        /// 在线帮助XML
        /// </summary>
        public string HelpXML { get; set; }

        public virtual MenuInfo Clone()
        {
            return MemberwiseClone() as MenuInfo;
        }
    }
}

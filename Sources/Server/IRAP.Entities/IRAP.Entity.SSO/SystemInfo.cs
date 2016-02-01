using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

using IRAP.Global;
using IRAPShared;

namespace IRAP.Entity.SSO
{
    public class SystemInfo
    {
        private byte[] iconImage;
        private byte[] logoPic;
        private byte[] backgroundPic;
        private Image imageIcon = null;
        private Image imageLogo = null;
        private Image imageBackground = null;

        /// <summary>
        /// 系统标识
        /// </summary>
        public int SystemID { get; set; }
        /// <summary>
        /// 系统名称
        /// </summary>
        public string SystemName { get; set; }
        /// <summary>
        /// 版本号
        /// </summary>
        public string VersionNo { get; set; }
        /// <summary>
        /// 图标文件
        /// </summary>
        public string IconFile { get; set; }
        /// <summary>
        /// 图标图像
        /// </summary>
        public byte[] IconImage
        {
            get { return iconImage; }
            set
            {
                iconImage = value;
                imageIcon = Tools.BytesToImage(value);
            }
        }
        [IRAPORMMap(ORMMap = false)]
        public Image ImageIcon
        {
            get { return imageIcon; }
        }
        /// <summary>
        /// 软件产品编号
        /// </summary>
        public string ProductNo { get; set; }
        /// <summary>
        /// 发布年月
        /// </summary>
        public string GAYearMonth { get; set; }
        /// <summary>
        /// 著作权人
        /// </summary>
        public string Author { get; set; }
        /// <summary>
        /// 共有著作权人
        /// </summary>
        public string Coauthor { get; set; }
        /// <summary>
        /// Logo图片文件路径
        /// </summary>
        public string LogoPicPath { get; set; }
        /// <summary>
        /// Logo图片图像
        /// </summary>
        public byte[] LogoPic
        {
            get { return logoPic; }
            set
            {
                logoPic = value;
                imageLogo = Tools.BytesToImage(value);
            }
        }
        [IRAPORMMap(ORMMap = false)]
        public Image ImageLogo
        {
            get { return imageLogo; }
        }
        /// <summary>
        /// 背景图片文件路径
        /// </summary>
        public string BGPicPath { get; set; }
        /// <summary>
        /// 背景图片图像
        /// </summary>
        public byte[] BackgroundPic
        {
            get { return backgroundPic; }
            set
            {
                backgroundPic = value;
                imageBackground = Tools.BytesToImage(value);
            }
        }
        [IRAPORMMap(ORMMap = false)]
        public Image ImageBackground
        {
            get { return imageBackground; }
        }
        /// <summary>
        /// 菜单风格（左右+上下）
        /// </summary>
        public int MenuStyle { get; set; }
        /// <summary>
        /// 菜单显示控制值
        /// </summary>
        public int MenuShowCtrl { get; set; }
        /// <summary>
        /// 显示工具条
        /// </summary>
        public bool AddToolBar { get; set; }
        /// <summary>
        /// 屏幕分辨率
        /// </summary>
        public int ScreenResolution { get; set; }
        /// <summary>
        /// 按键流
        /// </summary>
        public string KeyStrokeStream { get; set; }
        /// <summary>
        /// 是否有权访问
        /// </summary>
        public bool Accessible { get; set; }
        /// <summary>
        /// 默认数据源连接
        /// </summary>
        public int DataSrcLinkID { get; set; }
        /// <summary>
        /// 应用服务器地址
        /// </summary>
        public string Application { get; set; }

        public override string ToString()
        {
            return SystemName;
        }

        public SystemInfo Clone()
        {
            return MemberwiseClone() as SystemInfo;
        }
    }
}

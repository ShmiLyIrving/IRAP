// 文 件 名：BackGround.cs
// 功能描述：自动运行实体
// 修改描述：
//----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanMGMT.Entity
{
    public class BackGround
    {
        public BackGround(int idx,string name,string path)
        {
            index = idx;
            Name = name;
            ImagePath = path;
        }
        /// <summary>
        /// 背景索引
        /// </summary>
        public int index { get; set; }
        /// <summary>
        /// 背景名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 背景图片文件路径
        /// </summary>
        public string ImagePath { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}

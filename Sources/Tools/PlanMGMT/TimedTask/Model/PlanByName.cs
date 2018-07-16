// 文 件 名：PlanByName.cs
// 功能描述：项目名称和负责人关联类
// 修改描述：
//----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanMGMT.Model
{
    public class PlanByName
    {
        /// <summary>
        /// 用户代码
        /// </summary>
        public string UserCode { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        public PlanByName() { }
        public PlanByName(string code, string name)
        {
            this.UserCode = code;
            this.UserName = name;
        }
        /// <summary>
        /// Expander控件是否展开
        /// </summary>
        public bool IsExpanded
        {
            get
            {
                if (!BLL.PlanBLL.Instance.Expanded.Contains(this.UserCode))
                {
                    return false;
                }
                else
                    return true;
            }
            set
            {
                if (value)
                {
                    if (!BLL.PlanBLL.Instance.Expanded.Contains(this.UserCode))
                    {
                        BLL.PlanBLL.Instance.Expanded.Add(this.UserCode);
                    }
                }
                else
                {
                    if (BLL.PlanBLL.Instance.Expanded.Contains(this.UserCode))
                    {
                        BLL.PlanBLL.Instance.Expanded.Remove(this.UserCode);
                    }
                }
            }
        }
        public override string ToString()
        {
            return UserName;
        }
    }
}

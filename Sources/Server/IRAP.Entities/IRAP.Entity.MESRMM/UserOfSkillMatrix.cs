using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entity.MESRMM
{
    /// <summary>
    /// 可以用于技能矩阵中的用户
    /// </summary>
    public class UserOfSkillMatrix
    {
        /// <summary>
        /// 用户代码
        /// </summary>
        public string UserCode { get; set; }
        /// <summary>
        /// 用户姓名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string Gender { get; set; }
        /// <summary>
        /// 机构叶标识
        /// </summary>
        public int AgencyLeaf { get; set; }
        /// <summary>
        /// 隶属部门
        /// </summary>
        public string AgencyName { get; set; }
        /// <summary>
        /// 角色叶标识
        /// </summary>
        public int RoleLeaf { get; set; }
        /// <summary>
        /// 拥有角色
        /// </summary>
        public string RoleName { get; set; }
        /// <summary>
        /// 标识条码
        /// </summary>
        public string UserCodeBarcode { get; set; }
        /// <summary>
        /// 手机号码
        /// </summary>
        public string MobileNo { get; set; }
        /// <summary>
        /// 异常事件响应优先级
        /// </summary>
        public int EventRespondingPriority { get; set; }
        /// <summary>
        /// 正在处理的异常事件标识
        /// </summary>
        public long LinkedToEventID { get; set; }

        public UserOfSkillMatrix Clone()
        {
            return MemberwiseClone() as UserOfSkillMatrix;
        }
    }
}

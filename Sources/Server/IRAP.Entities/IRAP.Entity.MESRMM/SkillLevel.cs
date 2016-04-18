using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entity.MESRMM
{
    /// <summary>
    /// 技能熟练程度
    /// </summary>
    public class SkillLevel
    {
        /// <summary>
        /// 技能熟练等级
        /// </summary>
        public int Level { get; set; }
        /// <summary>
        /// 技能熟练等级描述
        /// </summary>
        public string SkillLevelString { get; set; }

        public SkillLevel Clone()
        {
            return MemberwiseClone() as SkillLevel;
        }
    }
}
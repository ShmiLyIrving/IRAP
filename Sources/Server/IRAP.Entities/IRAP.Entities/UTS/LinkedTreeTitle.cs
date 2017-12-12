using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entity.UTS {
    public class LinkedTreeTitle {
    }

    public class LinkedTreeTip {
        /// <summary>
        /// 导入导出关联的树标识
        /// </summary>
        public int TreeID { get; set; }

        /// <summary>
        /// 选择叶子的提示标签
        /// </summary>
        public string PromptStr { get; set; }
    }
}

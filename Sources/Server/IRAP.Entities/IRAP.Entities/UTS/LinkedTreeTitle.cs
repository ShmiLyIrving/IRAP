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

    public class LeafSet {
        /// <summary>
        /// 分区键
        /// </summary>
        public long PartitioningKey { get; set; }

        /// <summary>
        /// 叶标识
        /// </summary>
        public int LeafID { get; set; }

        /// <summary>
        /// 实体标识
        /// </summary>
        public int EntityID { get; set; }

        /// <summary>
        /// 实体代码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 实体名称
        /// </summary>
        public string LeafName { get; set; }

        /// <summary>
        /// 叶状态
        /// </summary>
        public int LeafStatus { get; set; }
    }

    public class ImportParam {
        /// <summary>
        /// 信号旗文件路径
        /// </summary>
        public string FlagFilePath { get; set; }
        /// <summary>
        /// 数据文件路径
        /// </summary>
        public string DataFilePath { get; set; }
        /// <summary>
        /// 文件名前缀
        /// </summary>
        public string FileNamePrefix { get; set; }
        /// <summary>
        /// 文件扩展名
        /// </summary>
        public string FileExtensionName { get; set; }
        /// <summary>
        /// 格式文件名
        /// </summary>
        public string FormatFileName { get; set; }
        /// <summary>
        /// 目标表名
        /// </summary>
        public string DstTableName { get; set; }
        /// <summary>
        /// 目标表是否存在
        /// </summary>
        public string DstTableExist { get; set; }
        /// <summary>
        /// 创建表存储过程
        /// </summary>
        public string ProcToCreateTBL { get; set; }
        /// <summary>
        /// 提示
        /// </summary>
        public string ToolTip { get; set; }
        /// <summary>
        /// 校验存储过程名
        /// </summary>
        public string ProcOnVerification { get; set; }
        /// <summary>
        /// 是否允许部分加载
        /// </summary>
        public string PartialLoadPermitted { get; set; }
        /// <summary>
        /// 加载存储过程
        /// </summary>
        public string ProcOnLoad { get; set; }
    }

    public class ImportMetaData {
        /// <summary>
        /// 序号
        /// </summary>
        public int Ordinal { get; set; }
        /// <summary>
        /// 列名
        /// </summary>
        public string ColName { get; set; }
        /// <summary>
        /// 列名称
        /// </summary>
        public string ColDisplayName { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public string ColType { get; set; }
        /// <summary>
        /// 长度
        /// </summary>
        public int Length { get; set; }
        /// <summary>
        /// 保留几位数
        /// </summary>
        public int Prec { get; set; }

        public int Scale { get; set; }

        public int Nullable { get; set; }
        /// <summary>
        /// 对齐方式
        /// </summary>
        public string Alignment { get; set; }
        /// <summary>
        /// 宽度
        /// </summary>
        public int DisplayWidth { get; set; }
        /// <summary>
        /// 是否可编辑
        /// </summary>
        public int EditEnabled { get; set; }

        /// <summary>
        /// 是否可见
        /// </summary>
        public string Visible { get; set; }
    }
}

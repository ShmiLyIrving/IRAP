using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Client.GUI.MDM
{
    /// <summary>
    /// 行集属性编辑器工厂
    /// </summary>
    public class PropertiesFormFactory
    {
        public static frmCustomProperites CreateInstance(int itemID)
        {
            frmCustomProperites instance = null;

            switch (itemID)
            {
                case -354007:
                    instance = new frmMethodStandardProperties();        // 工艺参数标准
                    break;
                case -354008:
                    instance = new frmInspectStandardProperites();        // 质量检查标准
                    break;
                case -354009:
                    instance = new frmTestStandardProperties();        // 机器测试标准
                    break;
                case -354010:
                    instance = new frmToolingStandardProperties();      // 工装使用标准
                    break;
                case -354011:
                    instance = new frmLoadingStandardProperties();        // 物料装料标准
                    break;
                case -354012:
                    instance = null;        // 返工卸料标准
                    break;
                case -354013:
                    instance = null;        // 产品包装标准
                    break;
                case -373377:
                    instance = new frmProductionProgramProperties();        // 生产程序标准
                    break;
                case -354014:
                    instance = new frmFailureModeProperties();        // 失效模式清单
                    break;
                case -354015:
                    instance = new frmOPStandardProperties();        // 生产作业标准
                    break;
                case -373386:
                    instance = new frmEnvParamStandardProperties();        // 环境参数标准
                    break;
                case -373387:
                    instance = new frmEnergyStandardProperties();        // 能源参数标准
                    break;
                case -373374:
                    instance = new frmPrepareStandardProperties();        // 生产准备事项
                    break;
                case -354016:
                    instance = new frmPokaYokeRuleProperties();        // 生产防错规则
                    break;
                case -373389:
                    instance = null;        // 工艺文档清单
                    break;
                case -372154:
                    instance = null;        // 员工技能矩阵
                    break;
            }

            return instance;
        }
    }
}
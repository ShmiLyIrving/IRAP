using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace IRAP.Client.GUI.MDM
{
    public enum SelectNodeType
    {
        [Description("无")]
        sntNone = -1,
        [Description("流程开始节点")]
        sntBegin = 0,
        [Description("有料生产工序")]
        sntProductionOfMaterial = 12158,
        [Description("无料加工工序")]
        sntNoMaterialProcessing = 12159,
        [Description("人工检查工序")]
        sntManualInspection = 12161,
        [Description("机器测试工序")]
        sntMachineTesting = 12165,
        [Description("故障维修工序")]
        sntTroubleShooting = 12168,
        [Description("成品包装工序")]
        sntProductPackaging = 12166,
        [Description("有料生产+人工检查工序")]
        sntProductionOfMaterialAndManualInspection = 12180,
        [Description("无料加工+人工检查工序")]
        sntNoMaterialProcessingAndManualInspection = 12182,
        [Description("有料生产+机器测试工序")]
        sntProductionOfMaterialAndMachineTesting = 12221,
        [Description("产品包装+附件配套工序")]
        sntProductPackagingAndAccessory = 12222,
        [Description("虚拟复合工序")]
        sntVirtualComposite = 39490,
        [Description("流程连接线")]
        sntLink = 98,
        [Description("流程结束节点")]
        sntEnd = 99,
    }
}
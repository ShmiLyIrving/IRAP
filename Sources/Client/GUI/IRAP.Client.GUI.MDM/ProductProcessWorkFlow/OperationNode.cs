using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

using IRAP.Components.WorkFlow;
using IRAP.Entity.MDM;
using IRAP.Client.Global.Resources.Properties;

namespace IRAP.Client.GUI.MDM
{
    /// <summary>
    /// 流程图节点类
    /// </summary>
    public class OperationNode : ItemNode
    {
        public OperationNode(Graphics graphics, Point location, int ordinal = 0) :
                    base(graphics, location, ordinal)
        {
        }

        public new object Tag
        {
            get { return tag; }
            set
            {
                if (value is ProcessOperation)
                {
                    tag = value;
                    ItemName =
                        string.Format(
                            "{0}\n[{1}]",
                            (value as ProcessOperation).T216Name,
                            (value as ProcessOperation).T216Code);

                    foreach (ItemLink link in prevLinks)
                    {
                        if (link is ProcessLine)
                        {
                            ProcessLine line = link as ProcessLine;
                            if (line.Tag != null)
                                line.Tag.T216LeafID2 = (value as ProcessOperation).T216Leaf;
                        }
                    }

                    foreach (ItemLink link in nextLinks)
                    {
                        if (link is ProcessLine)
                        {
                            ProcessLine line = link as ProcessLine;
                            if (line.Tag != null)
                                line.Tag.T216LeafID1 = (value as ProcessOperation).T216Leaf;
                        }
                    }
                }
                else
                {
                    throw new Exception("Tag 只能被赋予 ProcessOperation 对象");
                }
            }
        }
    }

    /// <summary>
    /// 有料生产工序类型节点类
    /// </summary>
    public class ProductionOfMaterial : OperationNode
    {
        public ProductionOfMaterial(Graphics graphics, Point location, int ordinal = 0) :
            base(graphics, location, ordinal)
        {
            SetItemImage(Resources.有料生产工序, location);
        }
    }

    /// <summary>
    /// 无料加工工序类型节点类
    /// </summary>
    public class NoMaterialProcessing : OperationNode
    {
        public NoMaterialProcessing(Graphics graphics, Point location, int ordinal = 0) :
            base(graphics, location, ordinal)
        {
            SetItemImage(Resources.无料加工工序, location);
        }
    }

    /// <summary>
    /// 人工检查工序类型节点类
    /// </summary>
    public class ManualInspection : OperationNode
    {
        public ManualInspection(Graphics graphics, Point location, int ordinal = 0) :
                    base(graphics, location, ordinal)
        {
            SetItemImage(Resources.人工检查工序, location);
        }
    }

    /// <summary>
    /// 机器测试工序类型节点类
    /// </summary>
    public class MachineTesting : OperationNode
    {
        public MachineTesting(Graphics graphics, Point location, int ordinal = 0) :
                    base(graphics, location, ordinal)
        {
            SetItemImage(Resources.机器测试工序, location);
        }
    }

    /// <summary>
    /// 故障维修工序类型节点类
    /// </summary>
    public class TroubleShooting : OperationNode
    {
        public TroubleShooting(Graphics graphics, Point location, int ordinal = 0) :
                    base(graphics, location, ordinal)
        {
            SetItemImage(Resources.故障维修工序, location);
        }
    }

    /// <summary>
    /// 产品包装工序类型节点类
    /// </summary>
    public class ProductPackaging : OperationNode
    {
        public ProductPackaging(Graphics graphics, Point location, int ordinal = 0) :
                    base(graphics, location, ordinal)
        {
            SetItemImage(Resources.成品包装工序, location);
        }
    }

    /// <summary>
    /// 有料生产和人工检查复合工序类型节点类
    /// </summary>
    public class ProductionOfMaterialAndManualInspection : OperationNode
    {
        public ProductionOfMaterialAndManualInspection(
            Graphics graphics,
            Point location,
            int ordinal = 0) :
            base(graphics, location, ordinal)
        {
            SetItemImage(Resources.有料生产人工检查工序, location);
        }
    }

    /// <summary>
    /// 无料加工和人工检查复合工序类型节点类
    /// </summary>
    public class NoMaterialProcessingAndManualInspection: OperationNode
    {
        public NoMaterialProcessingAndManualInspection(
            Graphics graphics,
            Point location,
            int ordinal = 0) :
            base(graphics, location, ordinal)
        {
            SetItemImage(Resources.无料加工人工检查工序, location);
        }
    }

    /// <summary>
    /// 有料生产和机器测试复合工序类型节点类
    /// </summary>
    public class ProductionOfMaterialAndMachineTesting : OperationNode
    {
        public ProductionOfMaterialAndMachineTesting(
            Graphics graphics,
            Point location,
            int ordinal = 0) :
            base(graphics, location, ordinal)
        {
            SetItemImage(Resources.有料生产机器测试工序, location);
        }
    }

    /// <summary>
    /// 成品包装盒附件配套复合工序类型节点类
    /// </summary>
    public class ProductPackagingAndAccessory : OperationNode
    {
        public ProductPackagingAndAccessory(
            Graphics graphics,
            Point location,
            int ordinal = 0) :
            base(graphics, location, ordinal)
        {
            SetItemImage(Resources.成品包装附件配套工序, location);
        }
    }

    /// <summary>
    /// 虚拟复合工序类型节点类
    /// </summary>
    public class VirtualComposite : OperationNode
    {
        public VirtualComposite(
            Graphics graphics,
            Point location,
            int ordinal = 0) :
            base(graphics, location, ordinal)
        {
            SetItemImage(Resources.虚拟复合工序, location);
        }
    }
}

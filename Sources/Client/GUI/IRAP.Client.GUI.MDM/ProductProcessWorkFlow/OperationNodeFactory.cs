using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

using IRAP.Entity.MDM;

namespace IRAP.Client.GUI.MDM
{
    /// <summary>
    /// 工序节点工厂类
    /// </summary>
    public class OperationNodeFactory
    {
        public static OperationNode CreateInstance(
                    Graphics graphics,
                    Point location,
                    ProcessOperation tag)
        {
            OperationNode instance = null;

            switch (tag.T116Leaf)
            {
                case 12158:
                    instance = new ProductionOfMaterial(graphics, location);
                    break;
                case 12159:
                    instance = new NoMaterialProcessing(graphics, location);
                    break;
                case 12161:
                    instance = new ManualInspection(graphics, location);
                    break;
                case 12165:
                    instance = new MachineTesting(graphics, location);
                    break;
                case 12168:
                    instance = new TroubleShooting(graphics, location);
                    break;
                case 12166:
                    instance = new ProductPackaging(graphics, location);
                    break;
                case 12180:
                    instance = new ProductionOfMaterialAndManualInspection(
                        graphics, location);
                    break;
                case 12182:
                    instance = new NoMaterialProcessingAndManualInspection(
                        graphics, location);
                    break;
                case 12221:
                    instance = new ProductionOfMaterialAndMachineTesting(
                        graphics, location);
                    break;
                case 12222:
                    instance = new ProductPackagingAndAccessory(graphics, location);
                    break;
                case 39490:
                    instance = new VirtualComposite(graphics, location);
                    break;
            }

            if (instance != null)
                instance.Tag = tag;

            return instance;
        }
    }
}
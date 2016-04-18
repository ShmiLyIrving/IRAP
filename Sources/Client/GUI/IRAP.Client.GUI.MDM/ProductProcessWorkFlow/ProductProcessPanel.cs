using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IRAP.Components.WorkFlow;
using IRAP.Entity.MDM;

namespace IRAP.Client.GUI.MDM
{
    class ProductProcessPanel : WorkFlowPanel
    {
        protected override ItemLink CreateWorkFlowLine()
        {
            return new ProcessLine()
            {
                Tag = new ProductProcess()
                {
                    MinPercent = 100,
                    MaxPercent = 100,
                },
            };
        }

        protected override void DrawItem()
        {
            base.DrawItem();
        }

        public void SetNodeLevel()
        {
            foreach (IPaintItem item in Items)
            {
                if (item is OperationNode)
                {
                    (item as OperationNode).Level = 0;
                }
            }

            // 重置各个节点的级别
            if (Root != null && Root is ItemBegin)
            {
                foreach (ItemLink link in (Root as ItemBegin).NextLinks)
                {
                    link.ItemTo = link.ItemTo;
                }
            }
        }
    }
}

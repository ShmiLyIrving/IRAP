using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IRAP.Components.WorkFlow;
using IRAP.Entity.MDM;
using IRAP.Entity.Kanban;

namespace IRAP.Client.GUI.MDM
{
    internal class ProcessLine : ItemLink
    {
        private ProductProcess tag = null;

        public ProductProcess Tag
        {
            get { return tag; }
            set
            {
                tag = value;

                AfterSetItemFrom(ItemFrom);
                AfterSetItemTo(ItemTo);
            }
        }

        protected override void AfterSetItemFrom(CustomItemNode item)
        {
            if (item is ItemNode)
            {
                if (tag != null && item.Tag is LeafSetEx)
                {
                    tag.T216LeafID1 = ((LeafSetEx)item.Tag).LeafID;
                }
            }
        }

        protected override void AfterSetItemTo(CustomItemNode item)
        {
            if (item is ItemNode)
            {
                if (tag != null && item.Tag is LeafSetEx)
                {
                    tag.T216LeafID2 = ((LeafSetEx)item.Tag).LeafID;
                }
            }

            base.AfterSetItemTo(item);
        }

        protected override void CheckValid()
        {
            if (tag != null)
            {
                if (!(itemFrom is ItemBegin) &&
                    ItemTo != null &&
                    tag.T121LeafID == 0)
                    ItemStatus = ItemStatus.Error;
            }
        }
    }
}

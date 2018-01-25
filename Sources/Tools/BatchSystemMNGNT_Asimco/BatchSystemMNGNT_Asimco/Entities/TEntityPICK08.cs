using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows.Forms;

using IRAP.Global;
using IRAPShared;

namespace BatchSystemMNGNT_Asimco.Entities
{
    public class TEntityPICK08 : TEntityCustomLog
    {
        public Quantity QtyLoaded = null;

        public TEntityPICK08() { }

        public TEntityPICK08(TEntityCustomLog source) : this()
        {
            CopyFrom(source);
        }

        protected override void ResolveExchangeXML(string stringXML)
        {
            XmlDocument xml = new XmlDocument();
            try
            {
                xml.LoadXml(stringXML);
                XmlNode node = xml.SelectSingleNode("Parameters/Param");
                if (node != null)
                {
                    if (node.Attributes["ItemNumber"] != null)
                        itemNumber = node.Attributes["ItemNumber"].Value;
                    if (node.Attributes["LotNumber"] != null)
                        lotNumber = node.Attributes["LotNumber"].Value;
                    if (node.Attributes["Bin"] != null)
                        binFrom = node.Attributes["Bin"].Value;
                    if (node.Attributes["IssuedQuantity"] != null)
                        quantity = node.Attributes["IssuedQuantity"].Value;
                    if (node.Attributes["OrderNumber"] != null)
                        orderNo = node.Attributes["OrderNumber"].Value;
                    if (node.Attributes["LineNumber"] != null)
                        orderLineNo = node.Attributes["LineNumber"].Value;
                }

                exchange.Add(IRAPXMLUtils.NodeToObject<TEntityXMLPICK08>(node));
            }
            catch { }
        }

        protected override bool ShowEditorDialogs()
        {
            using (Editors.frmEditorPICK08 form = 
                new Editors.frmEditorPICK08(this))
            {
                return form.ShowDialog() == DialogResult.OK;
            }
        }

        protected override void AfterExecute(TEntityCustomLog log)
        {
            if (QtyLoaded != null)
            {
                try
                {
                    TWaitting.Instance.ShowWaitForm("更新批次系统提料数量");
                    // 更新批次系统中的提料数量
                    List<TTableRSFactPWOMaterialTrack> datas =
                        DAL.TDBHelper.GetMaterialTrack(
                            skuID,
                            orderNo,
                            Tools.ConvertToInt32(orderLineNo));
                    if (datas != null && datas.Count > 0)
                    {
                        datas[0].QtyLoaded = QtyLoaded.IntValue;
                        DAL.TDBHelper.UpdateMaterialTrack(datas[0]);
                    }

                    TWaitting.Instance.CloseWaitForm();
                }
                catch (Exception error)
                {
                    TWaitting.Instance.CloseWaitForm();
                    MSGHelp.Instance.ShowErrorMessage(error);
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using DevExpress.XtraEditors;

using IRAP.OPC.Entity;

namespace OPCClient.Dialogs
{
    public partial class dlgImportDeviceTag : DevExpress.XtraEditors.XtraForm
    {
        private List<TIRAPOPCKepDeviceTagInfo> tags = new List<TIRAPOPCKepDeviceTagInfo>();

        public dlgImportDeviceTag()
        {
            InitializeComponent();
        }

        private string[] SplitCSVLine(string line)
        {
            List<string> a = new List<string>();

            string tmp = "";
            bool record = false;
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] == '\"')
                {
                    record = !record;
                }
                else
                {
                    if (line[i] == ',')
                    {
                        if (record)
                        {
                            tmp += line[i];
                        }
                        else
                        {
                            a.Add(tmp);
                            tmp = "";
                        }
                    }
                    else
                        tmp += line[i];
                }
            }
            if (tmp != "" || a.Count > 0)
                a.Add(tmp);

            return a.ToArray();
        }

        private void edtFileName_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            openFileDialog.Title = "选择设备标签文件";
            openFileDialog.Filter = "设备标签文件(*.CSV)|*.CSV|所有文件(*.*)|*.*";
            if (openFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            else
            {
                edtFileName.Text = openFileDialog.FileName;

                tags.Clear();

                bool isFirst = true;

                using (StreamReader sr = 
                    new StreamReader(
                        openFileDialog.FileName, 
                        Encoding.Default))
                {
                    string srTemp = "";
                    while ((srTemp = sr.ReadLine()) != null)
                    {
                        if (isFirst && chkIncludeTitle.Checked)
                        {
                            isFirst = false;
                            continue;
                        }

                        string[] tagInfo = SplitCSVLine(srTemp);

                        TIRAPOPCKepDeviceTagInfo tag = new TIRAPOPCKepDeviceTagInfo();

                        tag.TagName = tagInfo[0].Replace("\"", "");
                        tag.Address = tagInfo[1].Replace("\"", "");
                        tag.DataType = tagInfo[2].Replace("\"", "");
                        tag.RespectDataType = tagInfo[3].Replace("\"", "");
                        tag.ClientAccess = tagInfo[4].Replace("\"", "");
                        tag.ScanRate = tagInfo[5].Replace("\"", "");
                        tag.Scaling = tagInfo[6].Replace("\"", "");
                        tag.RawLow = tagInfo[7].Replace("\"", "");
                        tag.RawHigh = tagInfo[8].Replace("\"", "");
                        tag.ScaledLow = tagInfo[9].Replace("\"", "");
                        tag.ScaledHigh = tagInfo[10].Replace("\"", "");
                        tag.ScaledDataType = tagInfo[11].Replace("\"", "");
                        tag.ClampLow = tagInfo[12].Replace("\"", "");
                        tag.ClampHigh = tagInfo[13].Replace("\"", "");
                        tag.EngUnits = tagInfo[14].Replace("\"", "");
                        tag.Description = tagInfo[15].Replace("\"", "");
                        tag.NegateValue = tagInfo[16].Replace("\"", "");


                        tags.Add(tag);
                    }
                }

                grdTags.DataSource = tags;
                grdvTags.BestFitColumns();
            }
        }
    }
}
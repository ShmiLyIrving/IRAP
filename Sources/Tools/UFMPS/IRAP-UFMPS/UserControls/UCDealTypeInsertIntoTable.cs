using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;

using IRAP.Global;
using IRAP.UFMPS.Library;

namespace IRAP_UFMPS.UserControls
{
    public partial class UCDealTypeInsertIntoTable : UserControl
    {
        public UCDealTypeInsertIntoTable()
        {
            InitializeComponent();

            ImageComboBoxItem item = null;
            foreach (var value in Enum.GetValues(typeof(TThreadStartMark)))
            {
                item = new ImageComboBoxItem(string.Format("{0} - {1}",
                    (int)value,
                    EnumHelper.GetDescription((TThreadStartMark)value)));
                item.Value = (int)value;
                cboThreadStartMark.Properties.Items.Add(item);
            }
        }
    }
}

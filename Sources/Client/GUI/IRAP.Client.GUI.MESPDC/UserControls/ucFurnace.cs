using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using IRAP.Entities.MES;

namespace IRAP.Client.GUI.MESPDC.UserControls {
    public partial class ucFurnace : XtraUserControl {
        public ucFurnace(ProductionParam param) {
            InitializeComponent();
            this._productionParam = param;
        }

        /// <summary>
        /// 熔炉信息
        /// </summary>
        public ProductionParam ProductionParam {
            get { return _productionParam; }
        }
        private ProductionParam _productionParam;
        
    
    }
}

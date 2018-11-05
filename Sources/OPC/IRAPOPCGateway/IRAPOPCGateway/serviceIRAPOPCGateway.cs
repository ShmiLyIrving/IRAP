using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;

using IRAP.BL.OPCGateway;

namespace IRAPOPCGateway
{
    public partial class serviceIRAPOPCGateway : ServiceBase
    {
        public serviceIRAPOPCGateway()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            TOPCGatewayServiceControl.Instance.Start();
        }

        protected override void OnStop()
        {
            TOPCGatewayServiceControl.Instance.Stop();
        }
    }
}

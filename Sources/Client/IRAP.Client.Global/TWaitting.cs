using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DevExpress.XtraSplashScreen;

namespace IRAP.Client.Global
{
    public class TWaitting
    {
        private static TWaitting _instance = null;

        public static TWaitting Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new TWaitting();
                return _instance;
            }
        }

        private SplashScreenManager ssm = null;

        private TWaitting()
        {
            ssm = new SplashScreenManager(null, typeof(frmWaitting), true, true);
            ssm.Properties.ClosingDelay = 500;
        }

        public void ShowWaitForm(string description, string caption = "")
        {
            if (!ssm.IsSplashFormVisible)
                ssm.ShowWaitForm();

            if (caption == "")
                ssm.SetWaitFormCaption("请稍等......");
            else
                ssm.SetWaitFormCaption(caption);
            ssm.SetWaitFormDescription(description);
        }

        public void CloseWaitForm()
        {
            if (ssm.IsSplashFormVisible)
                ssm.CloseWaitForm();
        }
    }
}

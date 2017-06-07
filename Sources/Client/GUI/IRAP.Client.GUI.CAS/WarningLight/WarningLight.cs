using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Client.GUI.CAS.WarningLight
{
    internal abstract class WarningLight
    {
        public abstract void SetLightStatus(int red, int yellow, int green);
    }
}

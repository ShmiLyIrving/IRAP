using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Client.Global.WarningLight
{
    public abstract class WarningLight
    {
        public abstract void SetLightStatus(int red, int yellow, int green);
        public abstract void SetLeghtStatus(string ipAddress, int red, int yellow, int green);
    }
}

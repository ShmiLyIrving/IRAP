using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace IRAP.Client.GUI.CAS.CH375
{
    public class CH375Control
    {
        [DllImport("CH375Controller.dll", 
            CharSet = CharSet.Ansi, 
            CallingConvention = CallingConvention.StdCall)]
        public static extern void SetLightStatus(int red, int yellow, int green);
    }
}
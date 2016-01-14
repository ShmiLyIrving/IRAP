using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;

namespace IRAP.Global
{
    public class COMPrint
    {
        /// <summary>
        /// 串口打印
        /// </summary>
        public bool COMWrite(string portName, int baudRate, Parity parity, int dataBits, StopBits stopBits, string myString)
        {
            try
            {
                SerialPort comPort = new SerialPort(portName, baudRate, parity, dataBits, stopBits);
                if (comPort.IsOpen)
                {
                    comPort.Close();
                }
                comPort.Open();
                comPort.WriteLine(myString);
                comPort.Close();
                return true;
            }
            catch 
            {
                return false;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRAP_MaterialRequestImport
{
    public class TParams
    {
        private static TParams _instance = null;

        public static TParams Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new TParams();
                return _instance;
            }
        }

        private TParams() { }

        public string DBConnectionStr
        {
            get
            {
                return
                    "Server=192.168.97.208;initial catalog=IRAP;UID=sa;" +
                    "Password=CIMS040312;Min Pool Size=2;Max Pool Size=60;";
            }
        }
    }
}

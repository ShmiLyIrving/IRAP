using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace IRAP.DynamicLoad
{
    public class IRAPDevFramework
    {
        private static Dictionary<string, string> _assemblyList;
        private static AssemblyLoader _loader = null;

        public IRAPDevFramework()
        {
            if (_loader == null)
                _assemblyList = new Dictionary<string, string>();
        }

        private static AssemblyLoader Loader
        {
            get
            {
                if (_loader == null)
                    _loader = new AssemblyLoader();
                return _loader;
            }
        }

        public static void LoadEntity()
        {
            string entityPath = string.Format(@"{0}Entities",
                AppDomain.CurrentDomain.BaseDirectory);
            if (!Directory.Exists(entityPath))
                Directory.CreateDirectory(entityPath);
        }
    }
}

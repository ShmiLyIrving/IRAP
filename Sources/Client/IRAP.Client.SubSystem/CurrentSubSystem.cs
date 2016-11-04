using System.Reflection;

using IRAP.Entity.SSO;

namespace IRAP.Client.SubSystem
{
    public class CurrentSubSystem
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private static CurrentSubSystem _instance = null;
        private SystemInfo currentSubSystem = new SystemInfo();
        private bool isSystemSelected = false;

        private CurrentSubSystem()
        {
        }

        public static CurrentSubSystem Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new CurrentSubSystem();
                return _instance;
            }
        }

        public SystemInfo SysInfo
        {
            get { return currentSubSystem; }
        }

        public bool IsSystemSelected
        {
            get { return isSystemSelected; }
        }

        public void SetSystemInfo(SystemInfo subSysInfo)
        {
            if (subSysInfo == null)
                isSystemSelected = false;
            else
            {
                currentSubSystem = subSysInfo.Clone();
                isSystemSelected = true;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRAP_MaterialRequestImport
{
    public abstract class TBaseUser
    {
        protected bool isLogon = false;
        protected string password = "";
        protected string userCode = "";

        ~TBaseUser()
        {
            if (isLogon)
                Logout();
        }

        public bool IsLogon
        {
            get { return isLogon; }
        }

        public abstract bool ChangePassword(
            string oldPWD,
            string newPWD,
            string renewPWD);
        public abstract void Login();
        public abstract void Logout();
    }
}

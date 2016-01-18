using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Client.User
{
    public abstract class BaseUser
    {
        protected bool isLogon=false;
        protected string password="";
        protected string userCode="";

        ~BaseUser()
        {
            if (isLogon)
                Logout();
        }

        public bool IsLogon
        {
            get { return isLogon; }
        }

        public abstract bool ChangePassword(string oldPWD, string newPWD, string renewPWD);

        public abstract void Login();

        public abstract void Logout();
    }
}
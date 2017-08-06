using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entities.IRAP
{
    public class STB006
    {
        public long PartitioningKey { get; set; }
        public string UserCode { get; set; }
        public string UserName { get; set; }
        public byte[] EncryptedPWD { get; set; }
        public string AgencyNodeList { get; set; }
        public string RoleNodeList { get; set; }
        public int LanguageID { get; set; }
        public int TimeZone { get; set; }
        public int Status { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public int Gender { get; set; }
        public string PID { get; set; }
        public DateTime BirthDate { get; set; }
        public string OPhoneNo { get; set; }
        public string HPhoneNo { get; set; }
        public string MPhoneNo { get; set; }
        public string PagerNo { get; set; }
        public string MailBoxNo { get; set; }
        public string EmailAddr { get; set; }
        public string InstantMessageID { get; set; }
        public string WeChatID { get; set; }
        public string WearableDeviceID { get; set; }
        public byte[] SmallHeadPic { get; set; }
        public DateTime RegistedTime { get; set; }
        public DateTime ModifiedTime { get; set; }
        public int VerifyType { get; set; }
        public string VerifyCode { get; set; }
        public DateTime VerifyInvalidTime { get; set; }
        public int VerifySuccess { get; set; }
        public string CardNo { get; set; }
        public bool BeingAtWork { get; set; }
        public int EventRespondingPriority { get; set; }
        public long LinkedToEventID { get; set; }
        public string OtherSystemUserCode { get; set; }
        public string OtherSystemUserPWD { get; set; }

        public STB006 Clone()
        {
            return MemberwiseClone() as STB006;
        }
    }
}

using System;

using IRAPShared;

namespace IRAP.Entities.IRAP
{
    [IRAPDB(TableName = "IRAP..stb009")]
    public class STB009
    {
        [IRAPKey]
        public long PartitioningKey { get; set; }
        [IRAPKey]
        public long SysLogID { get; set; }
        public string UserCode { set; get; }
        public int AgencyLeaf { get; set; }
        public int RoleLeaf { get; set; }
        public string StationID { get; set; }
        public string IPAddress { get; set; }
        public int LanguageID { get; set; }
        public DateTime LoginTime { get; set; }
        public DateTime LogoutTime { get; set; }
        public string DBName { get; set; }
        public int DBProcessID { get; set; }
        public string UserDiary { get; set; }
        public byte Status { get; set; }

        public STB009 Clone()
        {
            return MemberwiseClone() as STB009;
        }
    }
}

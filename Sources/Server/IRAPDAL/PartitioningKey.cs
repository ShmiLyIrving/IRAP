using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAPDAL
{
    public class PartitioningKey
    {
        private static PartitioningKey _instance = null;

        private PartitioningKey() { }

        public static PartitioningKey Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new PartitioningKey();
                return _instance;
            }
        }

        public long GetTreePartitioningKey(int comunityID, int treeID)
        {
            return comunityID * 10000L + treeID;
        }

        public long GetFactPartitionPolicy(int communityID, int yearID, int opID)
        {
            //行集事实分区策略与主事实一致
            // 2015000600100482
            string s =
                yearID.ToString() +
                communityID.ToString().PadLeft(8, '0') +
                opID.ToString().PadLeft(4, '0');
            return long.Parse(s);
        }

        public long GetTranPartitionPolicy(int communityID, int yearID)
        {
            //交易表年度（4）+社区（8位）201500060013
            string p = yearID.ToString() + communityID.ToString().PadLeft(8, '0');
            return long.Parse(p);
        }

        public long GetAuxPartitionPolicy(int communityID, int yearID, int t132LeafID)
        {
            // comuminutyid+132LeafID(8位)+yearid(4位）60010022376822015
            string p = communityID.ToString() + t132LeafID.ToString().PadLeft(8, '0') + yearID.ToString();
            return long.Parse(p);
        }

        public long GetWIPPartitioningKey(int communityID, int t103LeafID)
        {
            //6001002237680 6001302243417
            string p = communityID.ToString() + t103LeafID.ToString().PadLeft(8, '0');
            return long.Parse(p);
        }
    }
}

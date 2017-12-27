using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.WebAPI.Entities.MES
{
    public class TRESPOPCServerTagList
    {
        public int T133LeafID { get; set; }
        public string T133Code { get; set; }
        public string T133Name { get; set; }
        public string ServerAddr { get; set; }
        public string ServerName { get; set; }
        public string TagList { get; set; }
    }

    public class TRESPOPCServerTagListSet
    {
        private List<TRESPOPCServerTagList> items =
            new List<TRESPOPCServerTagList>();

        public List<TRESPOPCServerTagList> Rows
        {
            get { return items; }
            set { items = value; }
        }

        public string ExCode { get; set; }
    }
}

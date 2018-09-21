using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data.SqlClient;

namespace IRAP.DBUtility
{
    public class TCommandInfo
    {
        public object ShareObject = null;
        public object OriginalData = null;
        public string CommandText = "";
        public DbParameter[] Parameters;
        public TEffentNextType EffentNextType = TEffentNextType.None;

        event EventHandler _solicitationEvent;

        public event EventHandler SolicitationEvent
        {
            add { _solicitationEvent += value; }
            remove { _solicitationEvent -= value; }
        }

        public TCommandInfo(string stringSQL, SqlParameter[] param) : 
            this()
        {
            CommandText = stringSQL;
            Parameters = param;
        }

        public TCommandInfo()
        {

        }

        public TCommandInfo(string stringSQL, SqlParameter[] param, TEffentNextType type) : 
            this(stringSQL, param)
        {
            EffentNextType = type;
        }

        public void OnSolicitationEvent()
        {
            if (_solicitationEvent != null)
                _solicitationEvent(this, new EventArgs());
        }
    }
}
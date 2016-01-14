using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace IRAPShared
{
    [Serializable]
   public class IRAPProcParameter : IDataParameter
    {
        public DbType  DbType {get;set;}

        public ParameterDirection Direction { get; set; }

        public bool IsNullable { get; set; }
        public string ParameterName { get; set; }

        public string SourceColumn { get; set; }
        public DataRowVersion SourceVersion { get; set; }

        public Object Value { get; set; }

        public int Size { get; set; }

        public IRAPProcParameter(string paramName,DbType paramType,   ParameterDirection direction,int size)
        {
            ParameterName = paramName;
           
            Direction = direction;
            DbType = paramType;
            SourceColumn = null;
            SourceVersion = DataRowVersion.Current;
            Size = size; 
        }
        public IRAPProcParameter()
        {
            SourceColumn = null;
            SourceVersion = DataRowVersion.Current;

        }

        public IRAPProcParameter(string paramName,DbType paramType, Object objValue)
        {
            ParameterName = paramName;
            Value = objValue;
            Direction =  ParameterDirection.Input;
            DbType = paramType;
            SourceColumn = null;
            SourceVersion = DataRowVersion.Current;
        }

    }
}

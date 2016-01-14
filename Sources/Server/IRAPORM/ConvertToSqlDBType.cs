using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Sql;

namespace IRAPORM
{
    public class Convert2DBType
    {
        public static SqlDbType ToSqlType(string typeName)
        {
            SqlDbType dbType = SqlDbType.Variant;//默认为Object

            switch (typeName.ToLower())
            {
                case "int":
                    dbType = SqlDbType.Int;
                    break;
                case "int32":
                    dbType = SqlDbType.Int;
                    break;
                case "uint32":
                    dbType = SqlDbType.Int;
                    break;
                case "uint16":
                    dbType = SqlDbType.Int;
                    break;
                case "string":
                    dbType = SqlDbType.VarChar;
                    break;
                case "bool":
                    dbType = SqlDbType.Bit;
                    break;
                case "boolean":
                    dbType = SqlDbType.Bit;
                    break;
                case "datetime":
                    dbType = SqlDbType.DateTime;
                    break;
                case "decimal":
                    dbType = SqlDbType.Decimal;
                    break;
                case "double":
                    dbType = SqlDbType.Float;
                    break;
                case "bytes":
                    dbType = SqlDbType.Image;
                    break;
                case "int64":
                    dbType = SqlDbType.BigInt;
                    break;
                case "byte":
                    dbType = SqlDbType.TinyInt;
                    break;
                case "ushort":
                    dbType = SqlDbType.SmallInt;
                    break;
                case "byte[]":
                    dbType = SqlDbType.Image;
                    break;
                case "single":
                    dbType = SqlDbType.Float;
                    break;
                default:
                    dbType= SqlDbType.Variant;
                    break;
            }
            return dbType;
        }
    }
}

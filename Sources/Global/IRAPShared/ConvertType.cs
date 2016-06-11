using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace IRAPShared
{
    public class ConvertSqlType
    {
        public static SqlDbType ToSqlType(DbType dbType)
        {
            SqlDbType sqlDbType = SqlDbType.Variant;//默认为Object

            switch (dbType)
            {
                case DbType.Int16:
                    sqlDbType = SqlDbType.SmallInt;
                    break;
                case DbType.Int32:

                    sqlDbType = SqlDbType.Int;
                    break;
                case DbType.Int64:
                    sqlDbType = SqlDbType.BigInt;
                    break;
                case DbType.Object:
                    sqlDbType = SqlDbType.Structured;
                    break;
                case DbType.SByte:
                    sqlDbType = SqlDbType.TinyInt;
                    break;
                case DbType.Single:
                    sqlDbType = SqlDbType.Real;
                    break;
                case DbType.String:
                    sqlDbType = SqlDbType.NVarChar;
                    break;
                case DbType.StringFixedLength:
                    sqlDbType = SqlDbType.NChar;
                    break;
                case DbType.Time:
                    sqlDbType = SqlDbType.Time;
                    break;
                case DbType.UInt16:
                    sqlDbType = SqlDbType.Int;
                    break;
                case DbType.UInt32:
                    sqlDbType = SqlDbType.BigInt;
                    break;
                case DbType.UInt64:
                    sqlDbType = SqlDbType.BigInt;
                    break;
                case DbType.VarNumeric:
                    sqlDbType = SqlDbType.Decimal;
                    break;
                case DbType.Xml:
                    sqlDbType = SqlDbType.Xml;
                    break;
                case DbType.AnsiString:
                    sqlDbType = SqlDbType.VarChar;
                    break;
                case DbType.AnsiStringFixedLength:
                    sqlDbType = SqlDbType.Char;
                    break;
                case DbType.Binary:
                    sqlDbType = SqlDbType.Image;
                    break;
                case DbType.Boolean:
                    sqlDbType = SqlDbType.Bit;
                    break;
                case DbType.Byte:
                    sqlDbType = SqlDbType.TinyInt;
                    break;
                case DbType.Currency:
                    sqlDbType = SqlDbType.Money;
                    break;
                case DbType.Date:
                    sqlDbType = SqlDbType.Date;
                    break;
                case DbType.DateTime:
                    sqlDbType = SqlDbType.DateTime;
                    break;
                case DbType.DateTime2:
                    sqlDbType = SqlDbType.DateTime2;
                    break;
                case DbType.DateTimeOffset:
                    sqlDbType = SqlDbType.DateTimeOffset;
                    break;
                case DbType.Decimal:
                    sqlDbType = SqlDbType.Decimal;
                    break;
                case DbType.Double:
                    sqlDbType = SqlDbType.Float;
                    break;
                case DbType.Guid:
                    sqlDbType = SqlDbType.UniqueIdentifier;
                    break;
                default:
                    sqlDbType = SqlDbType.Udt;
                    break;
            }
            return sqlDbType;
        }
    }

    public class ConvertOracleType
    {
        public static OracleDbType ToOracleType(DbType dbType)
        {
            OracleDbType oraDBType = OracleDbType.Object;//默认为Object

            switch (dbType)
            {
                case DbType.Int16:
                    oraDBType = OracleDbType.Int16;
                    break;
                case DbType.Int32:
                    oraDBType = OracleDbType.Int32;
                    break;
                case DbType.Int64:
                    oraDBType = OracleDbType.Int64;
                    break;
                case DbType.Object:
                    oraDBType = OracleDbType.Object;
                    break;
                case DbType.SByte:
                    oraDBType = OracleDbType.Int16;
                    break;
                case DbType.Single:
                    oraDBType = OracleDbType.Single;
                    break;
                case DbType.String:
                    oraDBType = OracleDbType.Varchar2;
                    break;
                case DbType.StringFixedLength:
                    oraDBType = OracleDbType.NChar;
                    break;
                case DbType.Time:
                    oraDBType = OracleDbType.TimeStamp;
                    break;
                case DbType.UInt16:
                    oraDBType = OracleDbType.Int16;
                    break;
                case DbType.UInt32:
                    oraDBType = OracleDbType.Int32;
                    break;
                case DbType.UInt64:
                    oraDBType = OracleDbType.Int64;
                    break;
                case DbType.VarNumeric:
                    oraDBType = OracleDbType.Decimal;
                    break;
                case DbType.Xml:
                    oraDBType = OracleDbType.XmlType;
                    break;
                case DbType.AnsiString:
                    oraDBType = OracleDbType.Varchar2;
                    break;
                case DbType.AnsiStringFixedLength:
                    oraDBType = OracleDbType.Char;
                    break;
                case DbType.Binary:
                    oraDBType = OracleDbType.Blob;
                    break;
                case DbType.Boolean:
                    oraDBType = OracleDbType.Int16;
                    break;
                case DbType.Byte:
                    oraDBType = OracleDbType.Byte;
                    break;
                case DbType.Currency:
                    oraDBType = OracleDbType.Double;
                    break;
                case DbType.Date:
                    oraDBType = OracleDbType.Date;
                    break;
                case DbType.DateTime:
                    oraDBType = OracleDbType.TimeStamp;
                    break;
                case DbType.DateTime2:
                    oraDBType = OracleDbType.TimeStamp;
                    break;
                case DbType.DateTimeOffset:
                    oraDBType = OracleDbType.TimeStamp;
                    break;
                case DbType.Decimal:
                    oraDBType = OracleDbType.Decimal;
                    break;
                case DbType.Double:
                    oraDBType = OracleDbType.Double;
                    break;
                case DbType.Guid:
                    oraDBType = OracleDbType.Varchar2;
                    break;
                default:
                    oraDBType = OracleDbType.Object;
                    break;
            }
            return oraDBType;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace IRAPShared
{
   public  class ConvertSqlType
    {
        public static SqlDbType ToSqlType(DbType dbType)
            {
                SqlDbType sqlDbType = SqlDbType.Variant;//默认为Object
               
                switch (dbType)
                {
                    case  DbType.Int16:
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
                    case  DbType.StringFixedLength:
                        sqlDbType = SqlDbType.NChar;
                        break;
                    case  DbType.Time:
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
  
}

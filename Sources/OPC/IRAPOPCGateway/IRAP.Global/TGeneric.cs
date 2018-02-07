using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace IRAP.Global
{
    public class TGeneric
    {
        public static T Mapper<T, V>(V source)
        {
            T dest = Activator.CreateInstance<T>();

            try
            {
                Type typeSource = source.GetType();
                Type typeDest = typeof(T);

                foreach (PropertyInfo sp in typeSource.GetProperties())
                {
                    foreach (PropertyInfo dp in typeDest.GetProperties())
                    {
                        if (sp.Name == dp.Name)
                            dp.SetValue(
                                dest,
                                sp.GetValue(source, null),
                                null);
                    }
                }
            }
            catch (Exception error)
            {
                error.Data["ErrCode"] = -1;
                error.Data["ErrText"] = error.Message;
                throw error;
            }

            return dest;
        }
    }
}

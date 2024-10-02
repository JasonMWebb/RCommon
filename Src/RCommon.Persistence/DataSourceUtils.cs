using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCommon.Persistence
{
    public static class DataSourceUtils
    {
        public static string FormatDataSourceName(string name, Type type)
        {
            string dataSourceName = type.GetGenericTypeName() + "-" + name;
            return dataSourceName;
        }
    }
}

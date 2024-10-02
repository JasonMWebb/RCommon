using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCommon.Persistence
{
    public class DataStoreFactoryOptions
    {
        public IDictionary<string, Type> Types { get; } = new Dictionary<string, Type>();

        public void Register<T>(string name) where T : IDataStore
        {
            string dataSourceName = DataSourceUtils.FormatDataSourceName(name, typeof(T));

            try
            {
                Types.Add(dataSourceName, typeof(T));
            }
            catch (Exception)
            {
                throw new DataStoreException($"Cannot add duplicate datastore name of: {name} for type: {dataSourceName} with a key of: {dataSourceName}");
            }
        }
    }
}

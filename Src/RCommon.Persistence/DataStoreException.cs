using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCommon.Persistence
{
    public class DataStoreException : GeneralException
    {
        public DataStoreException(string message) : base(message)
        {

        }
    }
}

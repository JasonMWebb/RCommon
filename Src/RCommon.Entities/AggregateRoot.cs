using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCommon.Entities
{
    public class AggregateRoot : BusinessEntity
    {
        private readonly IAggregateRootAdapter _aggregateRootAdapter;

        public AggregateRoot(IAggregateRootAdapter aggregateRootAdapter)
        {
            _aggregateRootAdapter = aggregateRootAdapter;
        }

        public override object[] GetKeys()
        {
            throw new NotImplementedException();
        }
    }
}

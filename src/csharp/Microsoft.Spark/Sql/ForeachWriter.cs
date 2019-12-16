using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Spark.Sql
{
    public abstract class ForeachWriter
    {
        public abstract bool Open(long partitionId, long epochId);

        public abstract void Process(DataFrame value);

        public abstract void Close(Exception errorOrNull);
    }
}

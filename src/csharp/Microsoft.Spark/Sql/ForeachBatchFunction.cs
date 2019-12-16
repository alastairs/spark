using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Spark.Sql
{
    internal class ForeachBatchFunction
    {
        readonly SparkContext _sparkContext;
        readonly Action<DataFrame, long> _function;

        public ForeachBatchFunction(SparkContext sparkContext, Action<DataFrame, long> function)
        {
            _sparkContext = sparkContext;
            _function = function;
        }

        void Call(DataFrame df, long batchId)
        {
            try
            {
                _function(df, batchId);
            }
            catch (Exception)
            {

            }
        }
    }
}

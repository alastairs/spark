using System;
using Microsoft.Spark.Sql.Streaming;

namespace Microsoft.Spark.Sql.Execution.Streaming.Sources
{
    class ForeachBatchSink
    {
        Action<DataFrame, long> _batchWriter;
        ExpressionEnco
    }

    abstract class PythonForeachBatchFunction
    {
        public abstract void Call(DataFrame batchDF, long batchId);
    }

    static class ForeachBatchHelper
    {
        void CallForeachBatch(DataStreamWriter dsw, PythonForeachBatchFunction pythonFunc)
        {
            dsw.ForeachBatch(pythonFunc.Call())
        }
    }
}

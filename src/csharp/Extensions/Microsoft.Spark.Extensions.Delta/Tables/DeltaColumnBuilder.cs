using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Spark.Interop;
using Microsoft.Spark.Interop.Ipc;
using Microsoft.Spark.Sql.Types;

namespace Microsoft.Spark.Extensions.Delta.Tables
{
    [DeltaLakeSince(DeltaLakeVersions.V1_0_0)]
    public class DeltaColumnBuilder
    {
        internal DeltaColumnBuilder(JvmObjectReference jvmObject)
        {
            Reference = jvmObject;
        }

        public JvmObjectReference Reference { get; private set; }

        public DeltaColumnBuilder DataType(string dataType) =>
            new DeltaColumnBuilder((JvmObjectReference)Reference.Invoke("dataType", dataType));

        public DeltaColumnBuilder DataType(DataType dataType) =>
            new DeltaColumnBuilder((JvmObjectReference)Reference.Invoke("dataType", dataType));

        public DeltaColumnBuilder Nullable(bool nullable) =>
            new DeltaColumnBuilder((JvmObjectReference)Reference.Invoke("nullable", nullable));

        public DeltaColumnBuilder GeneratedAlwaysAs(string expr) =>
            new DeltaColumnBuilder((JvmObjectReference)Reference.Invoke("generatedAlwaysAs", expr));

        public DeltaColumnBuilder Comment(string comment) =>
            new DeltaColumnBuilder((JvmObjectReference)Reference.Invoke("comment", comment));

        public StructField Build() => (StructField)Reference.Invoke("build");
    }
}

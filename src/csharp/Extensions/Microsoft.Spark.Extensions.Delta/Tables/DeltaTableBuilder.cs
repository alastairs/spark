using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Spark.Interop.Ipc;
using Microsoft.Spark.Sql.Types;

namespace Microsoft.Spark.Extensions.Delta.Tables
{
    /// <summary>
    ///   Builder to specify how to create / replace a Delta table.
    ///   You must specify the table name or the path before executing the builder.
    ///   You can specify the table columns, the partitioning columns,
    ///   the location of the data, the table comment and the property,
    ///   and how you want to create / replace the Delta table.
    /// 
    ///   After executing the builder, a <see cref="DeltaTable"/> object is returned.
    /// 
    ///  Use :py:meth:`delta.tables.DeltaTable.create`,
    ///  :py:meth:`delta.tables.DeltaTable.createIfNotExists`,
    ///  :py:meth:`delta.tables.DeltaTable.replace`,
    ///  :py:meth:`delta.tables.DeltaTable.createOrReplace` to create an object of this class.
    /// 
    ///  Example 1 to create a Delta table with separate columns, using the table name::
    /// 
    ///  var deltaTable = DeltaTable.Create(sparkSession)
    ///         .TableName("testTable")
    ///         .AddColumn("c1", dataType = "INT", nullable = False)
    ///         .AddColumn("c2", dataType = IntegerType(), generatedAlwaysAs = "c1 + 1")
    ///         .PartitionedBy("c1")
    ///         .Execute();
    /// 
    ///     Example 2 to replace a Delta table with existing columns, using the location::
    /// 
    ///     var df = spark.createDataFrame([('a', 1), ('b', 2), ('c', 3)], ["key", "value"]);
    /// 
    ///     var deltaTable = DeltaTable.Replace(sparkSession)
    ///         .TableName("testTable")
    ///         .AddColumns(df.Schema)
    ///         .Execute();
    /// </summary>
    [DeltaLakeSince(DeltaLakeVersions.V1_0_0)]
    public class DeltaTableBuilder
    {
        internal DeltaTableBuilder(JvmObjectReference jvmObject)
        {
            Reference = jvmObject;
        }

        public JvmObjectReference Reference { get; private set; }

        DeltaTableBuilder TableName(string identifier) =>
            new DeltaTableBuilder((JvmObjectReference)Reference.Invoke("tableName", identifier));


        DeltaTableBuilder Comment(string comment) =>
            new DeltaTableBuilder((JvmObjectReference)Reference.Invoke("comment", comment));


        DeltaTableBuilder Location(string location) =>
            new DeltaTableBuilder((JvmObjectReference)Reference.Invoke("location", location));

        DeltaTableBuilder AddColumn(string colName, string dataType) =>
            new DeltaTableBuilder((JvmObjectReference)Reference.Invoke("addColumn", colName, dataType));

        DeltaTableBuilder AddColumn(string colName, DataType dataType) =>
            new DeltaTableBuilder((JvmObjectReference)Reference.Invoke("addColumn", colName, dataType));

        DeltaTableBuilder AddColumn(string colName, string dataType, bool nullable) =>
            new DeltaTableBuilder((JvmObjectReference)Reference.Invoke("addColumn", colName, dataType, nullable));

        DeltaTableBuilder AddColumn(string colName, DataType dataType, bool nullable) =>
            new DeltaTableBuilder((JvmObjectReference)Reference.Invoke("addColumn", colName, dataType, nullable));

        DeltaTableBuilder AddColumn(StructField col) =>
            new DeltaTableBuilder((JvmObjectReference)Reference.Invoke("addColumn", col));

        DeltaTableBuilder AddColumns(StructType cols) =>
            new DeltaTableBuilder((JvmObjectReference)Reference.Invoke("addColumn", cols));

        DeltaTableBuilder PartitionedBy(params string[] colNames) =>
            new DeltaTableBuilder((JvmObjectReference)Reference.Invoke("partitionedBy", colNames));

        DeltaTableBuilder Property(string key, string value) =>
            new DeltaTableBuilder((JvmObjectReference)Reference.Invoke("property", key, value));

        DeltaTable Execute() => new DeltaTable((JvmObjectReference)Reference.Invoke("execute"));
    }
}

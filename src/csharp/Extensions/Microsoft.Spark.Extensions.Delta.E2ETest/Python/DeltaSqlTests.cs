// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Spark.E2ETest.Utils;
using Microsoft.Spark.Extensions.Delta.Tables;
using Microsoft.Spark.Sql;
using Microsoft.Spark.Sql.Streaming;
using Microsoft.Spark.Sql.Types;
using Xunit;

namespace Microsoft.Spark.Extensions.Delta.E2ETest.Python
{
    [Collection(Constants.DeltaTestContainerName)]
    public class DeltaSqlTests
    {
        private readonly SparkSession _spark;
        private string _tempFile;

        public DeltaSqlTests(DeltaFixture fixture)
        {
            _spark = fixture.SparkFixture.Spark;
        }

        public void SetUp()
        {
            _tempFile = Path.GetTempFileName();
        }

        public void TearDown()
        {

        }

        public void Test_ForPath()
        {

        }
    }
}

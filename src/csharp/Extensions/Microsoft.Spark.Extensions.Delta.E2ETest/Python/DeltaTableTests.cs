using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Spark.Sql;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using Xunit;

namespace Microsoft.Spark.Extensions.Delta.E2ETest.Python
{
    public class DeltaTableTests
    {
        private readonly SparkSession _spark;
        private string _tempFile;

        public DeltaTableTests(DeltaFixture fixture)
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

        public void Test_Alias_and_ToDF()
        {

        }

        public void Test_Delete()
        {

        }

        public void Test_Generate()
        {

        }

        public void Test_Update()
        {

        }

        public void Test_Merge()
        {

        }

        public void Test_History()
        {

        }

        public void Test_Vacuum()
        {

        }

        public void Test_ConvertToDelta()
        {

        }

        public void Test_IsDeltaTable()
        {

        }

        private void CheckAnswer(DataFrame df, DataFrame expectedDf)
        {
            if (expectedDf == null || expectedDf.IsEmpty())
            {
                Assert.Equal(0L, df.Count());
                return;
            }
            Assert.Equal(expectedDf.Count(), df.Count());
            Assert.Equal(expectedDf.Columns().Count, df.Columns().Count);
            Assert.Equal(df.);
        }

        private void WriteDeltaTable()
        {

        }

        private void OverwriteDeltaTable()
        {

        }

        private void CreateFile()
        {

        }

        private void CheckFileExists()
        {

        }
    }
}

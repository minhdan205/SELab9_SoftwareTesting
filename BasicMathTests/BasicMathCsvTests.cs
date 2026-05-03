using Microsoft.VisualStudio.TestTools.UnitTesting;
using BasicMath;
using CsvHelper;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace BasicMathTests
{
    [TestClass]
    public class BasicMathCsvTests
    {
        public static IEnumerable<object[]> GetTestData(string fileName)
        {
            using var reader = new StreamReader(fileName);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

            foreach (var record in csv.GetRecords<TestData>())
            {
                yield return new object[] { record.A, record.B, record.Expected };
            }
        }

        [DataTestMethod]
        [DynamicData(nameof(GetAddData), DynamicDataSourceType.Method)]
        public void Add_CsvData_ReturnsCorrectSum(int a, int b, double expected)
        {
            BasicMaths bm = new BasicMaths();

            double actual = bm.Add(a, b);

            Assert.AreEqual(expected, actual);
        }

        public static IEnumerable<object[]> GetAddData()
        {
            return GetTestData("add_testdata.csv");
        }

        [DataTestMethod]
        [DynamicData(nameof(GetSubtractData), DynamicDataSourceType.Method)]
        public void Subtract_CsvData_ReturnsCorrectDifference(int a, int b, double expected)
        {
            BasicMaths bm = new BasicMaths();

            double actual = bm.Subtract(a, b);

            Assert.AreEqual(expected, actual);
        }

        public static IEnumerable<object[]> GetSubtractData()
        {
            return GetTestData("subtract_testdata.csv");
        }

        [DataTestMethod]
        [DynamicData(nameof(GetMultiplyData), DynamicDataSourceType.Method)]
        public void Multiply_CsvData_ReturnsCorrectProduct(int a, int b, double expected)
        {
            BasicMaths bm = new BasicMaths();

            double actual = bm.Multiply(a, b);

            Assert.AreEqual(expected, actual);
        }

        public static IEnumerable<object[]> GetMultiplyData()
        {
            return GetTestData("multiply_testdata.csv");
        }

        [DataTestMethod]
        [DynamicData(nameof(GetDivideData), DynamicDataSourceType.Method)]
        public void Divide_CsvData_ReturnsCorrectQuotient(int a, int b, double expected)
        {
            BasicMaths bm = new BasicMaths();

            double actual = bm.Divide(a, b);

            Assert.AreEqual(expected, actual);
        }

        public static IEnumerable<object[]> GetDivideData()
        {
            return GetTestData("divide_testdata.csv");
        }

        public class TestData
        {
            public int A { get; set; }
            public int B { get; set; }
            public double Expected { get; set; }
        }
    }
}
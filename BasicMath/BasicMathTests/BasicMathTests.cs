using Microsoft.VisualStudio.TestTools.UnitTesting;
using BasicMath;
using System;

namespace BasicMathTests
{
    [TestClass]
    public class BasicMathsTests
    {
        [DataTestMethod]
        [DataRow(1, 1, 2)]
        [DataRow(-1, -1, -2)]
        [DataRow(0, 0, 0)]
        [DataRow(2147483647, 1, 2147483648d)]
        [DataRow(-2147483648, -1, -2147483649d)]
        public void Test_AddMV(int a, int b, double expected)
        {
            BasicMaths bm = new BasicMaths();

            double actual = bm.Add(a, b);

            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow(5, 3, 2)]
        [DataRow(-5, -3, -2)]
        [DataRow(0, 0, 0)]
        [DataRow(2147483647, 1, 2147483646d)]
        [DataRow(-2147483648, -1, -2147483647d)]
        public void Test_SubtractMV(int a, int b, double expected)
        {
            BasicMaths bm = new BasicMaths();

            double actual = bm.Subtract(a, b);

            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow(2, 3, 6)]
        [DataRow(-2, -3, 6)]
        [DataRow(-2, 3, -6)]
        [DataRow(0, 5, 0)]
        [DataRow(2147483647, 1, 2147483647d)]
        public void Test_MultiplyMV(int a, int b, double expected)
        {
            BasicMaths bm = new BasicMaths();

            double actual = bm.Multiply(a, b);

            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow(6, 3, 2)]
        [DataRow(-6, -3, 2)]
        [DataRow(-6, 3, -2)]
        [DataRow(0, 1, 0)]
        [DataRow(2147483647, 1, 2147483647d)]
        public void Test_DivideMV(int a, int b, double expected)
        {
            BasicMaths bm = new BasicMaths();

            double actual = bm.Divide(a, b);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_DivideByZero()
        {
            BasicMaths bm = new BasicMaths();

            try
            {
                bm.Divide(10, 0);
                Assert.Fail("Expected DivideByZeroException was not thrown.");
            }
            catch (DivideByZeroException)
            {
                // Test passed
            }
        }
    }
}
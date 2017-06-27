using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReactCalc;

namespace TestCalc
{
    [TestClass]
    public class CalcTest
    {
        [TestMethod]
        public void TestSum()
        {
            var calc = new Calc();
            double[] xy = {1, 2};
            var x = calc.Execute("Sum", xy);

            Assert.AreEqual(x, 3);
        }

        [TestMethod]
        public void TestDiv()
        {
            var calc = new Calc();
            double[] xy = { 2, 2 };
            var x = calc.Execute("Div", xy);

            Assert.AreEqual(x, 1);
        }

        [TestMethod]
        public void TestDiff()
        {
            var calc = new Calc();
            double[] xy = { 1, 2 };
            var x = calc.Execute("Diff", xy);

            Assert.AreEqual(x, -1);
        }

        [TestMethod]
        public void TestSquareRoot()
        {
            var calc = new Calc();
            double[] xy = { 4, 2 };
            var x = calc.Execute("Sqrt", xy);

            Assert.AreEqual(x, 2);
        }

        [TestMethod]
        public void TestPow()
        {
            var calc = new Calc();
            double[] xy = { 2, 2 };
            var x = calc.Execute("Pow", xy);

            Assert.AreEqual(x, 4);
        }
    }
}

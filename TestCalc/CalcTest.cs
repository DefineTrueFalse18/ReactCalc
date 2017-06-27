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
            var x = calc.Sum(1, 2);

            Assert.AreEqual(x, 3);
            Assert.AreEqual(calc.Sum(0, 0), 0);
            Assert.AreEqual(calc.Sum(-1, 2), 1);
            Assert.AreEqual(calc.Sum(3, 3), 6);
        }

        [TestMethod]
        public void TestDiv()
        {
            var calc = new Calc();
            var x = calc.Div(2, 2);
            var y = calc.Div(2, 0);

            Assert.AreEqual(x, 1);
        }

        [TestMethod]
        public void TestDiff()
        {
            var calc = new Calc();
            var x = calc.Diff(1, 2);

            Assert.AreEqual(x, -1);
        }

        [TestMethod]
        public void TestSquareRoot()
        {
            var calc = new Calc();
            var x = calc.SquareRoot(4);

            Assert.AreEqual(x, 2);
        }

        [TestMethod]
        public void TestPow()
        {
            var calc = new Calc();
            var x = calc.Pow(2,2);
            var y = calc.Pow(2, 0);

            Assert.AreEqual(x, 4);
            Assert.AreEqual(y, 1);
        }
    }
}

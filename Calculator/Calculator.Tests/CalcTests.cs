using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Calculator.Tests
{
    [TestClass]
    public class CalcTests
    {
        [TestMethod]
        public void Calc_Sum_2_and_3_results_5()
        {
            //Arrange
            Calc calc = new Calc();

            //Act
            int result = calc.Sum(2, 3);

            //Assert
            Assert.AreEqual(5, result);
        }

        [TestMethod]
        [DataRow(0, 0, 0)]
        [DataRow(2, 3, 5)]
        [DataRow(-2, 3, 1)]
        [DataRow(-2, -3, -5)]
        public void Calc_Sum(int a, int b, int exp)
        {
            //Arrange
            Calc calc = new Calc();

            //Act
            int result = calc.Sum(a, b);

            //Assert
            Assert.AreEqual(exp, result);
        }

        [TestMethod]
        public void Calc_Sum_MAX_and_1_throws_OverflowException()
        {
            Calc calc = new Calc();

            Assert.ThrowsException<OverflowException>(() => calc.Sum(int.MaxValue, 1));

        }

    }
}
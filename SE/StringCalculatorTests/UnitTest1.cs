using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using StringCalculatorApp;

namespace StringCalculatorTestsNamespace
{
    [TestClass]
    public class StringCalculatorTests
    {
        [TestMethod]
        public void EmptyString_ReturnsZero()
        {

            StringCalculator calculator = new StringCalculator();
            int result = calculator.Calculate("");
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void SingleNumber_ReturnsValue()
        {
            StringCalculator calculator = new StringCalculator();
            int result = calculator.Calculate("5");
            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void TwoCommaSeparatedNumbers_ReturnSum()
        {
            StringCalculator calculator = new StringCalculator();
            int result = calculator.Calculate("5,3");
            Assert.AreEqual(8, result);
        }

        [TestMethod]
        public void NewLineDelimiter_Works()
        {
            StringCalculator calculator = new StringCalculator();
            int result = calculator.Calculate("5\n3");
            Assert.AreEqual(8, result);
        }

        [TestMethod]
        public void MixedDelimiters_Work()
        {
            StringCalculator calculator = new StringCalculator();
            int result = calculator.Calculate("1,2\n3");
            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void IgnoreNumbersGreaterThan1000()
        {
            StringCalculator calculator = new StringCalculator();
            int result = calculator.Calculate("2,1001");
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void SingleCustomDelimiter_Works()
        {
            StringCalculator calculator = new StringCalculator();
            int result = calculator.Calculate("//#\n2#3");
            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void MultiCharacterDelimiter_Works()
        {
            StringCalculator calculator = new StringCalculator();
            int result = calculator.Calculate("//[###]\n2###3###4");
            Assert.AreEqual(9, result);
        }

        [TestMethod]
        public void MultipleDelimiters_Work()
        {
            StringCalculator calculator = new StringCalculator();
            int result = calculator.Calculate("//[*][%]\n1*2%3");
            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void NegativeNumbers_ThrowException()
        {
            StringCalculator calculator = new StringCalculator();

            Assert.ThrowsException<ArgumentException>(
                () => calculator.Calculate("1,-2,3")
            );
        }
    }
}
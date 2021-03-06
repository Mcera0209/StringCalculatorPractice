﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculatorKata
{
    [TestFixture]
    public class StringCalculatorTests
    {
        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        public void Add_GivenInvalidString_ShouldReturnZero(string numbers)
        {
            //----------------Arrange------------------------
            var stringCalculator = CreateStringCalculator();

            //----------------Act----------------------------
            var actual = stringCalculator.Add(numbers);

            //----------------Assert-------------------------
            var expected = 0;
            Assert.AreEqual(expected, actual);
        }

        [TestCase("12",12)]
        [TestCase("19",19)]
        [TestCase("188",188)]
        public void Add_GivenSingleNumberAsString_ShouldReturnThatNumberAsInteger(string numbers,int expected)
        {
            //----------------Arrange------------------------
            var stringCalculator = CreateStringCalculator();

            //----------------Act----------------------------
            var actual = stringCalculator.Add(numbers);

            //----------------Assert-------------------------
            Assert.AreEqual(expected, actual);
        }

        [TestCase("1,2", 3)]
        [TestCase("14,95,100", 209)]
        [TestCase("90,30,1002,90", 210)]
        public void Add_GivenNumbersAsStringSeparatedByComma_ShouldReturnSumOfThoseNumbersAsInteger(string numbers, int expected)
        {
            //----------------Arrange------------------------
            var stringCalculator = new StringCalculator();

            //----------------Act----------------------------
            var actual = stringCalculator.Add(numbers);

            //----------------Assert-------------------------
            Assert.AreEqual(expected, actual);
        }

        [TestCase("1\n2,3", 6)]
        [TestCase("12\n76,1001\n100", 188)]
        [TestCase("100\n20,50\n30,50", 250)]
        public void Add_GivenNumbersAsStringSeparatedByCommaAndNewline_ShouldReturnSumOfThoseNumbersAsInteger(string numbers, int expected)
        {
            //----------------Arrange------------------------
            var stringCalculator = CreateStringCalculator();

            //----------------Act----------------------------
            var actual = stringCalculator.Add(numbers);

            //----------------Assert-------------------------
            Assert.AreEqual(expected, actual);
        }

        [TestCase("//;\n1;2", 3)]
        [TestCase("//$\n10$1888$100$100", 210)]
        [TestCase("//*\n800*20*50*30*50", 950)]
        public void Add_GivenNumbersAsStringSeparatedBySpecifiedDelimiter_ShouldReturnSumOfThoseNumbersAsInteger(string numbers, int expected)
        {
            //----------------Arrange------------------------
            var stringCalculator = CreateStringCalculator();

            //----------------Act----------------------------
            var actual = stringCalculator.Add(numbers);

            //----------------Assert-------------------------
            Assert.AreEqual(expected, actual);
        }

        [TestCase("-100", "Negatives not allowed -100")]
        [TestCase("-89,100,-56", "Negatives not allowed -89 -56")]
        [TestCase("//%\n-8%9%-52,75", "Negatives not allowed -8 -52")]
        public void Add_GivenStringOfNumbersContainingNegativeNumber_ShouldThrowExceptionAllNegativeNumbersThatWerePassed(string numbers, string expected)
        {
            //-------------------Arrange--------------------
            var stringCalculator = CreateStringCalculator();

            //-------------------Act------------------------
            var actual = Assert.Throws<Exception>(() => stringCalculator.Add(numbers));

            //-------------------Assert---------------------
            Assert.AreEqual(expected, actual.Message);
        }

        [TestCase("//;\n2;1001", 2)]
        [TestCase("80\n78,1010\n10", 168)]
        [TestCase("960,54,8888,85,50", 1149)]
        public void Add_GivenNumbersAsStringHavingNumberGreaterThan1000SeparatedByDelimiter_ShouldReturnSumOfTheNumbersNotGreaterThan1000(string numbers, int expected)
        {
            //----------------Arrange------------------------
            var stringCalculator = CreateStringCalculator();

            //----------------Act----------------------------
            var actual = stringCalculator.Add(numbers);

            //----------------Assert-------------------------
            Assert.AreEqual(expected, actual);
        }

        private static StringCalculator CreateStringCalculator()
        {
            return new StringCalculator();
        }
    }
}

using NUnit.Framework;
using Rekrutacja.Helper;
using System;

namespace Rekrutacja.Tests.Tests
{
    [TestFixture]
    public class ParseHelperTests
    {
        [Test]
        public void MyIntParse_ValidPositiveNumber_ReturnsCorrectValue()
        {
            int result = ParseHelper.MyIntParse("12345");
            Assert.AreEqual(12345, result);
        }

        [Test]
        public void MyIntParse_ValidNegativeNumber_ReturnsCorrectValue()
        {
            int result = ParseHelper.MyIntParse("-12345");
            Assert.AreEqual(-12345, result);
        }

        [Test]
        public void MyIntParse_InputIsZero_ReturnsZero()
        {
            int result = ParseHelper.MyIntParse("0");
            Assert.AreEqual(0, result);
        }

        [Test]
        public void MyIntParse_InputIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => ParseHelper.MyIntParse(null));
        }

        [Test]
        public void MyIntParse_InputIsEmpty_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => ParseHelper.MyIntParse(""));
        }

        [Test]
        public void MyIntParse_InputContainsNonDigitCharacters_ThrowsFormatException()
        {
            Assert.Throws<FormatException>(() => ParseHelper.MyIntParse("123a45"));
        }

        [Test]
        public void MyIntParse_InputIsOnlyMinusSign_ThrowsFormatException()
        {
            Assert.Throws<FormatException>(() => ParseHelper.MyIntParse("-"));
        }

        [Test]
        public void MyIntParse_InputContainsLeadingZeros_ReturnsCorrectValue()
        {
            int result = ParseHelper.MyIntParse("000123");
            Assert.AreEqual(123, result);
        }
    }
}

using NUnit.Framework;
using Rekrutacja.Helper;
using System;

namespace Rekrutacja.Tests.Tests
{
    [TestFixture]
    public class ParseHelperIntegrationTests
    {
        [Test]
        public void MyIntParse_MultipleValidInputs_ReturnsCorrectValues()
        {
            int result1 = ParseHelper.MyIntParse("123");
            int result2 = ParseHelper.MyIntParse("-456");
            int result3 = ParseHelper.MyIntParse("7890");

            Assert.AreEqual(123, result1);
            Assert.AreEqual(-456, result2);
            Assert.AreEqual(7890, result3);
        }

        [Test]
        public void MyIntParse_InvalidInputSequence_ThrowsExceptions()
        {
            Assert.Throws<FormatException>(() => ParseHelper.MyIntParse("12a3"));
            Assert.Throws<ArgumentNullException>(() => ParseHelper.MyIntParse(null));
        }
    }
}

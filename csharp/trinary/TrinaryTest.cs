using NUnit.Framework;
using Exercism.Trinary;

[TestFixture]
public class TrinaryTest
{
    // change Ignore to false to run test case or just remove 'Ignore = true'
    [TestCase("1", Result = 1)]
    [TestCase("2", Result = 2)]
    [TestCase("10", Result = 3)]
    [TestCase("11", Result = 4)]
    [TestCase("100", Result = 9)]
    [TestCase("112", Result = 14)]
    [TestCase("222", Result = 26)]
    [TestCase("1122000120", Result = 32091)]
    public int Trinary_converts_to_decimal(string value)
    {
        return Trinary.ToDecimal(value);
    }

    [TestCase("carrot")]
    [TestCase("3")]
    [TestCase("6")]
    [TestCase("9")]
    [TestCase("124578")]
    [TestCase("abc1z")]
    public void Invalid_trinary_is_decimal_0(string invalidValue)
    {
        Assert.That(Trinary.ToDecimal(invalidValue), Is.EqualTo(0));
    }

    [Test]
    public void Trinary_can_convert_formatted_strings()
    {
        Assert.That(Trinary.ToDecimal("011"), Is.EqualTo(4));
    }
}
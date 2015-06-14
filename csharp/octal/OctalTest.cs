using NUnit.Framework;
using Exercism.Octal;

[TestFixture]
public class OctalTest
{
    // change Ignore to false to run test case or just remove 'Ignore = true'
    [TestCase("1", Result = 1)]
    [TestCase("10", Result = 8, Ignore = false)]
    [TestCase("17", Result = 15, Ignore = false)]
    [TestCase("11", Result = 9, Ignore = false)]
    [TestCase("130", Result = 88, Ignore = false)]
    [TestCase("2047", Result = 1063, Ignore = false)]
    [TestCase("7777", Result = 4095, Ignore = false)]
    [TestCase("1234567", Result = 342391, Ignore = false)]
    public int Octal_converts_to_decimal(string value)
    {
        return Octal.ToDecimal(value);
    }

    [TestCase("carrot", Ignore = false)]
    [TestCase("8", Ignore = false)]
    [TestCase("9", Ignore = false)]
    [TestCase("6789", Ignore = false)]
    [TestCase("abc1z", Ignore = false)]
    public void Invalid_octal_is_decimal_0(string invalidValue)
    {
        Assert.That(Octal.ToDecimal(invalidValue), Is.EqualTo(0));
    }

    [Test]
    public void Octal_can_convert_formatted_strings()
    {
        Assert.That(Octal.ToDecimal("011"), Is.EqualTo(9));
    }
}
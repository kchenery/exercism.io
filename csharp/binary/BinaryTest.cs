using NUnit.Framework;
using Exercism.Binary;

[TestFixture]
public class BinaryTest
{
    // change Ignore to false to run test case or just remove 'Ignore = false'
    [TestCase("1", Result = 1)]
    [TestCase("10", Result = 2, Ignore = false)]
    [TestCase("11", Result = 3, Ignore = false)]
    [TestCase("100", Result = 4, Ignore = false)]
    [TestCase("1001", Result = 9, Ignore = false)]
    [TestCase("11010", Result = 26, Ignore = false)]
    [TestCase("10001101000", Result = 1128, Ignore = false)]
    public int Binary_converts_to_decimal(string binary)
    {
        return Binary.ToDecimal(binary);
    }
    
    [TestCase("carrot", Ignore = false)]
    [TestCase("2", Ignore = false)]
    [TestCase("5", Ignore = false)]
    [TestCase("9", Ignore = false)]
    [TestCase("134678", Ignore = false)]
    [TestCase("abc10z", Ignore = false)]
    public void Invalid_binary_is_decimal_0(string invalidValue)
    {
        Assert.That(Binary.ToDecimal(invalidValue), Is.EqualTo(0));
    }

    [Test]
    public void Binary_can_convert_formatted_strings()
    {
        Assert.That(Binary.ToDecimal("011"), Is.EqualTo(3));
    }
}
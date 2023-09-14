using System;
using System.Collections.Generic;
using NUnit.Framework;

public class MathUtils
{
    public static double CalculateAverage(List<double> numbers)
    {
        if (numbers == null || numbers.Count == 0)
        {
            throw new ArgumentException("La liste ne peut pas être vide ou nulle.");
        }

        double sum = 0;
        foreach (double num in numbers)
        {
            sum += num;
        }

        return sum / numbers.Count;
    }
}

[TestFixture]
public class MathUtilsTests
{
    [Test]
    public void CalculateAverage_WithValidList_ReturnsCorrectAverage()
    {
        List<double> numbers = new List<double> { 1.0, 2.0, 3.0, 4.0, 5.0 };
        double expectedAverage = 3.0;

        double actualAverage = MathUtils.CalculateAverage(numbers);

        Assert.AreEqual(expectedAverage, actualAverage, 0.001); // Utilise une tolérance pour les comparaisons de nombres à virgule flottante
    }

    [Test]
    public void CalculateAverage_WithEmptyList_ThrowsArgumentException()
    {
        List<double> emptyList = new List<double>();

        Assert.Throws<ArgumentException>(() => MathUtils.CalculateAverage(emptyList));
    }

    [Test]
    public void CalculateAverage_WithNullList_ThrowsArgumentException()
    {
        List<double> nullList = null;

        Assert.Throws<ArgumentException>(() => MathUtils.CalculateAverage(nullList));
    }
}

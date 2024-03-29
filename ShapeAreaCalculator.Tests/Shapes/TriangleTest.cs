using ShapeAreaCalculator.Shapes;

namespace ShapeAreaCalculator.Tests.Shapes;

public class TriangleTest
{
    [Test]
    [TestCase(-1, 1, 1)]
    [TestCase(1, -1, 1)]
    [TestCase(1, 1, -1)]
    [TestCase(double.MinValue, 1, 1)]
    [TestCase(double.NegativeInfinity, 1, 1)]
    public void Ctor_EdgesLessOrEqualZero_ThrowsArgumentException(double a, double b, double c)
    {
        Assert.Throws<ArgumentException>(() => _ = new Triangle(a, b, c));
    }

    [Test]
    [TestCase(5, 10, 1)]
    [TestCase(1, 2, 3)]
    [TestCase(double.PositiveInfinity, double.PositiveInfinity, 1)]
    public void Ctor_InvalidTriangle_ThrowsException(double a, double b, double c)
    {
        Assert.Throws<Exception>(() => _ = new Triangle(a, b, c));
    }

    [Test]
    [TestCase(1, 1, 1)]
    [TestCase(3, 2, 3)]
    [TestCase(double.MaxValue / 3, double.MaxValue / 3, double.MaxValue / 3)]
    public void Ctor_ValidTriangle_DoesNotThrow(double a, double b, double c)
    {
        Assert.DoesNotThrow(() => _ = new Triangle(a, b, c));
    }

    [Test]
    public void CalculateArea_ValidEdges_Correct()
    {
        var triangle = new Triangle(5, 5, 5);
        Assert.That(Math.Round(triangle.CalculateArea(), 2), Is.EqualTo(10.83));
        
        triangle = new Triangle(100_000, 100_000, 1);
        Assert.That(Math.Round(triangle.CalculateArea()), Is.EqualTo(50000));
        
        triangle = new Triangle(10, 24, 26);
        Assert.That(triangle.CalculateArea(), Is.EqualTo(120));
    }

    [Test]
    public void IsRight_SquareAngle_IsTrue()
    {
        var triangle = new Triangle(10, 24, 26);
        Assert.That(triangle.IsRight);
    }

    [Test]
    public void IsRight_NotSquareAngle_IsFalse()
    {
        var triangle = new Triangle(1, 1, 1);
        Assert.That(!triangle.IsRight());
        
        triangle = new Triangle(double.MaxValue / 3, double.MaxValue / 3, double.MaxValue / 3);
        Assert.That(!triangle.IsRight());
    }
}
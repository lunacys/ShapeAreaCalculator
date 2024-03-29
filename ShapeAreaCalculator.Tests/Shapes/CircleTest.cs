using ShapeAreaCalculator.Shapes;

namespace ShapeAreaCalculator.Tests.Shapes;

public class CircleTest
{
    [Test]
    [TestCase(0.0)]
    [TestCase(-10.0)]
    [TestCase(double.NegativeInfinity)]
    [TestCase(double.MinValue)]
    [TestCase(double.NegativeZero)]
    public void Ctor_InvalidRadius_Throws(double radius)
    {
        Assert.Throws<ArgumentException>(() => _ = new Circle(radius));
    }

    [Test]
    [TestCase(0.001)]
    [TestCase(1)]
    [TestCase(150_000.123_456)]
    [TestCase(double.Epsilon)]
    [TestCase(double.MaxValue)]
    [TestCase(double.PositiveInfinity)]
    public void Ctor_ValidRadius_DoesNotThrow(double radius)
    {
        Assert.DoesNotThrow(() => _ = new Circle(radius));
    }

    [Test]
    public void CalculateArea_ValidRadii_Correct()
    {
        var circle = new Circle(1.0);
        Assert.That(circle.CalculateArea(), Is.EqualTo(Math.PI));

        circle = new Circle(10.0);
        Assert.That(circle.CalculateArea(), Is.EqualTo(100 * Math.PI));

        circle = new Circle(50.0);
        Assert.That(Math.Round(circle.CalculateArea(), 5), Is.EqualTo(7853.98163));
    }
}
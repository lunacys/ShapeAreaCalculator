namespace ShapeAreaCalculator.Shapes;

/// <summary>
/// Represents a shape, where an area can be calculated.
/// </summary>
public interface IShape
{
    /// <summary>
    /// Calculates the area of the shape.
    /// </summary>
    /// <returns>Area of the shape.</returns>
    double CalculateArea();
}
namespace ShapeAreaCalculator.Shapes;

/// <summary>
/// Represents a circle using a radius.
/// </summary>
public class Circle : IShape
{
    /// <summary>
    /// Gets or sets radius of the circle.
    /// </summary>
    public double Radius { get; }
    
    /// <summary>
    /// Constructs a circle with specified radius.
    /// </summary>
    /// <param name="radius">Radius of the circle. Must be greater than zero.</param>
    public Circle(double radius)
    {
        if (radius <= 0)
            throw new ArgumentException("Radius must be greater than zero.", nameof(radius));
        
        Radius = radius;
    }

    /// <summary>
    /// Calculates radius of the circle using formula S=pi*r^2.
    /// </summary>
    /// <returns>Radius of the circle</returns>
    public double CalculateArea()
        => Math.PI * (Radius * Radius);
}
namespace ShapeAreaCalculator.Shapes;

/// <summary>
/// Represents a triangle using 3 edges.
/// </summary>
public class Triangle : IShape
{
    /// <summary>
    /// Gets or sets the first edge.
    /// </summary>
    public double Edge1 { get; }
    /// <summary>
    /// Gets or sets the second edge.
    /// </summary>
    public double Edge2 { get; }
    /// <summary>
    /// Gets or sets the third edge.
    /// </summary>
    public double Edge3 { get; }
    
    /// <summary>
    /// Constructs a triangle with specified 3 edge lengths.
    /// </summary>
    /// <param name="edge1">Edge 1 (a). Must be greater than zero.</param>
    /// <param name="edge2">Edge 2 (b). Must be greater than zero.</param>
    /// <param name="edge3">Edge 3 (c). Must be greater than zero.</param>
    public Triangle(double edge1, double edge2, double edge3)
    {
        if (edge1 <= 0)
            throw new ArgumentException("Edge1 must be greater than zero", nameof(edge1));
        if (edge2 <= 0)
            throw new ArgumentException("Edge2 must be greater than zero", nameof(edge2));
        if (edge3 <= 0)
            throw new ArgumentException("Edge3 must be greater than zero", nameof(edge3));

        if (!IsValid(edge1, edge2, edge3))
            throw new Exception("The triangle is invalid");
        
        Edge1 = edge1;
        Edge2 = edge2;
        Edge3 = edge3;
    }

    /// <summary>
    /// Calculates area of the triangle by 3 edges.
    /// </summary>
    /// <returns>Calculated area.</returns>
    public double CalculateArea()
    {
        // The formula:
        //  sqrt(p*(p-a)(p-b)(p-c))
        // Where p - half perimeter and a,b,c - edges of the triangle.
        var halfPerimeter = HalfPerimeter();
        return Math.Sqrt(halfPerimeter * (halfPerimeter - Edge1) * (halfPerimeter - Edge2) * (halfPerimeter - Edge3));
    }

    /// <summary>
    /// Checks whether the triangle is right (one angle equals 90 degrees) using Pythagorean theorem.
    /// </summary>
    /// <returns>Whether the triangle is right.</returns>
    public bool IsRight()
        => Math.Abs((Edge1 * Edge1) + (Edge2 * Edge2) - (Edge3 * Edge3)) < double.Epsilon;

    /// <summary>
    /// Checks if a triangle is valid with 3 given edges.
    /// </summary>
    /// <param name="edge1">First Edge.</param>
    /// <param name="edge2">Second Edge.</param>
    /// <param name="edge3">Third Edge.</param>
    /// <returns>Whether a triangle is valid.</returns>
    public static bool IsValid(double edge1, double edge2, double edge3)
        => edge1 + edge2 > edge3 && edge1 + edge3 > edge2 && edge2 + edge3 > edge1;
    
    
    /// <summary>
    /// Calculates half the perimeter of the triangle.
    /// </summary>
    /// <returns>Half the perimeter.</returns>
    private double HalfPerimeter() 
        => (Edge1 + Edge2 + Edge3) / 2.0; 
}
public class Circle : Shape
{
    private double _radius;

    public Circle(string color, double radius):base(color)
    {
        SetColor(color);
        _radius = radius;
    }
    public void SetRadius(double radius)
    {
        _radius = radius;
    }
    public double GetRadius()
    {
        return _radius;
    }

    public override double GetArea()
    {
        return _radius*_radius*Math.PI;
    }
}
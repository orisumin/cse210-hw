using System;

class Program
{
    static void Main(string[] args)
    {
        Rectangle rec = new Rectangle("blue",1,2);
        Square sqr = new Square("yellow",1);
        Circle crl = new Circle("red",1);

        List<Shape> list = new List<Shape>{rec, sqr, crl};
        foreach(Shape shape in list)
        {
            Console.WriteLine(shape.GetArea());
        }
    }
}
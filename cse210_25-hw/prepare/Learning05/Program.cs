using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create a list of shapes
        List<Shape> shapes = new List<Shape>();

        // Add different shapes to the list
        Square square = new Square("Red", 4);
        shapes.Add(square);

        Rectangle rectangle = new Rectangle("Yellow", 5, 3);
        shapes.Add(rectangle);

        Circle circle = new Circle("Green", 6);
        shapes.Add(circle);

        // Iterate through the list and display color and area
        foreach (Shape shape in shapes)
        {
            string color = shape.GetColor();
            double area = shape.GetArea();
            
            Console.WriteLine($"The {color} shape has an area of {area:F2}");
        }
    }
}
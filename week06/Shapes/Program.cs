using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Test individual shapes
        Square square = new Square("Red", 5);
        Console.WriteLine($"Square color: {square.GetColor()}, area: {square.GetArea()}");

        Rectangle rectangle = new Rectangle("Blue", 4, 6);
        Console.WriteLine($"Rectangle color: {rectangle.GetColor()}, area: {rectangle.GetArea()}");

        Circle circle = new Circle("Green", 3);
        Console.WriteLine($"Circle color: {circle.GetColor()}, area: {circle.GetArea()}");

        // Polymorphism in action: List<Shape>
        List<Shape> shapes = new List<Shape>();
        shapes.Add(square);
        shapes.Add(rectangle);
        shapes.Add(circle);

        Console.WriteLine("\nList of shapes:");
        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"Shape color: {shape.GetColor()}, area: {shape.GetArea()}");
        }
    }
}
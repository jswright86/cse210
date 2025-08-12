using System;
using System.Dynamic;
using System.Globalization;
using Shapes;

class Program
{
    static void Main(string[] args)
    {
//update files

        
        Square square1 = new Square();
        Rectangle rectangle1 = new Rectangle();
        Circle circle1 = new Circle();
        square1.SetColor("Blue");
        square1.SetSide(2);
        rectangle1.SetColor("Green");
        rectangle1.SetWidth(3);
        rectangle1.SetLength(4);
        circle1.SetColor("Yellow");
        circle1.SetRadius(3);
        
        List<Shape> shapes = new List<Shape> {square1, rectangle1, circle1};

        foreach (Shape shape in shapes)
        {

            Console.WriteLine($"The {shape.GetColor()} shape has an area of {shape.GetArea()}.");
        }
        
       
       
       
       
    }   
}
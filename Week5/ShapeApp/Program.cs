using System;
using ClassAspectExamples;

namespace ShapeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Setup our instances of Shape
            Shape shape1 = new Shape("Bob");
            Shape shape2 = new Shape("Sally", ShapeColors.Orange, new Coordinates { X = 1, Y = 2, Z = 3 });
            Shape shape3 = new Shape("Frank", ShapeColors.Green, new Coordinates { X = 3, Y = 3, Z = 3 });
            // Display the Shape states
            Console.WriteLine("Instances after definition...");
            OutputShapeValues(shape1, shape2, shape3);
            shape1.MyCoordinates.X = 10;
            shape1.MyCoordinates.Y = 10;
            shape1.MyCoordinates.Z = 10;
            shape2.MyColor = ShapeColors.Purple;
            Console.WriteLine("\nInstances after changing values...");
            OutputShapeValues(shape1, shape2, shape3);
            shape1.CenterOfMyWorld.X = 13;
            shape1.CenterOfMyWorld.Y = 13;
            shape1.CenterOfMyWorld.Z = 13;
            Console.WriteLine("\nInstances after changing shape1.CenterOfMyWOrld...");
            OutputShapeValues(shape1, shape2, shape3);
        }

        private static void OutputShapeValues(Shape shape1, Shape shape2, Shape shape3)
        {
            Console.WriteLine(shape1.BuildOutput());
            Console.WriteLine($"{shape1.ShapeName} has a Center Of World: {shape1.CenterOfMyWorld.BuildOutput()}");
            Console.WriteLine(shape2.BuildOutput());
            Console.WriteLine($"{shape2.ShapeName} has a Center Of World: {shape2.CenterOfMyWorld.BuildOutput()}");
            Console.WriteLine(shape3.BuildOutput());
            Console.WriteLine($"{shape3.ShapeName} has a Center Of World: {shape3.CenterOfMyWorld.BuildOutput()}");
        }
    }
}

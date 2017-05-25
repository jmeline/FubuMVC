using System;
using System.Collections.Generic;
using System.Linq;
using Shouldly;
using Xunit;

namespace CSharp_Language.Solid_Principles.Open_Closed_Principle
{
    public class CalculatingAreaGoodExample
    {
        public abstract class Shape
        {
            public abstract double Area();
        }


        public class Triangle : Shape
        {
            public double Base { get; set; }
            public double Height { get; set; }
            public override double Area()
            {
                return 0.5 * Base * Height;
            }
        }

        public class Rectangle : Shape
        {
            public double Width { get; set; }
            public double Height { get; set; }
            public override double Area()
            {
                return Width * Height;
            }
        }
        public class Circle : Shape
        {
            public double Radius { get; set; }
            public override double Area()
            {
                return Radius * Radius * Math.PI;
            }
        }

        public class CalculateArea
        {
            // open for extension, closed for modification. 
            // This can be achieved by relying on abstractions
            public double Areas(List<Shape> shapes)
            {
               return shapes.Sum(x => x.Area()); 
            }
        }

        [Fact]
        public void TestingCalculateAreaUsingGoodExampleOfOCP()
        {
            var calculator = new CalculateArea();
            const double expected = 394.57963267949d;
            var result = calculator.Areas(new List<Shape>
            {
                new Rectangle {Height = 10, Width = 10},
                new Circle {Radius = 5},
                new Triangle {Base = 5, Height = 15},
                new Circle {Radius = 5},
                new Rectangle {Height = 10, Width = 10}
            });
            CheckResult(result, expected).ShouldBeTrue();
        }

        private bool CheckResult(double result, double expected)
        {
            var tolerance = Math.Abs(result * .0001);
            return Math.Abs(result - expected) <= tolerance;
        }

    }
}

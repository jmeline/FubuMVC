using System;
using System.Collections.Generic;
using System.Linq;
using Shouldly;
using Xunit;

namespace CSharp_Language.Solid_Principles.Open_Closed_Principle
{
    public class Rectangle
    {
        public double Width { get; set; }
        public double Height { get; set; }
    }

    public class Circle
    {
        public double Radius { get; set; }
    }

    public class AreaCalculator
    {
        public double Area(List<Rectangle> shapes)
        {
            return shapes.Sum(x => x.Width * x.Height);
        }

        public double Areas(List<object> shapes)
        {
            // unfortunately this isn't closed for modification
            double area = 0;
            foreach (var shape in shapes)
            {
                if (shape is Rectangle)
                {
                    var r = (Rectangle) shape;
                    area += r.Width * r.Height;
                }
                else
                {
                    var c = (Circle) shape;
                    area += c.Radius * c.Radius * Math.PI;
                }
            }
            return area;
        }
    }


    public class CalculatingAreaBadExample
    {
        [Fact]
        public void TestingAreasMethod()
        {
            
            var calculator = new AreaCalculator();
            var result = calculator.Areas(new List<object>
            {
                new Rectangle {Height = 10, Width = 5},
                new Circle {Radius = 5},
                new Rectangle {Height = 10, Width = 5},
                new Circle {Radius = 5},
                new Rectangle {Height = 10, Width = 5},
                new Circle {Radius = 5},
                new Rectangle {Height = 10, Width = 5},
                new Circle {Radius = 5},
                new Rectangle {Height = 10, Width = 5},
                new Circle {Radius = 5}
            });
            const double expected = 642.699081698724d;
            CheckResult(result, expected).ShouldBeTrue();
        }

        private bool CheckResult(double result, double expected)
        {
            var tolerance = Math.Abs(result * .0001);
            return Math.Abs(result - expected) <= tolerance;
        }

        [Fact]
        public void TestingAreaCalculator()
        {
            var calculator = new AreaCalculator();
            const double expectedResult = 4986.024d;
            var result = calculator.Area(new List<Rectangle>
            {
                new Rectangle { Width = 10,   Height = 15 },
                new Rectangle { Width = 15.3, Height = 35.12 },
                new Rectangle { Width = 15.3, Height = 35.12 },
                new Rectangle { Width = 15.3, Height = 35.12 },
                new Rectangle { Width = 15.3, Height = 35.12 },
                new Rectangle { Width = 15.3, Height = 35.12 },
                new Rectangle { Width = 15.3, Height = 35.12 },
                new Rectangle { Width = 15.3, Height = 35.12 },
                new Rectangle { Width = 15.3, Height = 35.12 },
                new Rectangle { Width = 15.3, Height = 35.12 },
            });
            CheckResult(result, expectedResult).ShouldBeTrue();
        }
    }
}

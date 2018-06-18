using System;
using Shouldly;
using Xunit;

namespace CSharp_Language.Fundamentals
{
    public enum COLORS
    {
        Black,
        Green,
        Red,
        Yellow,
        White
    }
    
    public class Enums
    {
        [Fact]
        public void TestEnum()
        {
            // Enum inherits from ValueType
            typeof(COLORS).BaseType.ShouldBe(typeof(Enum));
            typeof(Enum).BaseType.ShouldBe(typeof(ValueType));
        }
    }
}
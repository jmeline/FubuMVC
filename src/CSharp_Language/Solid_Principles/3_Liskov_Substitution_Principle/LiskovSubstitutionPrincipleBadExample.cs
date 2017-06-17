using System;
using System.Collections.Generic;
using Shouldly;
using Xunit;

namespace CSharp_Language.Solid_Principles._3_Liskov_Substitution_Principle
{
    public class LiskovSubstitutionPrincipleBadExample
    {
        // derived classes should be perfectly substituatable for their base classes.

        public class Apple
        {
            public virtual string GetColor() => "Red";
        }
         
        public class Orange : Apple
        {
            public override string GetColor() => "Orange";
        }

        [Fact]
        public void BadExample()
        {
            Apple apple = new Orange();
            apple.GetColor().ShouldBe("Red");
        }
    }
}

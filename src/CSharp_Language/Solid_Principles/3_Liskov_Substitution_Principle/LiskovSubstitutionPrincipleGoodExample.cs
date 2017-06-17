using System;
using System.Collections.Generic;
using Shouldly;
using Xunit;

namespace CSharp_Language.Solid_Principles._3_Liskov_Substitution_Principle
{
    public class LiskovSubstitutionPrincipleGoodExample
    {
        public abstract class Fruit
        {
            public abstract string GetColor();
        }

        public class Apple : Fruit
        {
            public override string GetColor() => "Red";
        }

        public class Orange : Fruit
        {
            public override string GetColor() => "Orange";
        }

        [Fact]
        public void GoodExample()
        {
            Fruit apple = new Apple();
            apple.GetColor().ShouldBe("Red");
            Fruit orange = new Orange();
            orange.GetColor().ShouldBe("Orange");
        }
    }

}

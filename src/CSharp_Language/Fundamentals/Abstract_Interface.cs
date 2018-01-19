using System;
using Shouldly;
using Xunit;

namespace CSharp_Language.Fundamentals
{
    public class AbstractInterface
    {
        public interface IDemo
        {
            // interfaces elements must be public
            //  any classes that implement the interface must 
            //  implement all the properties, methods.
            // cannot contain fields, static, class, interfaces, abstract
            // can contain properties
            int Value { get; set; }
        }

        private interface IPi
        {
            double GetPi();
        }

        // You cannot instantiate an abstract class directly
        public abstract class Demo3 : Demo2
        {
            protected Demo3()
            {
                _value = 150;
            } 
        }

        public abstract class Demo2 : IDemo
        {
            // fields cannot be abstract
            protected int _value;
            public abstract int Value { get; set; }
        }

        public class Test : Demo2, IPi
        {
            // if something is abstract, it must be implemented
            // classes can extend one abstract class but it can use as many interfaces as it wishes
            public override int Value
            {
                get { return _value; }
                set { _value = value * 2; }
            }

            public double GetPi()
            {
                return Math.PI;
            }
        }

        public class Test2 : Demo3
        {
            public override int Value
            {
                get { return _value; }
                set { _value = value; }
            }
        }

        [Fact]
        public void TestDemo2()
        {
            var test = new Test {Value = 100};
            test.Value.ShouldBe(200);
            test.GetPi().ShouldBe(Math.PI);
        }

        [Fact]
        public void TestDemo3()
        {
            var test = new Test2();
            test.Value.ShouldBe(150);
        }
    }
}

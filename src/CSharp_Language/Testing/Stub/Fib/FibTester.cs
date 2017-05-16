using System;
using Shouldly;
using Xunit;

namespace CSharp_Language.Testing.Stub
{
    public class FibTester
    {
        public class FibStub : IFib
        {
            // stub is a controllable replacement for an existing dependency in the system. 
            // By using a stub, you can test your code without dealing with the dependency directly.
            public decimal GetFib(int value)
            {
                decimal newValue;
                if (value == 100)
                {
                    decimal.TryParse("354224848179261915075", out newValue);
                    return newValue;
                }
                return 0;
            }
        }

        [Fact]
        public void FibReturnsFib100()
        {
            var fib = new FibStub();
            var result = decimal.Parse("354224848179261915075");
            fib.GetFib(100).ShouldBe(result);
        }
    }
}

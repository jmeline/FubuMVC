using Shouldly;
using Xunit;

namespace CSharp_Language.Computer_Science_Theory
{
    public class Recursion
    {
        public int FibRecur(int n)
        {
            if (n <= 0)
                return 0;
            if (n == 1)
                return 1;

            return FibRecur(n - 1) + FibRecur(n - 2);
        }

        public int FibLoop(int n)
        {
            var a = 0;
            var b = 1;

            for (var i = 0; i < n; i++)
            {
                var oldB = b;
                b = a + b;
                a = oldB;
            }

            return a;
        }


        [Fact]
        public void FibonacciRecurFunc()
        {
            FibRecur(3).ShouldBe(2);
            FibLoop(3).ShouldBe(2);
        }
    }
}

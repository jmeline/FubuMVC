using System.Collections.Generic;
using System.Linq;
using Shouldly;
using Xunit;

namespace CSharp_Language.Fundamentals
{
    public static class ExtensionMethods
    {
        public static double Sum(this IEnumerable<int> items)
        {
            return Enumerable.Sum(items);
        }

        public static string SurroundWithHello(this string value)
        {
            return "hello" + value + "hello";
        }
    }

    
    public class ExtensionMethodsTests
    {
        [Fact]
        public void TestSumExtension()
        {
            var arr = new List<int> {1, 1, 2, 3, 5, 8, 13, 21, 34, 55};
            arr.Sum().ShouldBe(143);
        }

        [Fact]
        public void TestSurroundWithHello()
        {
            var value = "C#";
            value.SurroundWithHello().ShouldBe("helloC#hello");
        }
    }
}

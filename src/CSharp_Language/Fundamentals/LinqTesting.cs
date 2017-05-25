using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Shouldly;
using Xunit;

namespace CSharp_Language.Fundamentals
{
    public static class LinqImpl
    {

        public static IEnumerable<T> Select<T>(this IEnumerable<T> list, Func<T, bool> predicate)
        {
        }

        public static IEnumerable<T> Where<T>(this IEnumerable<T> list, Func<T, bool> predicate)
        {
            var result = new List<T>();
            foreach (var item in list)
            {
                if (predicate(item))
                {
                    result.Add(item);
                }
            }
            return result;
        }

        public class LinqTesting
        {
            [Fact]
            public void TestMethod1()
            {
                var array = new List<int> {1, 2, 3, 4, 5};
                Func<int, bool> predicate = x => x > 3;
                array.Where(predicate).ShouldBe(Enumerable.Where(array, predicate));
            }
        }
    }
}

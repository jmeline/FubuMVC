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

        public static void Each<TSource>(this IEnumerable<TSource> list, Action<TSource> action)
        {
            foreach (var item in list)
            {
                action(item);
            }
        }

        public static IEnumerable<TResult> Select<TSource, TResult>(this IEnumerable<TSource> list, Func<TSource, TResult> predicate)
        {
            var result = new List<TResult>();

            foreach (var item in list)
            {
                result.Add(predicate(item));
            }
            return result;
        }


        public static IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> list, Func<TSource, bool> predicate)
        {
            var result = new List<TSource>();
            foreach (var item in list)
            {
                if (predicate(item))
                {
                    result.Add(item);
                }
            }
            return result;
        }

        public class Test
        {
            public string randomString;
        }

        public class LinqTesting
        {
            [Fact]
            public void TestSelect()
            {
                var array = new List<int> {1, 2, 3, 4, 5};
                Func<int, int> func = x => x * x * x;
                var actualResult = array.Select(func);
                var expectedResult = Enumerable.Select(array, func);
                actualResult.ShouldBe(expectedResult);
            }

            [Fact]
            public void TestSelectObjects()
            {
                var array = new List<Test>
                {
                    new Test {randomString = "haha"},
                    new Test()
                };

                Func<Test, string> func = x => x.randomString;
                var actualResult = array.Select(func);
                var expectedResult = Enumerable.Select(array, func);
                actualResult.ShouldBe(expectedResult);
            }

            [Fact]
            public void TestWhere()
            {
                var array = new List<int> {1, 2, 3, 4, 5};
                Func<int, bool> predicate = x => x % 2 == 0;
                array.Where(predicate).ShouldBe(Enumerable.Where(array, predicate));
            }
        }
    }
}

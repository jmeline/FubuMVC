using System;
using System.Diagnostics;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace CSharp_Language.Fundamentals
{
    public class StringInterpolation
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public StringInterpolation(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }
        public class Person
        {
            public string Name;
            public int Age;

            public Person()
            {
                
            }

            public Person(string firstName, string middleName, string lastName)
            {
                Name = $"{firstName} {middleName} {lastName}";
            }
        }

        [Fact]
        public void SampleStringInterpolation()
        {
            // string interpolation syntax reduces errors caused by arguments out of order
            // variables my be accessed directly and not through index arguments
             
            // String interpolation is compiler generated syntactic sugar that
            // that dynamically generates "string.Format()" code with compile
            // time expressions that are parameterized.

            // The format string has to be a static string literal.
            // For example:

            /*
             *  This doesn't work
             *  var format = "time: {DateTime.Now}";
             *  Console.WriteLine($format); 
             */

            /*
             *  This works
             *  var format = "time: {0}";
             *  Console.WriteLine(string.Format(format, DateTime.Now)); 
             */

            var samplePerson = new Person()
            {
                Name = "bob",
                Age = 10
            };

            var message = string.Format("Hello! {0}, I am {1} years old", samplePerson.Name, samplePerson.Age);
            message.ShouldBe($"Hello! {samplePerson.Name}, I am {samplePerson.Age} years old");
        }

        [Fact]
        public void SampleConstructorStrinInterpolation()
        {
            new Person("armin", "van", "buuren")
                .Name.ShouldBe("armin van buuren");
        }

        [Fact]
        public void SampleExpressionWithinStringInterpolation()
        {
            Func<int, int> MultiplyBy10 = x => x * 10;
            $"{MultiplyBy10(5)}".ShouldBe("50");
            $"{10 * 10}".ShouldBe("100");
        }

        [Fact]
        public void TestPerformance()
        {
            var stopFormat = Stopwatch.StartNew();
            UseStringFormat(1000000);
            stopFormat.Stop();
            _testOutputHelper.WriteLine($"String format time: {stopFormat.Elapsed}");

            var stopInterpolation = Stopwatch.StartNew();
            UseStringInterpolation(1000000);
            stopInterpolation.Stop();
            _testOutputHelper.WriteLine($"String interpolation time: {stopInterpolation.Elapsed}");

            var stopConcat = Stopwatch.StartNew();
            UseStringConcat(1000000);
            stopConcat.Stop();
            _testOutputHelper.WriteLine($"String concatentation time: {stopConcat.Elapsed}");
        }

        public static void UseStringFormat(int number)
        {
            var random = new Random();
            var text = "";
            for (var i = 0; i <= number; i++)
            {
                text = string.Format("First string {0} second string {1}", random.Next(i, i + 1000), i);
            }
        }

        public static void UseStringInterpolation(int number)
        {
            var random = new Random();
            var text = "";
            for (var i = 0; i <= number; i++)
            {
                text = $"First string {random.Next(i, i + 1000)} second string {i}";
            }
        }

        public static void UseStringConcat(int number)
        {
            var random = new Random();
            var text = "";
            for (var i = 0; i <= number; i++)
            {
                text = "First string " + random.Next(i, i + 1000) + " second string " + i;
            }
        }
    }
}

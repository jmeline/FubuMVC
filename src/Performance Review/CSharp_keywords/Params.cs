using System;
using System.Linq;

namespace Performance_Review.CSharp_keywords
{
    /*
     * 
     * Allows you to specify a method parameter that takes a variable number of arguments
     * 
     * No additional parameters are permitted after the params keyword in a method declaration,
     * and only one params keyword is permitted in a method declaration
     * 
     */

    public class Params
    {
        public static void Example()
        {
            Console.WriteLine("---- Params Example ----");
            SampleParams("comma separated list of ints", 1, 2, 3, 4, 5);
            SampleParams<object>("comma separated list of objects", 1, ".", 3, "%", 4, 5);
            SampleParams<object>("params can accept zero or more arguments");

            string[] stringList = {"a", "b", "c"};
            object[] objectList = {12, "abc", 32};
            SampleParams("In this example, params must be a string", stringList);
            SampleParams("Specifying an object list allows params to be of any type", objectList);

            // Another example of extending a function to allow for any range of values
            Console.WriteLine("1: " + DoubleSumMe(1));
            Console.WriteLine("1, 2, 3: " + DoubleSumMe(1, 2, 3));
            Console.WriteLine("1..1000: " + DoubleSumMe(Enumerable.Range(1, 1000).ToArray()));

            // params allows you to call functions with no arugments.
            //DoubleSumMe_ShouldFail(); Compile error due to empty arguments
            DoubleSumMe(); // Allowed to run without arguments
        }

        private static int DoubleSumMe(params int[] values) => values.Sum(x => x * x);
        private static int DoubleSumMe_ShouldFail(int[] values)
        {
            return DoubleSumMe(values);
        }

        public static void SampleParams<T>(string msg, params T[] list)
        {
            Console.Write(msg + ": ");
            if (list.Length == 0)
            {
                Console.WriteLine("()");
                return;
            }

            foreach (var t in list)
            {
                Console.Write(t + " ");
            }
            Console.WriteLine();
        }
    }
}

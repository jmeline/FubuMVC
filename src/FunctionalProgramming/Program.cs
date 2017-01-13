using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FunctionalProgramming
{
    public static class Program
    {

        // First class/order functions: means that you can store functions into a variable
        static void FirstClassFunctionsDemo()
        {
            Console.WriteLine("First Order Functions");
            Func<int, int, int> add = (a, b) => a + b;
            Console.WriteLine(add(1, 2));
        }

        // Higher Order Functions: functions can return functions or receive other functions as params.
        static void HigherOrderFunctionsDemo()
        {
            Func<int, Func<int, int>> add = a => b => a + b;
            Func<int, int> add2 = add(2);
            add2(3); // => 5
        }

        // Pure Functions: Functions that don't change any value, just receives data and outputs data
        // just like our beloved functions from Math.

        // Closures: mean that you can save some data inside a function that's only accessible to a specific returning function.
        // The returning function keeps its execution environment. Child functions are scoped to their parent functions.
        static void ClosuresDemo()
        {
            Func<string, Func<string, string>> logger = a => b => $"{a}: {b}";
            Func<string, string> warningString = logger("WARNING");
            Console.WriteLine(warningString("This is a warning message"));
        }

        // Currying
        // What is it?
        // Effectively decomposes the function into functions taking a single parameter. We don't pass any arguments into
        // the curry method itself. It converts one sort of function to another.

        // Curry(f) returns a function f1 such that...
        //     f1(a) returns a function f2 such that ...
        //         f2(b) returns a function f3 such that ...
        //             f3(c) invokes f(a, b, c)

        // Uses of currying:
        //  Instead of simply specifying default parameters for functions, you can return specialized functions that serve a special purpose
        // function log_message(log_level, message){}
        // log_error = curry(log_message, error)
        // log_warning = curry(log_message, warning)
        // log_message(WARNING, 'this would be a warning')
        // log_warning('this would also be a warning')

        // One use of currying is to get a new function from a higher order function with a captured variable.
        //
        public static void CurryingDemo()
        {
            Func<int, int, int, string> function = (a, b, c) => $"a={a}; b={b}; c={c}";

            // normal call
            string result = function(1, 2, 3);
            //or
            result = function.Invoke(1, 2, 3);

            // call via currying
            Func<int, Func<int, Func<int, string>>> f1 = Curry(function);
            Func<int, Func<int, string>> f2 = f1(1);
            Func<int, string> f3 = f2(2);
            string result2 = f3(3);

            // Or to do make all the calls together...
            Func<int, Func<int, Func<int, string>>> curried = Curry(function);
            string result3 = curried(1)(2)(3);

            bool condition = (result3 == result2) == (result == result2);
            Debug.Assert(condition);

        }

        

        private static Func<T1, Func<T2, Func<T3, TResult>>> Curry<T1, T2, T3, TResult>(Func<T1, T2, T3, TResult> function)
        {
            return a => b => c => function(a, b, c);
        }

        public static void Main(string[] args)
        {
            
        }
    }
}

using Xunit;

namespace CSharp_Language.Fundamentals
{
    public class StaticVsNonStatic
    {
        private int Test2; 
        private static int Test1;
        private static double GradePointAverge = 95.0;
        
        // Static keyword is used to declare a static member, which belongs to the type itself
        // rather than to a specific object.
        
        // * Static members don't live in the stack or the heap where dynamic memory is stored, instead it 
        // lives in the static area which is created at compile time. It exists before the Main function is called.
        // It doesn't need to grow or shrink (like in the stack or heap). It lives while the program runs.
        
        // * It is not possible to use 'this' to reference static methods or property accessors
        
        // * classes and static classes may have static constructors. Static constructors are called
        //     at some point between when the program starts and the class is instantiated
        // MSDN: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/static
        
        // Issues with relying on static
        // (https://stackoverflow.com/questions/241339/when-to-use-static-classes-in-c-sharp)
        // 1. Polymorphism
        //      If you have a utiliy method defined as a static and you find that down the road the need
        //      to modify parts of the function. Has the method been defined as a non-static, the method
        //      could have benefited from a derived class. This freedom is taken away with static.
        // 2. Interfaces
        //      Static classes cannot derive from interfaces. We aren't able to passing static members
        //      around by their interface. 
        // 3. Hard to Test/mock
        //      When mocking tests, it isn't an option to mock static classes or methods unless a test
        //      uses a wrapper around the static code, it isn't a pretty solution.
        
        
        [Fact]
        public void FieldsMethodsVariablesClassesCanBeStatic()
        {
            // Fields:     private static int Test
            // Properties: private static int Test1 {get; set;}
            // Classes:    public static class Test3 { }
        }

        [Fact]
        public void StaticClassesCannotHaveInstanceMethods()
        {
            // This fails.
            // Non static classes can have static members, not the other way around

            // public class DummyClass { }
            // public static class Test3
            // {
            //     private DummyClass _dummyClass = new DummyClass();
            // }
        }

        [Fact]
        public void StaticClassesCannotImplementAnInterface()
        {
            // This fails. Static classes cannot implement an interface
            
            // static class CannotImplementInterfaces : IDisposable
            // {
            // }
        }

        [Fact]
        public void StaticClassesCannotDeclareAnyConstructors()
        {
            // - This fails as static constructors don't have default constructors,
            //     but can have explicit static classes.
            // - A static constructor is called when anything that has to do with that type is called.
            // - The compiler doesn't create a parameterless constructor by default
            
            // static class DummyClass
            // {
            //     public DummyClass()
            //     {
            //         
            //     }
            // }
        }
        
        [Fact]
        public void StaticClassesMayBeGeneric()
        {
            // This works. static classes/methods are allowed to have generic types
            
            // static class GenericClass<TInput, TResult> where TResult : new()
            // {
            //     static TResult GetGenericType(TInput input)
            //     {
            //         return new TResult();
            //     }
            // }
        }

        [Fact]
        public void StaticClassesMayBeNested()
        {
            // This works, not sure why you'd do this but it is possible in c#
            
            // static class One
            // {
            //     static class Two
            //     {
            //         static class Three
            //         {
            //             static class Four
            //             {
            //                 static int value;   
            //             }
            //         }
            //     }
            // }
            
            // Accessing the value
            // One.Two.Three.Four.value = 10;
        }

        // C# 6 static keyword
        [Fact]
        public void UsingStaticForImportingTypesDirectly()
        {
            // using static System.Console;
            // class Program
            // {
            //     static void Main()
            //     {
            //        WriteLine("Importing static types is awesome");
            //     }
            // }
        }
    }
}
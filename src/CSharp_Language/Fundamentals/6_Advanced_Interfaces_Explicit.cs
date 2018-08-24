using Shouldly;
using Xunit;

namespace CSharp_Language.Fundamentals
{
    // If a class implements two interfaces that contain a member with the same signature, 
    // then implementing that member on the class will cause both interfaces to use that member as their 
    // implementation. In the following example GetValue will invoke the same method.
    public class Advanced_Interfaces_Implicit_Implementation
    {
        class Example : ITest1, ITest2
        {
            // implicitly implemented
            public string GetValue() => "GetValue";
        }

        [Fact]
        public void InvokesSameMethod()
        {
            var stubbedValue = "GetValue";
            var example = new Example();
            ITest1 test1 = example;
            ITest2 test2 = example;
            
            example.GetValue().ShouldBe(stubbedValue); // prints "GetValue"
            test1.GetValue().ShouldBe(stubbedValue);   // prints "GetValue"
            test2.GetValue().ShouldBe(stubbedValue);   // prints "GetValue"
        }

        private interface ITest1
        {
            string GetValue();
        }

        private interface ITest2
        {
            string GetValue();
        }
    }
    
    // A problem can arise where these members that have been treated as one actually perform different
    // operations. We can implement an interface member Explicitly as shown in this example.
    public class Advanced_Interfaces_Explicit_Implementation
    {
        private class Example : IWork, ILive
        {
            // explicitly implemented
            string IWork.Do() => "I Work";
            string ILive.Do() => "I Live";
        }

        [Fact]
        public void InvokesEachMethodSeparatelyDespiteHavingTheSameSignature()
        {
            var example = new Example();
            IWork w = example;
            ILive l = example;
            
            // example.Do() doesn't exist because of explicit implementation.
            w.Do().ShouldBe("I Work");
            l.Do().ShouldBe("I Live");
        }
        
        private interface IWork
        {
            string Do();
        }
        
        private interface ILive
        {
            string Do();
        }
    }

}
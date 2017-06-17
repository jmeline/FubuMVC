using System;
using Shouldly;
using Xunit;

namespace CSharp_Language.Computer_Science_Theory
{
    public class DeclarationVsInitializationVsInstantiation
    {
        [Fact]
        public void Declaration()
        {
            int a; //a is declared. a type and a name is given to introduce a variable to the program
        }

        [Fact]
        public void Instantiate()
        {
            object myObj = new object(); // create a new instance of the object
        }

        [Fact]
        public void Initialization()
        {
            int a = 0; // initialization or assigning a value to a variable
            a = 1; // assigning a new value to 'a'
        }

        [Fact]
        public void VariableBinding()
        {
            // simply the ability to give object names so that they can be accessed by the names. 
            // examples are shown above
        }

        [Fact]
        public void CallStack()
        {
            // a call stack is a stack data structure that stores information about the active subroutines of a computer program
            // aka execution stack, program stack, control stack. 

            // Most importantly, it keeps track of each routine and where it needs to go when the routine finishes.
            // a return address is given.
            Action dummy = () => Console.WriteLine("im a dummy");
            dummy(); //when dummy is called, it must return back to the CallStack routine that it is in.
        }

        [Fact]
        public void StackVsHeap()
        {
            // stack is used for static memory allocation
                // allocation for variables happens when the program compiles.
                // faster memory access
                // the stack is reserved on a LIFO order, the most recently reserved block is the next one to be freed.
            int a;
            string b;
            double c;

            // heap for dynamic memory allocation
                // memory is reserved on runtime
                // newing up an object is placed on the heap
                // slower memory access
                // objects on heap have no dependencies with each other and can be accessed randomly at any time.
            object obj = new object();
        }

        [Fact]
        public void Datatypes()
        {
            int i = 0; //int32 -> valuetype -> object
            typeof(int).BaseType.BaseType.ShouldBe(typeof(object));
        }
    }
}

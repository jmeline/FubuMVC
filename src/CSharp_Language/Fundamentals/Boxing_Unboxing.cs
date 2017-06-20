using System;
using Xunit;
using Shouldly;

namespace CSharp_Language
{
    public class Boxing_Unboxing
    {
        struct Point
        {
            public int x, y;

            public Point(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }
        
        [Fact]
        public void BoxingConvertsAValueTypeToAnObject()
        {
            // boxing converts a value type to an object
            //     - Copies value into allocated memory on the heap.
            //     - Can lead to performance and memory consumption problems

            // int (value type) is created on the 
            // Stack (Static Memory allocation)
            int i = 42;

            // Boxing = int is created on the Heap 
            // (Dynamic Memory Allocation) 
            object o = i; 

            //  Stack   Heap
            // ------- -------
            // i = 42 
            // o    -> (i boxed)
            //         int : 43
        }

        [Fact]
        public void BoxingStructExample()
        {
            var p = new Point(10, 10);
            object @object = p;
            p.x = 20;
            // p is located in a separate space on the heap than
            // @object 
            ((Point)@object).x.ShouldBe(10); 
            p.x.ShouldBe(20);
            ((Point)@object).ShouldNotBeSameAs(p);
            // Doing something like this won't work because boxing makes a copy
            //((Point) @object).x = 20;
            // Unboxing it by casting it back to Point creates another copy.
        }

        [Fact]
        public void UnboxingConvertsAnObjectBackToAValueType()
        {
            object @object = 42;
            int valueType = (int) @object; // unboxing occurs
        }
    }
}

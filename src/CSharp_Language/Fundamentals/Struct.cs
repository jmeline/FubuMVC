using System;
using System.Collections.Generic;
using System.Security.Permissions;
using Castle.Core.Smtp;
using Shouldly;
using Xunit;

namespace CSharp_Language.Fundamentals
{

    // a struct is a value type used to hold small groups of related variables. 
    // it is used for small data structure that contain primarily data that is not intended to be modified
    // after the struct is created. Because it is a value type, a struct is passed by value
    // instead of passed by reference. Memory is copied.
    
    public class Struct
    {

         struct Person
         {
             public int Id;
             public string Name;

             public Person(int id, string name)
             {
                 Id = id;
                 Name = name;
             }
         }

        class Developer { }

        [Fact]
        public void StructsCannotDeriveOrInheritFromOtherStructsOrClasses()
        {
            // structs can implement interfaces, but they cannot implement other structs or classes. 
            // In this case, the Employee struct is throwing an error trying to implement the Person struct.
            // struct Employee : Person {
            // ...
            // } -> Structs can only implement interfaces.
            
        }

        interface ICoder { string Code(); }
        interface ISwimmer { string Swim(); }
        interface IGamer { string Game(); }

        struct Me : ICoder, ISwimmer, IGamer
        {
            public string Code() => "I code";
            public string Swim() => "I swim";
            public string Game() => "I game";
        }
        
        [Fact]
        public void StructsCanImplementAnyNumberOfInterfaces()
        {
            // structs can implement as many interfaces as it wants.
            var me = new Me();
            me.Code().ShouldBe("I code");
            me.Swim().ShouldBe("I swim");
            me.Game().ShouldBe("I game");
        }

        
        // structs can have the following constructs within them
        struct Sample
        {
            // variables
            public int Num;
            public float BigNum;
            public double BiggerNum;
            public long FreakingBigNum;
            public string String;
            
            // enumerations
            enum Colors { GREEN, RED, BLUE, YELLOW };
            
            // static methods
            static void Do(string something) { }
            
            // method
            void Eat(string something) { }
            
            // properties
            public string Property { get; set; }
            
            // operators
            public static bool operator ==(Sample a, Sample b) => a.Equals(b);

            public static bool operator !=(Sample a, Sample b) => !(a == b);

            // Indexers
            public List<int> list { get; set; }
            public int this[int i]
            {
                get => list[i];
                set => list[i] = value;
            }
            
            // events
            delegate string SampleEvent(string str);
            event SampleEvent MyEvent;
        }

        class Point
        {
            public int x, y;

            public Point(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }

        struct Point1
        {
            public int x, y;

            public Point1(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }
        
        [Fact]
        public void StructsOverClassUsage()
        {
            // structs are particularly useful for small data structures that 
            // value semantics. The use of structs rather than classes for small 
            // data structures can make a big difference on memory allocations.
            
            // A rule of thumb is to use structs if you are only using value types
            // else use classes if your structure contains any reference types.
            
            List<Point> locations = new List<Point>();
            for (int i = 0; i < 100; ++i)
            {
                // Creating a new class point this way will initialize
                // 101 separate objects. Since the heap allocations are similar to
                // random access memory, objects can be allocated and deallocated
                // in a random order. Hence the need of a memory manager and 
                // garbage collector to maintain its structure.
                
                // arrays of reference types are allocated out of line
                locations.Add(new Point(i, i)); 
            }
            
            List<Point1> structLocations = new List<Point1>();
            for (int i = 0; i < 100; ++i)
            {
                // arrays of value types are allocated inline.
                // I like this quote about the stack and its interaction with allocated objects.
                // 'The Stack is a highly efficient memory structure that "bookmarks" the
                // stack when a method begins execution, Dumps data into the stack during
                // the method execution and once the method exection completes the stack
                // is reset to the bookmark releasing all the method's allocated memory.' 
                structLocations.Add(new Point1(i, i)); 
            }
        }
        
        void ChangeStruct(SampleStruct ss)
        {
            ss.Value = 20;
        }

        void ChangeClass(SampleClass sc)
        {
            sc.Value = 20;
        }

        public struct SampleStruct
        {
            public int Value { get; set; }
        }

        public class SampleClass
        {
            public int Value { get; set; }
        } 
        
        [Fact]
        public void TestStruct()
        {
            //SampleStruct @struct = null is not allowed as it is not a reference type.
            var @struct = new SampleStruct();
            @struct.ShouldNotBeNull();
            @struct.Value.ShouldBe(0);
            @struct = new SampleStruct
            {
                Value = 10
            };

            // structs inherit from valuetype which inherits from system.object
            Assert.True(typeof(SampleStruct).BaseType == typeof(ValueType));
            @struct.Value.ShouldBe(10);

            // passed by value
            ChangeStruct(@struct);

            // value not changed because it was modified on a copy passed to the method
            @struct.Value.ShouldBe(10);
        }
        
        [Fact]
        public void TestClass()
        {
            SampleClass @class = null;

            // classes are references and thus can point to null
            @class.ShouldBeNull();
            @class = new SampleClass
            {
                Value = 10
            };
            @class.Value.ShouldBe(10);

            // classes inherit from system.object
            Assert.True(typeof(SampleClass).BaseType == typeof(Object));

            // passed by reference
            ChangeClass(@class);
            @class.Value.ShouldBe(20);
        }

    }
}

using System;
using CSharp_Language.Fundamentals;
using Shouldly;
using Xunit;

namespace CSharp_Language.Fundamentals
{

    // a struct is a value type
    public struct SampleStruct
    {
        public int Value { get; set; }
    }

    public enum COLORS
    {
        Black,
        Green,
        Red,
        Yellow,
        White
    }
    
    // a class is a reference type
    public class SampleClass
    {
        public int Value { get; set; }
    } 

    public class Class_Struct_Enum
    {
        void ChangeStruct(SampleStruct ss)
        {
            ss.Value = 20;
        }

        void ChangeClass(SampleClass sc)
        {
            sc.Value = 20;
        }

        [Fact]
        public void TestStruct()
        {
            //SampleStruct @struct = null is not allowed
            var @struct = default(SampleStruct);
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
            @class = new SampleClass()
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

        [Fact]
        public void TestEnum()
        {
            // Enum inherits from ValueType
            typeof(COLORS).BaseType.ShouldBe(typeof(Enum));
            typeof(Enum).BaseType.ShouldBe(typeof(ValueType));
        }
    }
}

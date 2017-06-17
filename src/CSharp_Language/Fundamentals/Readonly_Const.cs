using Shouldly;
using Xunit;

namespace CSharp_Language.Fundamentals
{
    public class Readonly_Const_Static
    {
        public class ConstVSReadonly
        {
            // https://www.exceptionnotfound.net/const-vs-static-vs-readonly-in-c-sharp-applications/
            // const is a compile-value value and is immutable
            // Only primative or build-in c# types can be declared as "const"

            // public const string connection_string; // requires a value at declaration. Value cannot be changed later. 
            // If a const variable exists in Assembly A and is used in Assembly B, when Assembly A gets recompiled 
            // with a new value for the const variable Assembly B will still have the previous value until it is also recompiled.
            public const string value = "Hello Const";


            // read only is a runtime constant. it is evaluated when the application is launched and not before.
            //   Assignment to that field can only occur as part of the declaration of the class or constructor

            public readonly string value2 = "Hello Readonly";


            // static 
            // belongs to the type of the object rather than to an instance.
            public static readonly string value3 = "Im static readonly";

            public ConstVSReadonly()
            {
                // readonly
                value2 = "I can change this in the constructor";

                // const
                // No good...
                //value = "I cannot update a const variable";
            }

        }

        public class SampleClass
        {
            public static string MyString = "Random String";
        }

        [Fact]
        public void Testing()
        {
            var result = SampleClass.MyString;
            result.ShouldBe("Random String");

            ConstVSReadonly.value.ShouldBe("Hello Const");
            ConstVSReadonly.value3.ShouldBe("Im static readonly");

        }
    }
}

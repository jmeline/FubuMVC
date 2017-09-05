using System;
using Shouldly;
using Xunit;

namespace CSharp_Language.Computer_Science_Theory
{
    public class ValueAndReferenceTypes
    {
        public void OfTypeStuctAndBaseTypeValueType<T>()
        {
            typeof(T).IsValueType.ShouldBeTrue();
        }

        [Fact]
        public void ValueTypes()
        {
            OfTypeStuctAndBaseTypeValueType<double>();
            OfTypeStuctAndBaseTypeValueType<long>();
            OfTypeStuctAndBaseTypeValueType<short>();
        }
    }
}

using Shouldly;
using Xunit;

namespace DesignPatterns.Structural_Patterns
{
    /// <summary>
    /// Convert the interface of a class into another interface clients expect. 
    /// Adapter lets classes work together that couldn't otherwise because of incompatible interfaces.
    ///
    /// Frequency of use: Medium high (4/5)
    /// </summary>
    public class AdapterTests
    {
        [Fact]
        public void TestStructrualExample()
        {
            var target = new Target();
            target.Request().ShouldBe("Target");
            var adaptee = new Adaptee();
            var cheeseAdaptee = new CheeseAdaptee();
            new Adapter(adaptee).Request().ShouldBe("Adaptee");
            new Adapter(cheeseAdaptee).Request().ShouldBe("Cheese");
        }
    }
}

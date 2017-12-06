using Shouldly;
using Xunit;

namespace DesignPatterns.Creational_Patterns.Factory.SimpleFactory
{
    public class FactoryTests
    {
        [Fact]
        public void NaiveObjectCreation()
        {
            // breaks single responsibility principle
            // as if I want to add a new car, I will 
            // need to add more case statements to 
            // my switch statement in NaiveGetCarExample.
            var factory = new Factory();
            factory.NaiveGetCarExample("audi")
                .ShouldBeOfType<AudiTTS>();
            factory.NaiveGetCarExample("bmw")
                .ShouldBeOfType<BMW335Xi>();
            factory.NaiveGetCarExample("mini")
                .ShouldBeOfType<MiniCooper>();
            factory.NaiveGetCarExample("asdf")
                .ShouldBeOfType<NullCar>();
        }

        [Fact]
        public void BetterFactoryTests()
        {
            var factory = new Factory();
            factory.GetCar("audi").ShouldBeOfType<AudiTTS>();
            factory.GetCar("bmw").ShouldBeOfType<BMW335Xi>();
            factory.GetCar("mini").ShouldBeOfType<MiniCooper>();
            factory.GetCar("asdf").ShouldBeOfType<NullCar>();
        }
    }
}

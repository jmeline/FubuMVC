using System;
using Shouldly;
using Xunit;

namespace DesignPatterns.Creational_Patterns.Abstract_Factory
{
    public class AbstractFactoryTests
    {
        [Fact]
        public void TestMiniCooperFactory()
        {
            IAutoFactory factory = LoadFactory<MiniCooperFactory>();

            factory.CreateEconomyCar().Name.ShouldBe("Mini Cooper");
            factory.CreateLuxuryCar().Name.ShouldBe("Mini Cooper with luxury package");
            factory.CreateSportsCar().Name.ShouldBe("Mini Cooper with sport package");
        }

        [Fact]
        public void TestBMWFactory()
        {
            IAutoFactory factory = LoadFactory<BMWFactory>();
            factory.CreateEconomyCar().Name.ShouldBe("BMWM3");
            factory.CreateLuxuryCar().Name.ShouldBe("BMW740i");
            factory.CreateSportsCar().Name.ShouldBe("BMW328i");
        }

        private IAutoFactory LoadFactory<T>()
        {
            return (IAutoFactory)Activator.CreateInstance(typeof(T));
        }
    }
}

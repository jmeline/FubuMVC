
using System.Reflection;
using Shouldly;
using Xunit;

namespace DesignPatterns.Creational_Patterns.Factory.FactoryMethod
{
    public class FactoryTest
    {
        [Fact]
        public void Test()
        {
            IAutoFactory autoFactory = LoadFactory();
            IAuto car = autoFactory.CreateAutomobile();
            car.Name.ShouldBe("Mini Cooper S");
        }

        public IAutoFactory LoadFactory()
        {
            string name = Properties.settings.Default.AutoFactory;
            return Assembly.GetExecutingAssembly().CreateInstance(name) as IAutoFactory;
        }
    }
}

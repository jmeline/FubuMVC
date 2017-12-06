
namespace DesignPatterns.Creational_Patterns.Factory.FactoryMethod
{
    public class MiniCooper : IAuto
    {
        public string Name { get; set; }

        public void TurnOn()
        {
            throw new System.NotImplementedException();
        }

        public void TurnOff()
        {
            throw new System.NotImplementedException();
        }
    }

    public class BMW : IAuto
    {
        public string Name { get; set; }

        public void TurnOn()
        {
            throw new System.NotImplementedException();
        }

        public void TurnOff()
        {
            throw new System.NotImplementedException();
        }
    }

    public class MiniCooperFactory : IAutoFactory
    {
        public IAuto CreateAutomobile()
        {
            return new MiniCooper { Name = "Mini Cooper S" };
        }
    }

    public class BMWFactory : IAutoFactory
    {
        public IAuto CreateAutomobile()
        {
            return new BMW { Name = "BMW" };
        }
    }
}

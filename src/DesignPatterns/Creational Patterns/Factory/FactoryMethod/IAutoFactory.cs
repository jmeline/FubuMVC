
namespace DesignPatterns.Creational_Patterns.Factory.FactoryMethod
{
    public interface IAutoFactory
    {
        IAuto CreateAutomobile();
    }

    public interface IAuto
    {
        string Name { get; set; }
        void TurnOn();
        void TurnOff();
    }
}

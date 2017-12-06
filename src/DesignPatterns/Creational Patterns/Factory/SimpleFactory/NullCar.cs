
namespace DesignPatterns.Creational_Patterns.Factory.SimpleFactory
{
    public class NullCar : IAuto
    {
        public void TurnOn()
        {
            throw new System.NotImplementedException();
        }

        public void TurnOff()
        {
            throw new System.NotImplementedException();
        }
    }
}
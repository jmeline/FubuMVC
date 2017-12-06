
namespace DesignPatterns.Creational_Patterns.Factory.SimpleFactory
{
    public class Factory
    {
        public IAuto NaiveGetCarExample(string carName)
        {
            switch (carName)
            {
                case "bmw":
                    return new BMW335Xi();
                case "mini":
                    return new MiniCooper();
                case "audi":
                    return new AudiTTS();
                default:
                    return new NullCar();
            }
        }

        public IAuto GetCar(string carName)
        {
            var factory = new CarFactory();
            return factory.CreateInstance(carName);
        }
    }
}

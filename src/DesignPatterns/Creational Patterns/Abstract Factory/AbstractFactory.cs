
namespace DesignPatterns.Creational_Patterns.Abstract_Factory
{
    public interface IAutoFactory
    {
        IAutomobile CreateEconomyCar();
        IAutomobile CreateLuxuryCar();
        IAutomobile CreateSportsCar();
    }

    public class MiniCooperFactory : IAutoFactory
    {
        public IAutomobile CreateEconomyCar()
        {
            return new MiniCooper();
        }

        public IAutomobile CreateLuxuryCar()
        {
            var mini = new MiniCooper();
            mini.AddLuxuryPackage();
            return mini;
        }

        public IAutomobile CreateSportsCar()
        {
            var mini = new MiniCooper();
            mini.AddSportPackage();
            return mini;
        }
    }

    public class BMWFactory : IAutoFactory
    {
        public IAutomobile CreateEconomyCar()
        {
            return new BMWM3();
        }

        public IAutomobile CreateLuxuryCar()
        {
            return new BMW740i();
        }

        public IAutomobile CreateSportsCar()
        {
            return new BMW328i();
        }
    }

    public interface IAutomobile
    {
        string Name { get; set; }
    }

    public class MiniCooper : IAutomobile
    {
        public string Name { get; set; }

        public MiniCooper()
        {
            Name = "Mini Cooper";
        }

        public void AddSportPackage()
        {
            Name += " with sport package";
        }

        public void AddLuxuryPackage()
        {
            Name += " with luxury package";
        }
    }

    public abstract class NullAutomobile : IAutomobile
    {
        public string Name { get; set; }
    }

    public abstract class BMWBase : IAutomobile
    {
        public string Name { get; set; }
    }

    public class BMWM3 : BMWBase
    {
        public BMWM3()
        {
            Name = "BMWM3";
        }
    }

    public class BMW740i : BMWBase
    {
        public BMW740i()
        {
            Name = "BMW740i";
        }
    }

    public class BMW328i : BMWBase
    {
        public BMW328i()
        {
            Name = "BMW328i";
        }
    }
}
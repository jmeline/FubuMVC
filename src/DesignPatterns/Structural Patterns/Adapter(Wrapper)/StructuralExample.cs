
namespace DesignPatterns.Structural_Patterns
{
    public interface IAdapt
    {
        string Request();
    }

    public class Adapter : Target
    {
        private readonly IAdapt _adaptee;

        public Adapter(IAdapt adaptee) 
        {
            _adaptee = adaptee;
        }

        public override string Request() => _adaptee.Request();
    }

    public class Adaptee : IAdapt
    {
        public string Request() => "Adaptee";
    }

    public class CheeseAdaptee : IAdapt
    {
        public string Request() => "Cheese";
    }

    public class Target
    {
        public virtual string Request() => "Target";
    }
}

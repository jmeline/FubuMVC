using System;

namespace IoC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Inversion of Control
            //   High level Pattern that can be applied in different ways to invert different kinds of control

            // Dependancy Injection

            // *******************************
            //      Manual Dependancy 
            // *******************************
            // Dependancies are manually created and are passed into the classes constructor.
            // This creates the need to manually create each dependancy 

            // ICreditCard creditCard = new MasterCard();
            // ICreditCard otherCreditCard = new Visa();
            // var shopper = new Shopper(otherCreditCard);
            // shopper.Charge();
            //
            // Console.Read();

            // *******************************
            //      Resolving Dependancies
            // *******************************

            // Resolver resolver = new Resolver();
            // var shopper = new Shopper(resolver.ResolveCreditCard());
            // shopper.Charge();
            //
            // Console.Read();

            // *******************************
            //      Container
            // *******************************

            var resolver = new Resolver();
            resolver.Register<Shopper, Shopper>();
            resolver.Register<ICreditCard, Visa>();
            var shopper = resolver.Resolve<Shopper>();
            shopper.Charge();
            Console.Read();

        }
    }
}

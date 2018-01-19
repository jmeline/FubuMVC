using Xunit;

namespace CSharp_Language.Solid_Principles._4_Interface_Segregation_Principle
{
    public class InterfaceSegregationPrincipleGoodExample
    {
        // example of a thin contract
        public interface IOrder
        {
            void Purchase();
        }
        
        public interface IPayPal
        {
            void ProcessPayPal();
        }

        public class AmazonOrder : IOrder, IPayPal
        {
            public void Purchase()
            {
                // handle transaction
            }

            public void ProcessPayPal()
            {
                // paypal transaction
            }
        }

        public class CashOrder : IOrder
        {
            public void Purchase()
            {
                // handle transaction
            }
        }

        [Fact]
        public void TestMethod1()
        {
        }
    }
}

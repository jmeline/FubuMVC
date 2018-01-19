using System;
using Xunit;

namespace CSharp_Language.Solid_Principles._4_Interface_Segregation_Principle
{
    public class InterfaceSegregationPrincipleBadExample
    {
        // no objects should be forced to implement methods which it does
        // not use and contracts should be broken down into thin ones.

        // example of a thick contract
        public interface IOrder
        {
            void Purchase();
            void ProcessPayPal();
        }

        public class AmazonOrder : IOrder
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

            public void ProcessPayPal()
            {
                // Violates ISP
                throw new Exception("Not needed to cash order");
            }
        }

        [Fact]
        public void TestMethod1()
        {
        }
    }
}

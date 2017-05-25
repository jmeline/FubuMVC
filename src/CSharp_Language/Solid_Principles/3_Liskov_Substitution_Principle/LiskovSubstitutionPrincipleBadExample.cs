using System;
using System.Collections.Generic;
using Shouldly;
using Xunit;

namespace CSharp_Language.Solid_Principles._3_Liskov_Substitution_Principle
{
    public class LiskovSubstitutionPrincipleBadExample
    {
        public class SpecialCustomers
        {
            List<Customer> list = new List<Customer>();

            public virtual void AddCustomer(Customer obj)
            {
                list.Add(obj);
            }

            public int Count => list.Count;
        }

        public class SuperSpecialCustomers : SpecialCustomers
        {
            private int max = 5;

            public override void AddCustomer(Customer obj)
            {
                if (Count < max)
                {
                    base.AddCustomer(obj);
                }
                else
                {
                    throw new Exception("Bad stuff happens");
                }


            }
        }

        public class Customer
        {
        }

        [Fact]
        public void ExampleBreakingSubstitutionPrinciple()
        {
            try
            {
                SpecialCustomers sc = new SuperSpecialCustomers();
                for (int i = 10; i >= 0; i--)
                {
                    Customer obj = new Customer();
                    sc.AddCustomer(obj);
                }
            }
            catch (Exception ex)
            {
                Assert.True(true);
            }
        }
    }

}

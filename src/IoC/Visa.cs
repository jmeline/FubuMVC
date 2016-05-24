using System;

namespace IoC
{
    public class Visa : ICreditCard
    {
        public string CardName
        {
            get { return "Visa"; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(value));
                CardName = value;
            }
        }

        public string Charge()
        {
            return "Charging with the Visa";
        }
    }
}
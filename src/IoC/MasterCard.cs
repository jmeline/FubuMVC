using System;

namespace IoC
{
    public class MasterCard : ICreditCard
    {
        public string CardName
        {
            get { return "MasterCard"; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(value));
                CardName = value;
            }
        }

        public string Charge()
        {
            return "Swiping the MasterCard";
            
        }
    }
}
namespace IoC
{
    public class MasterCard : ICreditCard
    {
        public string Charge()
        {
            return "Swiping the MasterCard";
            
        }
    }
}
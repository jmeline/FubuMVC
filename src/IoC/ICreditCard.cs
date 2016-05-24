namespace IoC
{
    public interface ICreditCard
    {
        string CardName { get; set; }
        string Charge();
    }
}
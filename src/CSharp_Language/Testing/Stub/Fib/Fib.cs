
namespace CSharp_Language.Testing.Stub
{
    public class Fib : IFib
    {
        public decimal GetFib(int value)
        {
            switch (value)
            {
                case 0:
                    return 0;
                case 1:
                    return 1;
                default:
                    return GetFib(value - 2) + GetFib(value - 1);
            }
        }
    }
}

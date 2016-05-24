using Shouldly;
using Xunit;

namespace IoC.Tests
{
    public class ShopperIocTest
    {
        private readonly Resolver _resolver;

        public ShopperIocTest()
        {
            _resolver = new Resolver();
            _resolver.Register<Shopper, Shopper>();
        }

        [Fact]
        public void ShopperUsesMasterCard()
        {
            _resolver.Register<ICreditCard, MasterCard>();
            var shopper = _resolver.Resolve<Shopper>();
            shopper.GetCardName().ShouldBe("MasterCard");
        }

        [Fact]
        public void ShopperUsesVisa()
        {
            _resolver.Register<ICreditCard, Visa>();
            var shopper = _resolver.Resolve<Shopper>();
            shopper.GetCardName().ShouldBe("Visa");
        }
    }
}

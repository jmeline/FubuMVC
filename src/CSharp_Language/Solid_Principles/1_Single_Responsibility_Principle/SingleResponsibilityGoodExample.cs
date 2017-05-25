using Xunit;

namespace CSharp_Language.Solid_Principles._1_Single_Responsibility_Principle
{
    public class SingleResponsibilityGoodExample
    {
        // abstract out responsibilities into separate classes
        public interface IShopOperations
        {
            void OpenShop();
            void CloseShop();
        }

        public interface IShopDataExporter
        {
            void ExportShopData();
        }

        public class ShopOperations : IShopOperations
        {
            public void OpenShop()
            {
            }

            public void CloseShop()
            {
            }
        }
         
        public class ShopDataExporter : IShopDataExporter
        {
            public void ExportShopData()
            {
            }
        }

        public class ShopHelper
        {

            public void ServiceVehicle(Vehicle vehicle)
            {
                
            }
            
        }

        [Fact]
        public void TestMethod1()
        {
        }
    }
}

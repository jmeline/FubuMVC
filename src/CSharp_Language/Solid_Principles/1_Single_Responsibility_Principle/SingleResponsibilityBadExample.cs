using Xunit;

namespace CSharp_Language.Solid_Principles._1_Single_Responsibility_Principle
{
    public class SingleResponsibilityBadExample
    {
        // This ShopHelper object doesn't need to know about 
        //  whether the shop is open or closed. This violates the Single Responsibility Principle
        public class ShopHelper
        {
            public void OpenShop()
            {
                
            }

            public void CloseShop()
            {
                
            }

            public void ServiceVehicle(Vehicle vehicle)
            {
                
            }

            public void ExportShopData()
            {
                
            }
        }

    }

    public class Vehicle
    {
    }
}

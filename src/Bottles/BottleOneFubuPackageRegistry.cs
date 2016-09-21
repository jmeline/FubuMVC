
using FubuMVC.Core;

namespace Bottles
{
    public class BottleOneFubuPackageRegistry : FubuPackageRegistry
    {
        public BottleOneFubuPackageRegistry()
        {
            UrlPrefix = "http://localhost/";
        } 
    }
}

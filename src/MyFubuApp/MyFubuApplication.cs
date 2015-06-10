using FubuMVC.Core;
using FubuMVC.StructureMap;
using StructureMap;
using StructureMap.Configuration.DSL;

namespace MyFubuApp
{

    public class MyFubuApplication : IApplicationSource
    {

        public FubuApplication BuildApplication()
        {
            var fubuApp = FubuApplication.For<MyFubuApplicationRegistry>().StructureMap();
            return fubuApp;
        }
    }

    public class MyFubuApplicationRegistry : FubuRegistry
    {
        public MyFubuApplicationRegistry()
        {

        }        
    }

    public class MyRegistry : Registry
    {
        public MyRegistry()
        {
            For<IApplicationSource>().Use<MyFubuApplication>();
            
        }
    }
}

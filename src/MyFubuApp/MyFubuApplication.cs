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
            AlterSettings<DiagnosticsSettings>(x => x.TraceLevel = TraceLevel.Verbose);
            Services(x =>
            {
                x.AddService<IRegistry, MyRegistry>();
            });
        }        
    }

    public class MyRegistry : Registry
    {
        public MyRegistry()
        {
            
        }
    }
}

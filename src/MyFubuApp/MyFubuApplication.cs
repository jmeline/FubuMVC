using FubuMVC.Core;
using FubuMVC.StructureMap;
using Raven.Client;
using Raven.Client.Document;
using StructureMap.Building;
using StructureMap.Configuration.DSL;

namespace MyFubuApp
{

    public class MyFubuApplication : IApplicationSource
    {
        public FubuApplication BuildApplication()
        {
            var fubuApp = FubuApplication.For<MyFubuApplicationRegistry>()
                .StructureMap<MyStructureMapFubuApplicationRegistry>();
            return fubuApp;
        }
    }

    public class MyFubuApplicationRegistry : FubuRegistry
    {
        public MyFubuApplicationRegistry()
        {
            Actions
                .IncludeClassesSuffixedWithEndpoint();
            AlterSettings<DiagnosticsSettings>(x => x.TraceLevel = TraceLevel.Verbose);
        }
    }

    public class MyStructureMapFubuApplicationRegistry : Registry
    {
        public MyStructureMapFubuApplicationRegistry()
        {
            IncludeRegistry<RavenDbRegistry>();
        }
    }

    public class RavenDbRegistry : Registry
    {
        public RavenDbRegistry()
        {
            var documentStore = new DocumentStore { ConnectionStringName = "localhost" }.Initialize();
            For<IDocumentSession>().Use(() => documentStore.OpenSession());
            For<IDocumentStore>().Singleton().Use(documentStore);
        }
    }
}

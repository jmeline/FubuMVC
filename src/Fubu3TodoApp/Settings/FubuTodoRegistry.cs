using FubuMVC.Core;
using StructureMap;

namespace Fubu3TodoApp.Settings
{
    public class FubuTodoRegistry : FubuRegistry
    {
        public FubuTodoRegistry()
        {
            Features.Diagnostics.Enable(TraceLevel.Verbose);
            Actions.IncludeClassesSuffixedWithEndpoint();

            StructureMap(new Container( new FubuTodoStructureMapRegistry() ));
        }
    }

    public class FubuTodoStructureMapRegistry : Registry
    {
        public FubuTodoStructureMapRegistry()
        {
            Scan(x =>
            {
                x.WithDefaultConventions();
            });
        }
    }
}
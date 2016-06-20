using System.Globalization;
using Fubu3TodoApp.Behaviors;
using FubuMVC.Core;
using FubuMVC.Core.Registration;
using FubuMVC.Core.Registration.Nodes;
using StructureMap;

namespace Fubu3TodoApp.Settings
{
    public class FubuTodoRegistry : FubuRegistry
    {
        public FubuTodoRegistry()
        {
            Features.Diagnostics.Enable(TraceLevel.Verbose);

            // Setup Localization
            Features.Localization.Enable(true);
            Features.Localization.Configure(_ =>
            {
                _.DefaultCulture = new CultureInfo("en-US");
            });

            Actions.FindBy(a =>
            {
                a.Applies.ToThisAssembly();
                a.IncludeClassesSuffixedWithEndpoint();
            });

            Policies.Global.Add<SamplePolicy>();

            StructureMap(new Container(new FubuTodoStructureMapRegistry()));
        }
    }

    public class SamplePolicy : IConfigurationAction
    {
        public void Configure(BehaviorGraph graph)
        {
            
            foreach (var action in graph.Actions())
            {
                if (action.Method.DeclaringType != null &&
                    action.Method.DeclaringType.Name == "HomeEndpoint")
                {
                    var parameters = action.Method.GetParameters();
                    action.AddBefore(new Wrapper(typeof (SayHello)));
                    action.AddBefore(new Wrapper(typeof (SayGoodbye)));
                }
            }
        }
    }

    public class FubuTodoStructureMapRegistry : Registry
    {
        public FubuTodoStructureMapRegistry()
        {
            Scan(x => { x.WithDefaultConventions(); });
        }
    }
}
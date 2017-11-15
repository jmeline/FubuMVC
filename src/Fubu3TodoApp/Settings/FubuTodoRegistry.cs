using System.Globalization;
using Fubu3TodoApp.Behaviors;
using FubuMVC.Core;
using FubuMVC.Core.Registration;
using FubuMVC.Core.Registration.Nodes;

namespace Fubu3TodoApp.Settings
{
    public class FubuTodoRegistry : FubuRegistry
    {
        public FubuTodoRegistry()
        {
            // Enables Diagnostic page
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
                // Endpoint is defaulted
                a.IncludeClassesSuffixedWithEndpoint();

                // Flexibility to change 
                //a.IncludeTypesNamed(x => x.EndsWith("example"));
                a.IncludeClassesSuffixedWithController();
            });

            Policies.Local.Add<SamplePolicy>();
            Policies.Local.Add<FubuJsonSerializationSettings>();
        }

    }

    public class SamplePolicy : IConfigurationAction
    {
        public void Configure(BehaviorGraph graph)
        {
            foreach (var action in graph.Actions())
            {
                if (action.Method.DeclaringType != null && action.Method.DeclaringType.Name == "HomeEndpoint")
                {
                    var parameters = action.Method.GetParameters();
                    action.AddBefore(new Wrapper(typeof (SayHello)));
                    action.AddBefore(new Wrapper(typeof (SayGoodbye)));
                }
            }
        }
    }
}
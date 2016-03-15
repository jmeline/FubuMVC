using System.Collections.Generic;
using System.Diagnostics;
using FubuMVC.Core;
using FubuMVC.Core.Behaviors;
using FubuMVC.Core.Registration;
using FubuMVC.Core.Registration.Nodes;
using StructureMap;
using TraceLevel = FubuMVC.Core.TraceLevel;

namespace Fubu3TodoApp.Settings
{
    public class FubuTodoRegistry : FubuRegistry
    {
        public FubuTodoRegistry()
        {
            Features.Diagnostics.Enable(TraceLevel.Verbose);
            Actions.IncludeClassesSuffixedWithEndpoint();

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
                    action.AddBefore(new Wrapper(typeof (SayHelloBehavior)));
                    action.AddBefore(new Wrapper(typeof (SayGoodbyeBehavior)));
                }
            }
        }
    }

    public class SayHelloBehavior : IActionBehavior
    {
        public IActionBehavior InsideBehavior { get; set; }

        public void Invoke()
        {
            Debug.WriteLine("Hello");
            InsideBehavior?.Invoke();
        }

        public void InvokePartial()
        {
            InsideBehavior?.InvokePartial();
        }
    }

    public class SayGoodbyeBehavior : IActionBehavior
    {
        public IActionBehavior InsideBehavior { get; set; }

        public void Invoke()
        {
            Debug.WriteLine("GoodBye");
            InsideBehavior?.Invoke();
        }

        public void InvokePartial()
        {
            InsideBehavior?.InvokePartial();
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
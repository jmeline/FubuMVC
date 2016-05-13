using System.Diagnostics;
using FubuMVC.Core.Behaviors;

namespace Fubu3TodoApp.Behaviors
{
    public class SayHello : IActionBehavior
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
}
using System.Diagnostics;
using FubuMVC.Core.Behaviors;

namespace Fubu3TodoApp.Behaviors
{
    public class SayGoodbye : IActionBehavior
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
}
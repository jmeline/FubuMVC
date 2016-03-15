using FubuMVC.Core.Continuations;

namespace Fubu3TodoApp.Endpoints
{
    public class HomeEndpoint
    {
        public FubuContinuation Index()
        {
            //return new HomeViewModel();
            return FubuContinuation.RedirectTo("Index.html");
        }
    }

    public class HomeViewModel
    {
        public string name { get; set; }
    }
}
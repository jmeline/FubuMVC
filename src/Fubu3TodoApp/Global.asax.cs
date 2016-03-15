using System;
using Fubu3TodoApp.Settings;
using FubuCore;
using FubuMVC.Core;

namespace Fubu3TodoApp
{
    public class Global : System.Web.HttpApplication
    {

        private FubuRuntime _runtime;

        protected void Application_Start(object sender, EventArgs e)
        {
            _runtime = FubuRuntime.For<FubuTodoRegistry>();
        }


        protected void Application_End(object sender, EventArgs e)
        {
            if (_runtime != null)
            {
                _runtime.SafeDispose();
            }
        }
    }
}
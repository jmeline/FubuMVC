using System;
using System.Web;

namespace MyFubuApp
{
    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            new MyFubuApplication().BuildApplication().Bootstrap();
        }
    }
}
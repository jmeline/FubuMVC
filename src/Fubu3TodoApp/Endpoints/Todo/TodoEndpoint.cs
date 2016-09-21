using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fubu3TodoApp.Endpoints.Todo
{
    public class TodoEndpoint
    {
        public TodoViewModel get_Todo()
        {
            var model = new TodoViewModel();
            return model;
        }
    }
}
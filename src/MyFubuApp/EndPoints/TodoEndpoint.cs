using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FubuMVC.Core.Continuations;
using Raven.Client;

namespace MyFubuApp.EndPoints
{
    /// <summary>
    /// TodoApp page
    /// </summary>
    public class TodoEndPoint
    {
        private readonly IDocumentSession _session;
        public TodoEndPoint(IDocumentSession session)
        {
            _session = session;
        }

        public TodoViewModel App(TodoImportModel model)
        {
            var todos = _session.Query<Todo>()
                .Customize(x => x.WaitForNonStaleResults())
                .ToList();
            return new TodoViewModel { Todos = todos };
        }

        public FubuContinuation post_addItem(AddItemInputModel itemInputModel)
        {
            _session.Store(new Todo
            {
                Task = itemInputModel.Task, 
                Assignee = itemInputModel.Assignee,
                IsCompleted = itemInputModel.IsCompleted
            });

            _session.SaveChanges();

            return FubuContinuation.RedirectTo<TodoImportModel>();
        }
    }

    public class TodoImportModel
    {
    }

    public class TodoViewModel
    {
        public IList<Todo> Todos { get; set; }
        public TodoViewModel()
        {
            Todos = new List<Todo>();
        }
    }

    public class Todo
    {
        public string Assignee { get; set; }
        public bool IsCompleted { get; set; }
        public string Task { get; set; }
    }

    public class AddItemInputModel
    {
        public string Assignee { get; set; }
        public bool IsCompleted { get; set; }
        public string Task { get; set; }
        
    }


}
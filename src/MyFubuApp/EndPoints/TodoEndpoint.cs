using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FubuMVC.Core;
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
            try
            {
                var todos = _session.Query<Todo>()
                    .Customize(x => x.WaitForNonStaleResults())
                    .ToList();
                return new TodoViewModel
                {
                    EditingId = model.Id,
                    Todos = todos
                };
            }
            catch (Exception)
            {
                Console.WriteLine("Turn on RavenDB stupid!");
                throw;
            }

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

        public FubuContinuation post_edit_Id(EditInputItemModel itemInputModel)
        {
            Todo edited_todo = _session.Load<Todo>("todos/" + itemInputModel.Id);
            return FubuContinuation.RedirectTo(new TodoImportModel
            {
                Id = itemInputModel.Id
            });
        }

        public FubuContinuation post_rm_Id(DeleteInputItemModel deleteInputItemModel)
        {
            _session.Delete("todos/" + deleteInputItemModel.Id);
            _session.SaveChanges();
            return FubuContinuation.RedirectTo<TodoImportModel>();
        }

        public FubuContinuation post_update_Id(UpdateInputItemModel updateInputItemModel)
        {
            var edited_todo = _session.Load<Todo>("todos/" + updateInputItemModel.Id);

            edited_todo.Task = updateInputItemModel.Task;
            edited_todo.IsCompleted = updateInputItemModel.IsCompleted;
            edited_todo.Assignee = updateInputItemModel.Assignee;

            _session.SaveChanges();
            return FubuContinuation.RedirectTo<TodoImportModel>();
        }
    }

    public class TodoImportModel
    {
        [QueryString]
        public int? Id { get; set; }
    }

    public class TodoViewModel
    {
        public IList<Todo> Todos { get; set; }
        public int? Id { get; set; }
        public int? EditingId { get; set; }

        public TodoViewModel()
        {
            Todos = new List<Todo>();
        }
    }

    public class Todo
    {
        public int Id { get; set; }
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

    public class DeleteInputItemModel
    {
        public int Id { get; set; }

    }

    public class EditInputItemModel
    {
        public int Id { get; set; }
    }

    public class UpdateInputItemModel
    { 
        public int Id { get; set; }
        public string Assignee { get; set; }
        public bool IsCompleted { get; set; }
        public string Task { get; set; }
    }


}
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
            return new TodoViewModel();
        }

        public TodoViewModel post_TodoApp(AddItemInputModel itemInputModel)
        {
            
            _session.Store(itemInputModel);
            _session.SaveChanges();

            return new TodoViewModel()
            {
                Task = itemInputModel.Task, 
                Assignee = itemInputModel.Assignee,
                IsCompleted = itemInputModel.IsCompleted
            };
        }
    }

    public class TodoImportModel
    {
    }

    public class TodoViewModel
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
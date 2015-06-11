namespace MyFubuApp.EndPoints
{
    /// <summary>
    /// TodoApp page
    /// </summary>
    public class TodoEndPoint
    {
        public TodoViewModel App(TodoImportModel model)
        {
            return new TodoViewModel();
        }

        public TodoViewModel post_TodoApp(AddItemInputModel itemInputModel)
        {
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
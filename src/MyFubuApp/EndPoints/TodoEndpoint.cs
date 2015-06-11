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

        public AddItemModel post_AddItem(AddItemInputModel itemInputModel)
        {
            return new AddItemModel();
        }
 
    }

    public class TodoImportModel
    {
    }

    public class TodoViewModel
    {
    }

    public class AddItemInputModel
    {
        public string Assignee { get; set; }
        public bool IsCompleted { get; set; }
        public string Task { get; set; }
    }

    public class AddItemModel
    {
    }
    
}
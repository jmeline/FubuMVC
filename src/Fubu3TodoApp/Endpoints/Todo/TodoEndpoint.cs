namespace Fubu3TodoApp.Endpoints.Todo
{
    public class TodoEndpoint
    {
        public TodoViewModel get_Todo()
        {
            return new TodoViewModel();
        }
    }
}
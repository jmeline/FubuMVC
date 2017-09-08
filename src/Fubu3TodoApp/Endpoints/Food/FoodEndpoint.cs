namespace Fubu3TodoApp.Endpoints.Food
{
    public class FoodEndpoint
    {
        public FoodViewModel get_FoodDescription()
        {
            //var description = ConfigurationManager.AppSettings["Description"];
            return new FoodViewModel
            {
                Description = Localization.Food.Pizza.Description
            };
        }
    }
}
using Fubu3TodoApp.Localization;
namespace Fubu3TodoApp.Endpoints.Food
{
    public class FoodEndpoint
    {
        public FoodViewModel get_FoodDescription()
        {
            return new FoodViewModel()
            {
                Description = Localization.Food.Pizza.Description
            };
        }
    }
}
using FubuMVC.Core.Localization;

namespace Fubu3TodoApp.Localization
{
    public class Food
    {
        public string Description;

        public static Food Pizza = new Food(FoodDescriptionToken.Pizza);
        public static Food Sushi = new Food(FoodDescriptionToken.Sushi);
        public static Food RootBeer = new Food(FoodDescriptionToken.RootBeer);

        private Food(StringToken food)
        {
            Description = food.DefaultValue;
        }
    }
}
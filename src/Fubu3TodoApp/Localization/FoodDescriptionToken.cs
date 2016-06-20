using FubuMVC.Core.Localization;

namespace Fubu3TodoApp.Localization
{
    public class FoodDescriptionToken : StringToken
    {
        public static FoodDescriptionToken Pizza = new FoodDescriptionToken("Pizza is a flatbread generally topped with tomato sauce and cheese and baked in an oven. It is commonly topped with a selection of {meats}, {vegetables} and {condiments}. The term was first recorded in the 10th century, in a Latin manuscript from Gaeta in Central Italy.[1] The modern pizza was invented in Naples, Italy, and the dish and its variants have since become popular in many areas of the world.");
    
        public static FoodDescriptionToken Sushi = new FoodDescriptionToken("Sushi is a food preparation originating in Japan, consisting of cooked vinegared rice (鮨飯 sushi-meshi?) combined with other ingredients (ネタ neta?) such as raw seafood, vegetables and sometimes tropical fruits. Ingredients and forms of sushi presentation vary widely, but the ingredient which all sushi have in common is rice (also referred to as shari (しゃり?) or sumeshi (酢飯?))");

        public static FoodDescriptionToken RootBeer = new FoodDescriptionToken("Root Beer is a brown sweet beverage traditionally made using the root beer tree Sassafras albidum (sassafras) or the vine Smilax ornata (sarsaparilla) as the primary flavor. Root beer may be alcoholic or non-alcoholic, and may be carbonated or non-carbonated. Most root beer has a thick foamy head when poured. Modern, commercially produced root beer is generally sweet, foamy, carbonated, and non-alcoholic, and is flavoured using sassafras. It may or may not contain caffeine.");

        public FoodDescriptionToken(string defaultValue) : base(null, defaultValue)
        {
        }

    }
}
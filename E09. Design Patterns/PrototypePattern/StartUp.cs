namespace PrototypePattern
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SandwichMenu menu = new SandwichMenu();

            //Default sandwiches
            menu["BLT"] =
                new Sandwich("Wheat", "Bacon", "", "Lettuce, Tomato");
            menu["PB&J"] =
                new Sandwich("White", "", "", "Peanut Butter, Jelly");
            menu["Turkey"] =
                new Sandwich("Rye", "Turkey", "Swiss", "Lettuce, Onion, Tomato");

            //Deli manager adds custom sandwiches
            menu["LoadedBLT"] =
                new Sandwich("Wheat", "Turkey, Bacon", "American", "Lettuce, Tomato, Onion, Olives");
            menu["ThreeMeatCombo"] =
                new Sandwich("Rye", "Turkey, Ham, Salami", "Provolone", "Lettuce, Onion");
            menu["Vegetarian"] =
                new Sandwich("Wheat", "", "", "Lettuce, Onion, Tomato, Olives, Spinach");

            //Up to here we have initialized menu with sandwiches
            //Here we can start serving different instances of sandwiches
            Sandwich sandwich1 = (menu["BLT"].Clone() as Sandwich)!;
            Sandwich sandwich2 = (menu["ThreeMeatCombo"].Clone() as Sandwich)!;
            Sandwich sandwich3 = (menu["Vegetarian"].Clone() as Sandwich)!;
        }
    }
}
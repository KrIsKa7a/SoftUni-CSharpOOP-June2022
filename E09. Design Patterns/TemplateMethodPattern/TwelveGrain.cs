namespace TemplateMethodPattern
{
    //Current selection of the menu
    public class TwelveGrain : Bread
    {
        public override void MixIngredients()
        {
            //In case of real device -> there should be the logic for mixing the bread (fast, slow...)
            Console.WriteLine("Gathering ingredients for 12-Grain Bread!");
        }

        public override void Bake()
        {
            //In case of real device -> you should program the heater to be on for 25 minutes on selected temperature
            Console.WriteLine("Baking the 12-Grain Bread! (25 minutes)");
        }
    }
}

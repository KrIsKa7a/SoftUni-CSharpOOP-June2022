namespace TemplateMethodPattern
{
    public class SourDough : Bread
    {
        public override void MixIngredients()
        {
            Console.WriteLine("Gathering the ingredients for SourDough Bread!");
        }

        public override void Bake()
        {
            Console.WriteLine("Baking the SourDough Bread! (20 minutes)");
        }
    }
}

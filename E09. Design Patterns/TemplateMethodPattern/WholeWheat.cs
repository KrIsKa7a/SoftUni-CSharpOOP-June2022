namespace TemplateMethodPattern
{
    public class WholeWheat : Bread
    {
        public override void MixIngredients()
        {
            Console.WriteLine("Gathering ingredients for WholeWheat Bread!");
        }

        public override void Bake()
        {
            Console.WriteLine("Baking the WholeWheat Bread! (15 minutes)");
        }
    }
}

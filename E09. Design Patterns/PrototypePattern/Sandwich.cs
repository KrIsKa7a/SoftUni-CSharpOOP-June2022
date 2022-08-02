namespace PrototypePattern
{
    public class Sandwich : SandwichPrototype
    {
        //This is not a part of the Prototype Pattern
        //Example data
        private readonly string bread;
        private readonly string meat;
        private readonly string cheese;
        private readonly string veggies;

        public Sandwich(string bread, string meat, string cheese, string veggies)
        {
            this.bread = bread;
            this.meat = meat;
            this.cheese = cheese;
            this.veggies = veggies;
        }

        //Properties are allowed

        //The part of the pattern is inside this method!!!
        public override SandwichPrototype Clone()
        {
            string ingredients = this.GetIngredientsList();
            //Good to implement Reader
            Console.WriteLine($"Cloning sandwich with ingredients: {ingredients}");

            return (this.MemberwiseClone() as SandwichPrototype)!;
        }

        private string GetIngredientsList()
        {
            return $"{this.bread}, {this.meat}, {this.cheese}, {this.veggies}";
        }
    }
}

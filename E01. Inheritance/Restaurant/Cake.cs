namespace Restaurant
{
    public class Cake : Dessert
    {
        private const double CakeGrams = 250;
        private const double CakeCalories = 1000;
        private const decimal CakePrice = 5m;

        public Cake(string name) 
            : base(name, CakePrice, CakeGrams, CakeCalories)
        {

        }

        //Not for Judge
        public override string ToString()
        {
            return $"{this.Grams}g {this.Name} - {this.Price}$, Calories: {this.Calories}kCal";
        }
    }
}

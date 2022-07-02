namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        //Hard-code from the problem description
        private const double CoffeeMilliliters = 50;
        private const decimal CoffeePrice = 3.50m;

        //Change the value of the property in the base class -> Use base() constructor
        //Change the logic of the get or set of a property -> override
        public Coffee(string name, double caffeine)
            : base(name, CoffeePrice, CoffeeMilliliters)
        {
            this.Caffeine = caffeine;
        }

        public double Caffeine { get; set; }
    }
}

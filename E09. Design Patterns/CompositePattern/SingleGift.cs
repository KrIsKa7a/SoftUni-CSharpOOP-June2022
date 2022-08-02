namespace CompositePattern
{
    public class SingleGift : GiftBase
    {
        public SingleGift(string name, int price) 
            : base(name, price)
        {
        }

        public override int CalculateTotalPrice()
        {
            Console.WriteLine($"{this.name} with the price {this.price}");

            return this.price;
        }
    }
}

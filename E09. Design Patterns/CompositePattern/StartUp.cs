namespace CompositePattern
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            GiftBase phone = new SingleGift("Phone", 256);
            phone.CalculateTotalPrice();
            Console.WriteLine();

            CompositeGift rootBox = new CompositeGift("RootBox", 0);
            GiftBase truckToy = new SingleGift("TruckToy", 289);
            GiftBase plainToy = new SingleGift("PlainToy", 587);

            rootBox.Add(truckToy);
            rootBox.Add(plainToy);

            CompositeGift childBox = new CompositeGift("ChildBox", 0);
            GiftBase soldierToy = new SingleGift("SoldierToy", 200);
            childBox.Add(soldierToy);

            rootBox.Add(childBox);

            Console.WriteLine($"Total price of this composite present is: {rootBox.CalculateTotalPrice()}");
        }
    }
}
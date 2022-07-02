namespace Restaurant
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            Cake cake = new Cake("Bavarian Cake");
            Console.WriteLine(cake);
        }
    }
}